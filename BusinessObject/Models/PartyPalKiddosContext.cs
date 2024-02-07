﻿using System;
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
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Drink> Drinks { get; set; } = null!;
        public virtual DbSet<DrinkCategory> DrinkCategories { get; set; } = null!;
        public virtual DbSet<DrinkImage> DrinkImages { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<FoodCategory> FoodCategories { get; set; } = null!;
        public virtual DbSet<FoodImage> FoodImages { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<LocationImage> LocationImages { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDrink> OrderDrinks { get; set; } = null!;
        public virtual DbSet<OrderFood> OrderFoods { get; set; } = null!;
        public virtual DbSet<OrderService> OrderServices { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<PackageCategory> PackageCategories { get; set; } = null!;
        public virtual DbSet<PackageTag> PackageTags { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public virtual DbSet<ServiceImage> ServiceImages { get; set; } = null!;
        public virtual DbSet<ServiceOption> ServiceOptions { get; set; } = null!;
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

                entity.Property(e => e.CouponName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("coupon_name");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("discount_amount");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.ToTable("Drink");

                entity.HasIndex(e => e.DrinkCategoryId, "idx_drink_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DrinkCategoryId).HasColumnName("DrinkCategory_id");

                entity.Property(e => e.DrinkName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("drink_name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.DrinkCategory)
                    .WithMany(p => p.Drinks)
                    .HasForeignKey(d => d.DrinkCategoryId)
                    .HasConstraintName("FK__Drink__DrinkCate__5629CD9C");
            });

            modelBuilder.Entity<DrinkCategory>(entity =>
            {
                entity.ToTable("DrinkCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.Description).HasColumnType("text");
            });

            modelBuilder.Entity<DrinkImage>(entity =>
            {
                entity.ToTable("DrinkImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DrinkId).HasColumnName("drink_id");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .HasColumnName("Img_url");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.DrinkImages)
                    .HasForeignKey(d => d.DrinkId)
                    .HasConstraintName("FK_DrinkImg_Drink");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.HasIndex(e => e.FoodCategoryId, "idx_food_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FoodCategoryId).HasColumnName("FoodCategory_id");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("food_name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.FoodCategory)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.FoodCategoryId)
                    .HasConstraintName("FK__Food__FoodCatego__5165187F");
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("FoodCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.Description).HasColumnType("text");
            });

            modelBuilder.Entity<FoodImage>(entity =>
            {
                entity.ToTable("FoodImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FoodId).HasColumnName("food_Id");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .HasColumnName("img_url");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.FoodImages)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_FoodImg_Food");
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

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_Location_District");
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

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK__Orders__package___787EE5A0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__user_id__76969D2E");
            });

            modelBuilder.Entity<OrderDrink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderDrink");

                entity.HasIndex(e => e.DrinkId, "idx_order_drink");

                entity.Property(e => e.DrinkId).HasColumnName("Drink_Id");

                entity.Property(e => e.PackageId).HasColumnName("Package_id");

                entity.HasOne(d => d.Drink)
                    .WithMany()
                    .HasForeignKey(d => d.DrinkId)
                    .HasConstraintName("FK__OrderDrin__Drink__693CA210");

                entity.HasOne(d => d.Package)
                    .WithMany()
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_OrderDrink_Package");
            });

            modelBuilder.Entity<OrderFood>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderFood");

                entity.HasIndex(e => e.FoodId, "idx_order_food");

                entity.Property(e => e.FoodId).HasColumnName("Food_Id");

                entity.Property(e => e.PackageId).HasColumnName("Package_Id");

                entity.HasOne(d => d.Food)
                    .WithMany()
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__OrderFood__FoodI__66603565");

                entity.HasOne(d => d.Package)
                    .WithMany()
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_OrderFood_Package");
            });

            modelBuilder.Entity<OrderService>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderService");

                entity.HasIndex(e => e.ServiceId, "idx_order_service");

                entity.Property(e => e.PackageId).HasColumnName("Package_id");

                entity.Property(e => e.ServiceId).HasColumnName("Service_id");

                entity.Property(e => e.ServiceOptionId).HasColumnName("ServiceOption_Id");

                entity.HasOne(d => d.Package)
                    .WithMany()
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_OrderService_Package");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__OrderServ__Servi__6C190EBB");

                entity.HasOne(d => d.ServiceOption)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceOptionId)
                    .HasConstraintName("FK_OrderService_ServiceOption");
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

                entity.Property(e => e.NumberOfKid).HasColumnName("number_of_kid");

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

                entity.HasIndex(e => e.ServiceCategoryId, "idx_service_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceCategoryId).HasColumnName("ServiceCategory_id");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("service_name");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("FK__Service__Service__5AEE82B9");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.ToTable("ServiceCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.Description).HasColumnType("text");
            });

            modelBuilder.Entity<ServiceImage>(entity =>
            {
                entity.ToTable("ServiceImage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .HasColumnName("Img_url");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceImages)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_ServiceImg_Service");
            });

            modelBuilder.Entity<ServiceOption>(entity =>
            {
                entity.ToTable("ServiceOption");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.OptionName)
                    .HasMaxLength(100)
                    .HasColumnName("option_name");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceOptions)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_ServiceOption_Service");
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

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

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