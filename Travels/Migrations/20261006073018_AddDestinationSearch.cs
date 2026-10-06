using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travels.Migrations
{
    /// <inheritdoc />
    public partial class AddDestinationSearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationSearch",
                table: "Trips",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
                migrationBuilder.Sql("UPDATE Trips SET DestinationSearch = lower(Destination)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationSearch",
                table: "Trips");
        }
    }
}
