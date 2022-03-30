using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstonFilRouge_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BillingPeriod = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndCommitmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClubList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Inside = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubList_AddressList_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndHour = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseList_ClubList_ClubId",
                        column: x => x.ClubId,
                        principalTable: "ClubList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpeningDayList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningHour = table.Column<int>(type: "int", nullable: false),
                    ClosingHour = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningDayList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningDayList_ClubList_ClubId",
                        column: x => x.ClubId,
                        principalTable: "ClubList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserList_AddressList_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserList_ClubList_ClubId",
                        column: x => x.ClubId,
                        principalTable: "ClubList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationList_CourseList_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubList_AddressId",
                table: "ClubList",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseList_ClubId",
                table: "CourseList",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningDayList_ClubId",
                table: "OpeningDayList",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationList_CourseId",
                table: "ReservationList",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserList_AddressId",
                table: "UserList",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserList_ClubId",
                table: "UserList",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthList");

            migrationBuilder.DropTable(
                name: "OpeningDayList");

            migrationBuilder.DropTable(
                name: "ReservationList");

            migrationBuilder.DropTable(
                name: "SubscriptionList");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.DropTable(
                name: "CourseList");

            migrationBuilder.DropTable(
                name: "ClubList");

            migrationBuilder.DropTable(
                name: "AddressList");
        }
    }
}
