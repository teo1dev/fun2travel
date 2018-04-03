using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fun2travel.Models.Entities
{
    public partial class FunToTravelContext : DbContext
    {
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActToHot> ActToHot { get; set; }
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

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking", "f2t");

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
