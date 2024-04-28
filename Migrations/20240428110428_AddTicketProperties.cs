using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toll_Payment.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Ticket");
        }
    }
}
