using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoookingRoomUniversity.Assignment.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BookingCancel",
                columns: table => new
                {
                    BookingCancelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDetailId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeleteTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCancel", x => x.BookingCancelId);
                    table.ForeignKey(
                        name: "FK_BookingCancel_BookingDetails_BookingDetailId",
                        column: x => x.BookingDetailId,
                        principalTable: "BookingDetails",
                        principalColumn: "BookingDetailId");
                    table.ForeignKey(
                        name: "FK_BookingCancel_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "FK_BookingCancel_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3759), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3791), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3794), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3796), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3971), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3976), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3977), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3979), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(3981), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(4003), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(4006), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(4008), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(4010), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 14, 17, 54, 561, DateTimeKind.Unspecified).AddTicks(4012), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Users_CampusId",
                table: "Users",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCancel_BookingDetailId",
                table: "BookingCancel",
                column: "BookingDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCancel_BookingId",
                table: "BookingCancel",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCancel_UserId",
                table: "BookingCancel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Campuses_CampusId",
                table: "Users",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "CampusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Campuses_CampusId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BookingCancel");

            migrationBuilder.DropIndex(
                name: "IX_Users_CampusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6092), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6121), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6123), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6125), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Campuses",
                keyColumn: "CampusId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6127), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6234), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6237), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6239), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6241), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6266), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6269), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6271), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2025, 4, 1, 13, 37, 44, 936, DateTimeKind.Unspecified).AddTicks(6313), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
