using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyKid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableBookingTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingTimeSlot",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    AvailableTimeSlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTimeSlot", x => new { x.BookingId, x.AvailableTimeSlotId });
                    table.ForeignKey(
                        name: "FK_BookingTimeSlot_AvailableTimeSlots_AvailableTimeSlotId",
                        column: x => x.AvailableTimeSlotId,
                        principalTable: "AvailableTimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTimeSlot_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingTimeSlot_AvailableTimeSlotId",
                table: "BookingTimeSlot",
                column: "AvailableTimeSlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTimeSlot");
        }
    }
}
