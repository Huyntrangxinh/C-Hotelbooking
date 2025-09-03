using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddContractFieldsToProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessLicensePath",
                table: "Properties",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSignatoryDirector",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LegalEntityAddress",
                table: "Properties",
                type: "TEXT",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalEntityName",
                table: "Properties",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatoryEmail",
                table: "Properties",
                type: "TEXT",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatoryIdCardPath",
                table: "Properties",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatoryName",
                table: "Properties",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatoryPhoneNumber",
                table: "Properties",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatoryPosition",
                table: "Properties",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxPayerAddress",
                table: "Properties",
                type: "TEXT",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxPayerName",
                table: "Properties",
                type: "TEXT",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessLicensePath",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsSignatoryDirector",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LegalEntityAddress",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LegalEntityName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SignatoryEmail",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SignatoryIdCardPath",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SignatoryName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SignatoryPhoneNumber",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SignatoryPosition",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TaxPayerAddress",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TaxPayerName",
                table: "Properties");
        }
    }
}
