using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReception24Hours = table.Column<bool>(type: "INTEGER", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    ExteriorPhotoPath = table.Column<string>(type: "TEXT", nullable: true),
                    InteriorPhotoPath = table.Column<string>(type: "TEXT", nullable: true),
                    RoomPhotoPath = table.Column<string>(type: "TEXT", nullable: true),
                    HasSmokingArea = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAccessibleBathroom = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasElevator = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasPublicWifi = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAccessibleParking = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasParkingArea = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasCafe = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasRestaurant = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasBar = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasFrontDesk = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasExpressCheckIn = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasConcierge = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasExpressCheckOut = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasLaundryService = table.Column<bool>(type: "INTEGER", nullable: false),
                    Has24HourSecurity = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasLuggageStorage = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAirportTransfer = table.Column<bool>(type: "INTEGER", nullable: false),
                    StarRating = table.Column<int>(type: "INTEGER", nullable: true),
                    RoomDescription = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfRooms = table.Column<int>(type: "INTEGER", nullable: true),
                    RoomTypes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyData_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyData_PropertyId",
                table: "PropertyData",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyData");
        }
    }
}
