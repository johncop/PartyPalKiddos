using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyKid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingTimeSlotTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlot_Bookings_BookingId",
                table: "BookingTimeSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlot_TimeSlots_TimeSlotId",
                table: "BookingTimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingTimeSlot",
                table: "BookingTimeSlot");

            migrationBuilder.RenameTable(
                name: "BookingTimeSlot",
                newName: "BookingTimeSlots");

            migrationBuilder.RenameIndex(
                name: "IX_BookingTimeSlot_TimeSlotId",
                table: "BookingTimeSlots",
                newName: "IX_BookingTimeSlots_TimeSlotId");

            migrationBuilder.AlterColumn<string>(
                name: "Weekday",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "TimeSlots",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "TimeSlots",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingTimeSlots",
                table: "BookingTimeSlots",
                columns: new[] { "BookingId", "TimeSlotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlots_Bookings_BookingId",
                table: "BookingTimeSlots",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlots_TimeSlots_TimeSlotId",
                table: "BookingTimeSlots",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlots_Bookings_BookingId",
                table: "BookingTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlots_TimeSlots_TimeSlotId",
                table: "BookingTimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingTimeSlots",
                table: "BookingTimeSlots");

            migrationBuilder.RenameTable(
                name: "BookingTimeSlots",
                newName: "BookingTimeSlot");

            migrationBuilder.RenameIndex(
                name: "IX_BookingTimeSlots_TimeSlotId",
                table: "BookingTimeSlot",
                newName: "IX_BookingTimeSlot_TimeSlotId");

            migrationBuilder.AlterColumn<string>(
                name: "Weekday",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "TimeSlots",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "TimeSlots",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingTimeSlot",
                table: "BookingTimeSlot",
                columns: new[] { "BookingId", "TimeSlotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlot_Bookings_BookingId",
                table: "BookingTimeSlot",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlot_TimeSlots_TimeSlotId",
                table: "BookingTimeSlot",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
