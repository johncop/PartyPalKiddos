using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class PartyPalKiddosDBContext : DbContext
    {
        public PartyPalKiddosDBContext()
        {
        }

        public PartyPalKiddosDBContext(DbContextOptions<PartyPalKiddosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailableTimeSlot> AvailableTimeSlots { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingFoodDetail> BookingFoodDetails { get; set; } = null!;
        public virtual DbSet<BookingServiceDetail> BookingServiceDetails { get; set; } = null!;
        public virtual DbSet<BookingTimeSlot> BookingTimeSlots { get; set; } = null!;
        public virtual DbSet<Combo> Combos { get; set; } = null!;
        public virtual DbSet<ComboFoodDetail> ComboFoodDetails { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<CouponType> CouponTypes { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<FoodCategory> FoodCategories { get; set; } = null!;
        public virtual DbSet<Host> Hosts { get; set; } = null!;
        public virtual DbSet<HostComboDetail> HostComboDetails { get; set; } = null!;
        public virtual DbSet<HostImage> HostImages { get; set; } = null!;
        public virtual DbSet<HostServiceDetail> HostServiceDetails { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public virtual DbSet<ServicePackage> ServicePackages { get; set; } = null!;
        public virtual DbSet<ServicePackageDetail> ServicePackageDetails { get; set; } = null!;
        public virtual DbSet<ServicePackageImage> ServicePackageImages { get; set; } = null!;
        public virtual DbSet<TimeSlot> TimeSlots { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PartyPalKiddo"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableTimeSlot>(entity =>
            {
                entity.ToTable("AvailableTimeSlot");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TimeslotId).HasColumnName("timeslot_id");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.AvailableTimeSlots)
                    .HasForeignKey(d => d.HostId)
                    .HasConstraintName("FK_AvailableTimeSlot_Host");

                entity.HasOne(d => d.Timeslot)
                    .WithMany(p => p.AvailableTimeSlots)
                    .HasForeignKey(d => d.TimeslotId)
                    .HasConstraintName("FK_AvailableTimeSlot_TimeSlot");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasColumnName("booking_date");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(50)
                    .HasColumnName("booking_status");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.NumberOfAdults).HasColumnName("number_of_adults");

                entity.Property(e => e.NumberOfKids).HasColumnName("number_of_kids");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CouponId)
                    .HasConstraintName("FK__Orders__coupon_i__778AC167");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__user_id__76969D2E");
            });

            modelBuilder.Entity<BookingFoodDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BookingFoodDetail");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.ComboId).HasColumnName("combo_id");

                entity.Property(e => e.ComboQuantity).HasColumnName("combo_quantity");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.FoodQuantity).HasColumnName("food_quantity");

                entity.HasOne(d => d.Booking)
                    .WithMany()
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_BookingFoodDetail_Booking");

                entity.HasOne(d => d.Combo)
                    .WithMany()
                    .HasForeignKey(d => d.ComboId)
                    .HasConstraintName("FK_BookingFoodDetail_Combo");

                entity.HasOne(d => d.Food)
                    .WithMany()
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_BookingFoodDetail_Food");
            });

            modelBuilder.Entity<BookingServiceDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BookingServiceDetail");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ServicePackageId).HasColumnName("service_package_id");

                entity.Property(e => e.ServicePackageQuantity).HasColumnName("service_package_quantity");

                entity.Property(e => e.ServiceQuantity).HasColumnName("service_quantity");

                entity.HasOne(d => d.Booking)
                    .WithMany()
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_BookingServiceDetail_Booking");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_BookingServiceDetail_Service");

                entity.HasOne(d => d.ServicePackage)
                    .WithMany()
                    .HasForeignKey(d => d.ServicePackageId)
                    .HasConstraintName("FK_BookingServiceDetail_ServicePackage");
            });

            modelBuilder.Entity<BookingTimeSlot>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BookingTimeSlot");

                entity.Property(e => e.AvailableTimeslotId).HasColumnName("available_timeslot_id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.HasOne(d => d.AvailableTimeslot)
                    .WithMany()
                    .HasForeignKey(d => d.AvailableTimeslotId)
                    .HasConstraintName("FK_BookingTimeSlot_AvailableTimeSlot");

                entity.HasOne(d => d.Booking)
                    .WithMany()
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_BookingTimeSlot_Booking");
            });

            modelBuilder.Entity<Combo>(entity =>
            {
                entity.ToTable("Combo");

                entity.Property(e => e.ComboName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("combo_name");

                entity.Property(e => e.ComboPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("combo_price");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("text")
                    .HasColumnName("img_url");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ComboFoodDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ComboFoodDetail");

                entity.Property(e => e.ComboId).HasColumnName("combo_id");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Combo)
                    .WithMany()
                    .HasForeignKey(d => d.ComboId)
                    .HasConstraintName("FK_ComboFoodDetail_Combo");

                entity.HasOne(d => d.Food)
                    .WithMany()
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_ComboFoodDetail_Food");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvailableDate)
                    .HasColumnType("datetime")
                    .HasColumnName("available_date");

                entity.Property(e => e.ConditionAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("condition_amount");

                entity.Property(e => e.CouponName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("coupon_name");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("discount_amount");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expired_date");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Coupons)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Coupons_CouponType");
            });

            modelBuilder.Entity<CouponType>(entity =>
            {
                entity.ToTable("CouponType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FoodCategoryId).HasColumnName("food_category_id");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("food_name");

                entity.Property(e => e.ImageUrl)
                    .HasColumnType("text")
                    .HasColumnName("image_url");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.FoodCategory)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.FoodCategoryId)
                    .HasConstraintName("FK_Food_FoodCategory");
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("FoodCategory");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FoodCategoryName)
                    .HasMaxLength(255)
                    .HasColumnName("food_category_name");
            });

            modelBuilder.Entity<Host>(entity =>
            {
                entity.ToTable("Host");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DistrictId).HasColumnName("District_id");

                entity.Property(e => e.HostName)
                    .HasMaxLength(100)
                    .HasColumnName("host_name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Hosts)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_Host_District");
            });

            modelBuilder.Entity<HostComboDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HostComboDetail");

                entity.Property(e => e.ComboId).HasColumnName("combo_id");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.HasOne(d => d.Combo)
                    .WithMany()
                    .HasForeignKey(d => d.ComboId)
                    .HasConstraintName("FK_HostComboDetail_Combo");

                entity.HasOne(d => d.Food)
                    .WithMany()
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_HostComboDetail_Food");

                entity.HasOne(d => d.Host)
                    .WithMany()
                    .HasForeignKey(d => d.HostId)
                    .HasConstraintName("FK_HostComboDetail_Host");
            });

            modelBuilder.Entity<HostImage>(entity =>
            {
                entity.ToTable("HostImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .HasColumnName("Img_url");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.HostImages)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_HostImage_Host");
            });

            modelBuilder.Entity<HostServiceDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HostServiceDetail");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ServicePackageId).HasColumnName("service_package_id");

                entity.HasOne(d => d.Host)
                    .WithMany()
                    .HasForeignKey(d => d.HostId)
                    .HasConstraintName("FK_HostServiceDetail_Host");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_HostServiceDetail_Service");

                entity.HasOne(d => d.ServicePackage)
                    .WithMany()
                    .HasForeignKey(d => d.ServicePackageId)
                    .HasConstraintName("FK_HostServiceDetail_ServicePackage");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentUrl)
                    .HasColumnType("text")
                    .HasColumnName("payment_url");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payment__order_i__7C4F7684");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceCategoryId).HasColumnName("service_category_Id");

                entity.Property(e => e.ServiceImage)
                    .HasMaxLength(200)
                    .HasColumnName("service_image");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .HasColumnName("service_name");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("FK_Service_ServiceCategory");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.ToTable("ServiceCategory");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<ServicePackage>(entity =>
            {
                entity.ToTable("ServicePackage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.PackageName)
                    .HasMaxLength(50)
                    .HasColumnName("package_name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ServicePackageDetail>(entity =>
            {
                entity.HasNoKey();

                entity.HasKey(spd => new { spd.ServicePackageId, spd.ServiceId });

                entity.ToTable("ServicePackageDetail");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.ServicePackageId).HasColumnName("service_package_Id");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_PackageDetail_Service1");

                entity.HasOne(d => d.ServicePackage)
                    .WithMany()
                    .HasForeignKey(d => d.ServicePackageId)
                    .HasConstraintName("FK_PackageDetail_Package");
            });

            modelBuilder.Entity<ServicePackageImage>(entity =>
            {
                entity.ToTable("ServicePackageImage");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(200)
                    .HasColumnName("Img_url");

                entity.Property(e => e.ServicePackageId).HasColumnName("service_package_id");

                entity.HasOne(d => d.ServicePackage)
                    .WithMany(p => p.ServicePackageImages)
                    .HasForeignKey(d => d.ServicePackageId)
                    .HasConstraintName("FK_PackageImage_Package");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("TimeSlot");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Hours).HasColumnName("hours");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Weekday)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("weekday");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61646663D104")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__role_id__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
