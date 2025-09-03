using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyContactAndPicInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicEmail",
                table: "Properties",
                type: "TEXT",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicFirstName",
                table: "Properties",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicLastName",
                table: "Properties",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicPhoneCountryCode",
                table: "Properties",
                type: "TEXT",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicPhoneNumber",
                table: "Properties",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicPosition",
                table: "Properties",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyPhoneCountryCode",
                table: "Properties",
                type: "TEXT",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyPhoneNumber",
                table: "Properties",
                type: "TEXT",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicEmail",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PicFirstName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PicLastName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PicPhoneCountryCode",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PicPhoneNumber",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PicPosition",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyPhoneCountryCode",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyPhoneNumber",
                table: "Properties");
        }
    }
}
