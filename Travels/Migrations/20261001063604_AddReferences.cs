using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travels.Migrations
{
    /// <inheritdoc />
    public partial class AddReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Trips",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransportId",
                table: "Trips",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CountryId",
                table: "Trips",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TransportId",
                table: "Trips",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Countries_CountryId",
                table: "Trips",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Transports_TransportId",
                table: "Trips",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Countries_CountryId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Transports_TransportId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CountryId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_TransportId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "Trips");
        }
    }
}
