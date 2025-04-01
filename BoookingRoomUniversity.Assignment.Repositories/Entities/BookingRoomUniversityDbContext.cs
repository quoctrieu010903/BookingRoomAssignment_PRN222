using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoookingRoomUniversity.Assignment.Repositories.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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
        public DbSet<BookingDetail> BookingDetails { get; set; }

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

            modelBuilder.Entity<BookingDetail>()
           .HasKey(bd => bd.BookingDetailId);

            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.Booking)
                .WithMany(b => b.BookingDetails)
                .HasForeignKey(bd => bd.BookingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.Room)
                .WithMany(r => r.BookingDetails)
                .HasForeignKey(bd => bd.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RoomDetail>()
            .HasKey(rd => rd.RoomDetailId);

            modelBuilder.Entity<RoomDetail>()
                .HasOne(rd => rd.Room)
                .WithMany(r => r.RoomDetails)
                .HasForeignKey(rd => rd.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RoomDetail>()
                .HasOne(rd => rd.Slot)
                .WithMany(s => s.RoomDetails)
                .HasForeignKey(rd => rd.SlotId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookingCancel>()
    .HasOne(bc => bc.BookingDetail)
    .WithMany(bd => bd.BookingCancels)
    .HasForeignKey(bc => bc.BookingDetailId)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookingCancel>()
                .HasOne(bc => bc.Booking)
                .WithMany(b => b.BookingCancels)
                .HasForeignKey(bc => bc.BookingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookingCancel>()
                .HasOne(bc => bc.User)
                .WithMany(u => u.BookingCancels)
                .HasForeignKey(bc => bc.UserId)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Campus>().HasData(
        new Campus { CampusId = 1, Name = "FPT University Hồ Chí Minh", Location = "Khu Công Nghệ Cao, Quận 9, TP.HCM", CreatedTime = DateTime.Now },
        new Campus { CampusId = 2, Name = "FPT University Hà Nội", Location = "Hòa Lạc, Thạch Thất, Hà Nội", CreatedTime = DateTime.Now },
        new Campus { CampusId = 3, Name = "FPT University Cần Thơ", Location = "Quận Ninh Kiều, TP. Cần Thơ", CreatedTime = DateTime.Now },
        new Campus { CampusId = 4, Name = "FPT University Đà Nẵng", Location = "Ngũ Hành Sơn, TP. Đà Nẵng", CreatedTime = DateTime.Now },
        new Campus { CampusId = 5, Name = "FPT University Quy Nhơn", Location = "Khu Đô thị Khoa học Quy Hòa, TP. Quy Nhơn", CreatedTime = DateTime.Now }
          );
            modelBuilder.Entity<Department>().HasData(
       new Department { DepartmentId = 1, Name = "Software Engineering", Description = "Software Development Department", CreatedTime = DateTime.Now, CampusId = 1 },
       new Department { DepartmentId = 2, Name = "Business Administration", Description = "Business & Marketing Department",  CreatedTime = DateTime.Now, CampusId = 2 },
       new Department { DepartmentId = 3, Name = "Artificial Intelligence", Description = "AI Research Department", CreatedTime = DateTime.Now, CampusId = 3 },
       new Department { DepartmentId = 4, Name = "Cyber Security", Description = "Cyber Security Department", CreatedTime = DateTime.Now, CampusId = 4 },
       new Department { DepartmentId = 5, Name = "Data Science", Description = "Data Analytics Department", CreatedTime = DateTime.Now, CampusId = 5 }
        );
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomId = 1, Name = "Room A101", Capacity = 50, Status = RoomStatus.Active, CreatedTime = DateTime.Now, CampusId = 1 },
                new Room { RoomId = 2, Name = "Room B202", Capacity = 30, Status = RoomStatus.Unavailable, CreatedTime = DateTime.Now, CampusId = 2 },
                new Room { RoomId = 3, Name = "Room C303", Capacity = 40, Status = RoomStatus.Active, CreatedTime = DateTime.Now, CampusId = 3 },
                new Room { RoomId = 4, Name = "Room D404", Capacity = 20, Status = RoomStatus.Active, CreatedTime = DateTime.Now, CampusId = 4 },
                new Room { RoomId = 5, Name = "Room E505", Capacity = 60, Status = RoomStatus.Active, CreatedTime = DateTime.Now, CampusId = 5 }
            );



            
           }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BookingRoomUniversityDbContext>
        {
            public BookingRoomUniversityDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<BookingRoomUniversityDbContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                    b => b.MigrationsAssembly("BoookingRoomUniversity.Assignment.Repositories"));

                return new BookingRoomUniversityDbContext(optionsBuilder.Options);
            }
        }



    }
}
