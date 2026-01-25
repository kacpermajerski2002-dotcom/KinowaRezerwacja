using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KinowaRezerwacja.Data;
using KinowaRezerwacja.Models;

namespace KinowaRezerwacja.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservationsController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int seatId, int seanceId)
        {
            var userId = _userManager.GetUserId(User);

            // Czy miejsce już zajęte?
            var exists = await _context.Reservations
                .AnyAsync(r => r.SeatId == seatId && r.SeanceId == seanceId);

            if (exists)
            {
                return BadRequest("Miejsce jest już zajęte.");
            }

            var reservation = new Reservation
            {
                SeatId = seatId,
                SeanceId = seanceId,
                UserId = userId!,
                ReservationDate = DateTime.Now
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(
                "Details",
                "UserSeances",
                new { id = seanceId }
            );
        }

        // GET: Reservations/MyReservations
        public async Task<IActionResult> MyReservations()
        {
            var userId = _userManager.GetUserId(User);

            var reservations = await _context.Reservations
                .Include(r => r.Seat)
                .ThenInclude(s => s.Hall)
                .Include(r => r.Seance)
                .ThenInclude(s => s.Movie)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return View(reservations);
        }

        // POST: Reservations/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = _userManager.GetUserId(User);

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(r => r.Id == id && r.UserId == userId);

            if (reservation == null)
                return NotFound();

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyReservations));
        }
    }
}
