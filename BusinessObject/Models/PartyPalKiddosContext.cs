using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class PartyPalKiddosContext : DbContext
    {
        public PartyPalKiddosContext()
        {
        }

        public PartyPalKiddosContext(DbContextOptions<PartyPalKiddosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<CouponType> CouponTypes { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<LocationImage> LocationImages { get; set; } = null!;
        public virtual DbSet<LocationType> LocationTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<PackageCategory> PackageCategories { get; set; } = null!;
        public virtual DbSet<PackageDetail> PackageDetails { get; set; } = null!;
        public virtual DbSet<PackageImage> PackageImages { get; set; } = null!;
        public virtual DbSet<PackageTag> PackageTags { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public virtual DbSet<ServiceImage> ServiceImages { get; set; } = null!;
        public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PartyPalKiddo"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

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

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DistrictId).HasColumnName("District_id");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TypeId).HasColumnName("Type_id");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_Location_District");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Location_LocationType");
            });

            modelBuilder.Entity<LocationImage>(entity =>
            {
                entity.ToTable("LocationImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .HasColumnName("Img_url");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationImages)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_LocationImg_Location");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("LocationType");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.UserId, "idx_order_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_amount");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CouponId)
                    .HasConstraintName("FK__Orders__coupon_i__778AC167");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__user_id__76969D2E");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.PackageId).HasColumnName("Package_Id");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Orders");

                entity.HasOne(d => d.Package)
                    .WithMany()
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_OrderDetail_Package");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.HasIndex(e => e.UserId, "idx_package_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.NumberOfAdults).HasColumnName("number_of_adults");

                entity.Property(e => e.NumberOfKids).HasColumnName("number_of_kids");

                entity.Property(e => e.PackageName)
                    .HasMaxLength(50)
                    .HasColumnName("package_name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Package_Location");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Package__user_id__71D1E811");

                entity.HasMany(p => p.PackageDetails)
                .WithOne()
                .HasForeignKey(pd => pd.PackageId);
            });

            modelBuilder.Entity<PackageCategory>(entity =>
            {
                entity.ToTable("PackageCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.Description).HasColumnType("text");
            });

            modelBuilder.Entity<PackageDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PackageDetail");

                entity.Property(e => e.PackageId).HasColumnName("Package_Id");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                // Define a composite key for PackageDetail
                entity.HasKey(pd => new { pd.PackageId, pd.ServiceId });

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageDetails)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_PackageDetail_Package");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_PackageDetail_Service1");
            });

            modelBuilder.Entity<PackageImage>(entity =>
            {
                entity.ToTable("PackageImage");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .HasColumnName("Img_url");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageImages)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_PackageImage_Package");
            });

            modelBuilder.Entity<PackageTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PackageTag");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PackageId).HasColumnName("Package_Id");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_PackageTag_PackageCategory");

                entity.HasOne(d => d.Package)
                    .WithMany()
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_PackageTag_Package");
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

                entity.Property(e => e.ServiceCategoryId).HasColumnName("serviceCategory_Id");

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

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ServiceCategories)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_ServiceCategory_ServiceType");
            });

            modelBuilder.Entity<ServiceImage>(entity =>
            {
                entity.ToTable("ServiceImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImgUrl).HasColumnName("Img_url");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceImages)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_ServiceImage_Service");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.ToTable("ServiceType");

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61646663D104")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId, "idx_user_role");

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
