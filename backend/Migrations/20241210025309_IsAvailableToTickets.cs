using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCSharpers_QuikTix.Migrations
{
    /// <inheritdoc />
    public partial class IsAvailableToTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "Showtimes");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "Showtimes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
