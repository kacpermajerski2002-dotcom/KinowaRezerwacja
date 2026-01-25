using KinowaRezerwacja.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KinowaRezerwacja.Controllers
{
    public class UserSeancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserSeancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserSeances
        public async Task<IActionResult> Index()
        {
            var seances = await _context.Seances
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .ToListAsync();

            return View(seances);
        }

        public async Task<IActionResult> Details(int id)
        {
            var seance = await _context.Seances
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                    .ThenInclude(h => h.Seats)
                .Include(s => s.Reservations)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seance == null)
                return NotFound();

            return View(seance);
        }


        [Authorize]
        public async Task<IActionResult> MyReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reservations = await _context.Reservations
                .Where(r => r.UserId == userId)
                .Include(r => r.Seat)
                .Include(r => r.Seance)
                    .ThenInclude(s => s.Movie)
                .Include(r => r.Seance)
                    .ThenInclude(s => s.Hall)
                .ToListAsync();

            return View(reservations);
        }


    }
}
