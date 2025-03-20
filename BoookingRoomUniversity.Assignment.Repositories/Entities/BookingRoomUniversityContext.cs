using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class BookingRoomUniversityContext : DbContext
{
    public BookingRoomUniversityContext()
    {
    }

    public BookingRoomUniversityContext(DbContextOptions<BookingRoomUniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Campus> Campuses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACD17669CB8");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__RoomID__534D60F1");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__UserID__52593CB8");
        });

        modelBuilder.Entity<Campus>(entity =>
        {
            entity.HasKey(e => e.CampusId).HasName("PK__Campuses__FD598D36101FC0DF");

            entity.Property(e => e.CampusId).HasColumnName("CampusID");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDAB907C23");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.CampusId).HasColumnName("CampusID");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

            entity.HasOne(d => d.Campus).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Departmen__Campu__3B75D760");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A17442326");

            entity.HasIndex(e => e.Name, "UQ__Roles__737584F67DEF8EC5").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__3286391989D4C959");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.CampusId).HasColumnName("CampusID");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

            entity.HasOne(d => d.Campus).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.CampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rooms__CampusID__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC5DBC782B");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534AE5A62F5").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__Departmen__48CFD27E");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleID__49C3F6B7");

            entity.HasMany(d => d.Rooms).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoom",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Room__RoomI__4D94879B"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Room__UserI__4CA06362"),
                    j =>
                    {
                        j.HasKey("UserId", "RoomId").HasName("PK__User_Roo__94A0AF3DF90868CB");
                        j.ToTable("User_Rooms");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("RoomId").HasColumnName("RoomID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
