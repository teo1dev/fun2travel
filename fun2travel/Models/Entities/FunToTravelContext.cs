using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fun2travel.Models.Entities
{
    public partial class FunToTravelContext : DbContext
    {
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActToHot> ActToHot { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=fun2travel.database.windows.net;Initial Catalog=fun2travel;Integrated Security=False;User ID=jerryteodor;Password=P@ssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityDescription).IsRequired();

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ActivityPrice).HasColumnType("money");

                entity.Property(e => e.ActivityRentalPrice).HasColumnType("money");
            });

            modelBuilder.Entity<ActToHot>(entity =>
            {
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

            modelBuilder.Entity<Hotel>(entity =>
            {
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
