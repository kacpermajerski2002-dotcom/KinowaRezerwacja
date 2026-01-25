using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinowaRezerwacja.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixReservationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Movies_MovieId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Reservations",
                newName: "SeanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MovieId",
                table: "Reservations",
                newName: "IX_Reservations_SeanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seances_SeanceId",
                table: "Reservations",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seances_SeanceId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "SeanceId",
                table: "Reservations",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_SeanceId",
                table: "Reservations",
                newName: "IX_Reservations_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Movies_MovieId",
                table: "Reservations",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
