using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

public class PartyKidDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public PartyKidDbContext(DbContextOptions<PartyKidDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(PartyKidDbContext).Assembly);
    }

    public override int SaveChanges()
    {
        OnBeforeSaving();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    #region Entities
    //Booking
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingDetail> BookingDetails { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }

    //Combo
    public DbSet<Combo> Combos { get; set; }
    public DbSet<ComboFood> ComboFoods { get; set; }

    //Coupon
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<CouponType> CouponTypes { get; set; }

    //Food
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodCategory> FoodCategories { get; set; }

    //Venue
    public DbSet<District> Districts { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<VenueCombo> VenueCombos { get; set; }
    public DbSet<VenueFood> VenueFoods { get; set; }
    public DbSet<VenueImage> VenueImages { get; set; }
    public DbSet<VenueService> VenueServices { get; set; }
    public DbSet<VenueServicePackage> VenueServicePackages { get; set; }

    //Service
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }

    //Service Package
    public DbSet<ServicePackage> ServicePackages { get; set; }
    public DbSet<ServicePackageImage> ServicePackageImages { get; set; }
    public DbSet<ServicePackageDetail> ServicePackageDetails { get; set; }

    #endregion

    #region Support Function
    private void OnBeforeSaving()
    {
        IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry> entries = ChangeTracker.Entries();
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry in entries)
        {
            if (entry.Entity is BaseEntity trackableEntity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        trackableEntity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        trackableEntity.UpdatedDate = DateTime.Now;
                        break;
                }
            }
        }
    }
    #endregion
}
