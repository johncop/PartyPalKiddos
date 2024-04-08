using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyKid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIndexForAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Venues_Id",
                table: "Venues",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_Name",
                table: "Venues",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_VenueImages_Id",
                table: "VenueImages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_Id",
                table: "TimeSlots",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Id",
                table: "Services",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Name",
                table: "Services",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePackages_Id",
                table: "ServicePackages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePackages_Name",
                table: "ServicePackages",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePackageImages_Id",
                table: "ServicePackageImages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategories_Id",
                table: "ServiceCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategories_Name",
                table: "ServiceCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Id",
                table: "Foods",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Name",
                table: "Foods",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_Id",
                table: "FoodCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_Name",
                table: "FoodCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_Id",
                table: "Districts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CouponTypes_Id",
                table: "CouponTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CouponTypes_Name",
                table: "CouponTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Id",
                table: "Coupons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Name",
                table: "Coupons",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_Id",
                table: "Combos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_Name",
                table: "Combos",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Id",
                table: "Bookings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_Id",
                table: "BookingDetails",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Venues_Id",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Venues_Name",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_VenueImages_Id",
                table: "VenueImages");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_Id",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Services_Id",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_Name",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_ServicePackages_Id",
                table: "ServicePackages");

            migrationBuilder.DropIndex(
                name: "IX_ServicePackages_Name",
                table: "ServicePackages");

            migrationBuilder.DropIndex(
                name: "IX_ServicePackageImages_Id",
                table: "ServicePackageImages");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCategories_Id",
                table: "ServiceCategories");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCategories_Name",
                table: "ServiceCategories");

            migrationBuilder.DropIndex(
                name: "IX_Foods_Id",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_Name",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_FoodCategories_Id",
                table: "FoodCategories");

            migrationBuilder.DropIndex(
                name: "IX_FoodCategories_Name",
                table: "FoodCategories");

            migrationBuilder.DropIndex(
                name: "IX_Districts_Id",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_CouponTypes_Id",
                table: "CouponTypes");

            migrationBuilder.DropIndex(
                name: "IX_CouponTypes_Name",
                table: "CouponTypes");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_Id",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_Name",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Combos_Id",
                table: "Combos");

            migrationBuilder.DropIndex(
                name: "IX_Combos_Name",
                table: "Combos");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Id",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_Id",
                table: "BookingDetails");
        }
    }
}
