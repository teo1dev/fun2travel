using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fun2travel.Models.Entities
{
    public partial class FunToTravelContext : DbContext
    {
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActToHot> ActToHot { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("fun2travel");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity", "f2t");

                entity.Property(e => e.ActivityDescription).IsRequired();

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ActivityPic1)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ActivityPic2)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ActivityPrice).HasColumnType("money");

                entity.Property(e => e.ActivityRentalPrice).HasColumnType("money");
            });

            modelBuilder.Entity<ActToHot>(entity =>
            {
                entity.ToTable("ActToHot", "f2t");

                entity.HasOne(d => d.ActivityFkNavigation)
                    .WithMany(p => p.ActToHot)
                    .HasForeignKey(d => d.ActivityFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityToTable");

                entity.HasOne(d => d.HotelFkNavigation)
                    .WithMany(p => p.ActToHot)
                    .HasForeignKey(d => d.HotelFk)
                    .HasConstraintName("FK_HotelToTable");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking", "f2t");

                entity.Property(e => e.ActivityName).HasMaxLength(50);

                entity.Property(e => e.BookingEmail).IsRequired();

                entity.Property(e => e.BookingId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.BookingPhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalCostActivity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalCostHotel).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalCostRenting).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalCostTransport).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel", "f2t");

                entity.Property(e => e.BedPricePerNight).HasColumnType("money");

                entity.Property(e => e.HotelAdress).IsRequired();

                entity.Property(e => e.HotelDescription).IsRequired();

                entity.Property(e => e.HotelLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HotelPic1).IsRequired();

                entity.Property(e => e.HotelPic2).IsRequired();

                entity.Property(e => e.HotelPic3).IsRequired();

                entity.Property(e => e.PriceForTransport).HasColumnType("money");
            });
        }
    }
}
