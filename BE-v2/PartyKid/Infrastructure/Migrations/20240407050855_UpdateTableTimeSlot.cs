using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyKid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Venues_VenueId",
                table: "TimeSlots");

            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "TimeSlots",
                newName: "StartTime");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "TimeSlots",
                type: "time",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Venues_VenueId",
                table: "TimeSlots",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Venues_VenueId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TimeSlots");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "TimeSlots",
                newName: "Hours");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "TimeSlots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Venues_VenueId",
                table: "TimeSlots",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id");
        }
    }
}
