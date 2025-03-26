using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities
{
    public class BookingRoomUniversityDbContext : DbContext
    {
        public BookingRoomUniversityDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Lưu Enum dưới dạng int
            modelBuilder.Entity<Room>()
                .Property(r => r.Status)
                .HasConversion<int>();

            modelBuilder.Entity<Booking>()
                .Property(b => b.Status)
                .HasConversion<int>();
            modelBuilder.Entity<Department>()
                .Property(d => d.Status)
                .HasConversion<int>();

            modelBuilder.Entity<User>()
        .HasOne(u => u.Department)
        .WithMany()
        .HasForeignKey(u => u.DepartmentId)
        .OnDelete(DeleteBehavior.Restrict); // Không xóa User khi xóa Department

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Ngăn chặn cascade delete vòng lặp

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade); // Nếu xóa Room thì xóa Booking


            modelBuilder.Entity<Campus>().HasData(
        new Campus { CampusId = 1, Name = "FPT University Hồ Chí Minh", Location = "Khu Công Nghệ Cao, Quận 9, TP.HCM", CreatedTime = DateTime.Now },
        new Campus { CampusId = 2, Name = "FPT University Hà Nội", Location = "Hòa Lạc, Thạch Thất, Hà Nội", CreatedTime = DateTime.Now },
        new Campus { CampusId = 3, Name = "FPT University Cần Thơ", Location = "Quận Ninh Kiều, TP. Cần Thơ", CreatedTime = DateTime.Now },
        new Campus { CampusId = 4, Name = "FPT University Đà Nẵng", Location = "Ngũ Hành Sơn, TP. Đà Nẵng", CreatedTime = DateTime.Now },
        new Campus { CampusId = 5, Name = "FPT University Quy Nhơn", Location = "Khu Đô thị Khoa học Quy Hòa, TP. Quy Nhơn", CreatedTime = DateTime.Now }
          );



        }


    }
}
