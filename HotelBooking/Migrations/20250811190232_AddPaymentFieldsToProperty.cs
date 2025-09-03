using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentFieldsToProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowPaymentAtHotel",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountHolderName",
                table: "Properties",
                type: "TEXT",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                table: "Properties",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranch",
                table: "Properties",
                type: "TEXT",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Properties",
                type: "TEXT",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Properties",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowPaymentAtHotel",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "BankAccountHolderName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "BankBranch",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Properties");
        }
    }
}
