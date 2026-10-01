using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travels.Migrations
{
    /// <inheritdoc />
    public partial class UniqueTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trips_Destination_StartDate",
                table: "Trips",
                columns: new[] { "Destination", "StartDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trips_Destination_StartDate",
                table: "Trips");
        }
    }
}
