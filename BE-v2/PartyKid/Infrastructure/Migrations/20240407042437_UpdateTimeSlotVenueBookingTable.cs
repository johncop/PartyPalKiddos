using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyKid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeSlotVenueBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlot_AvailableTimeSlots_AvailableTimeSlotId",
                table: "BookingTimeSlot");

            migrationBuilder.DropTable(
                name: "AvailableTimeSlots");

            migrationBuilder.RenameColumn(
                name: "AvailableTimeSlotId",
                table: "BookingTimeSlot",
                newName: "TimeSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingTimeSlot_AvailableTimeSlotId",
                table: "BookingTimeSlot",
                newName: "IX_BookingTimeSlot_TimeSlotId");

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "TimeSlots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_VenueId",
                table: "TimeSlots",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlot_TimeSlots_TimeSlotId",
                table: "BookingTimeSlot",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Venues_VenueId",
                table: "TimeSlots",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlot_TimeSlots_TimeSlotId",
                table: "BookingTimeSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Venues_VenueId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_VenueId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "TimeSlots");

            migrationBuilder.RenameColumn(
                name: "TimeSlotId",
                table: "BookingTimeSlot",
                newName: "AvailableTimeSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingTimeSlot_TimeSlotId",
                table: "BookingTimeSlot",
                newName: "IX_BookingTimeSlot_AvailableTimeSlotId");

            migrationBuilder.CreateTable(
                name: "AvailableTimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableTimeSlots_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableTimeSlots_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTimeSlots_TimeSlotId",
                table: "AvailableTimeSlots",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTimeSlots_VenueId",
                table: "AvailableTimeSlots",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlot_AvailableTimeSlots_AvailableTimeSlotId",
                table: "BookingTimeSlot",
                column: "AvailableTimeSlotId",
                principalTable: "AvailableTimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
