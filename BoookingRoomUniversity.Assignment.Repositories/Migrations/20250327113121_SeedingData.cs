using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoookingRoomUniversity.Assignment.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campuses",
                columns: table => new
                {
                    CampusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => x.CampusId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CampusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "CampusId");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => new { x.BookingId, x.RoomId });

                    table.ForeignKey(
                    name: "FK_BookingDetail_Bookings_BookingId",
                    column: x => x.BookingId,
                    principalTable: "Bookings",
                    principalColumn: "BookingId",
                    onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                    name: "FK_BookingDetail_Rooms_RoomId",
                    column: x => x.RoomId,
                    principalTable: "Rooms",
                    principalColumn: "RoomId",
                    onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "CampusId", "CreatedTime", "DeleteTime", "Location", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9283), null, "Khu Công Nghệ Cao, Quận 9, TP.HCM", "FPT University Hồ Chí Minh", null },
                    { 2, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9299), null, "Hòa Lạc, Thạch Thất, Hà Nội", "FPT University Hà Nội", null },
                    { 3, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9301), null, "Quận Ninh Kiều, TP. Cần Thơ", "FPT University Cần Thơ", null },
                    { 4, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9302), null, "Ngũ Hành Sơn, TP. Đà Nẵng", "FPT University Đà Nẵng", null },
                    { 5, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9303), null, "Khu Đô thị Khoa học Quy Hòa, TP. Quy Nhơn", "FPT University Quy Nhơn", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "CampusId", "CreatedTime", "DeleteTime", "Description", "Name", "Status", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9416), null, "Software Development Department", "Software Engineering", 1, null },
                    { 2, 2, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9418), null, "Business & Marketing Department", "Business Administration", 1, null },
                    { 3, 3, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9420), null, "AI Research Department", "Artificial Intelligence", 1, null },
                    { 4, 4, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9422), null, "Cyber Security Department", "Cyber Security", 1, null },
                    { 5, 5, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9423), null, "Data Analytics Department", "Data Science", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "CampusId", "Capacity", "CreatedTime", "DeleteTime", "Description", "Name", "Status", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 1, 50, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9471), null, "Lecture Hall", "Room A101", 0, null },
                    { 2, 2, 30, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9475), null, "Computer Lab", "Room B202", 0, null },
                    { 3, 3, 40, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9476), null, "Seminar Room", "Room C303", 1, null },
                    { 4, 4, 20, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9478), null, "Meeting Room", "Room D404", 1, null },
                    { 5, 5, 60, new DateTime(2025, 3, 27, 18, 31, 21, 171, DateTimeKind.Local).AddTicks(9480), null, "Conference Hall", "Room E505", 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CampusId",
                table: "Departments",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CampusId",
                table: "Rooms",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomUser_UsersUserId",
                table: "RoomUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "RoomUser");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Campuses");
        }
    }
}
