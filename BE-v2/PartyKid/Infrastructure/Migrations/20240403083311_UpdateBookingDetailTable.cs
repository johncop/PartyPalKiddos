using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyKid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingDetails",
                table: "BookingDetails");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BookingDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BookingDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BookingDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingDetails",
                table: "BookingDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_BookingId",
                table: "BookingDetails",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingDetails",
                table: "BookingDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_BookingId",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BookingDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingDetails",
                table: "BookingDetails",
                columns: new[] { "BookingId", "FoodId", "ComboId", "ServiceId", "ServicePackageId" });
        }
    }
}
