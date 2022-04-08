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
                    Num = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressList", x => x.Id);
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
                    Inside = table.Column<int>(type: "int", nullable: true)
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
                name: "OpeningDayList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingHour = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserList_AddressList_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserList_ClubList_ClubId",
                        column: x => x.ClubId,
                        principalTable: "ClubList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_CourseList_UserList_CoachId",
                        column: x => x.CoachId,
                        principalTable: "UserList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EndCommitmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionList_ClubList_ClubId",
                        column: x => x.ClubId,
                        principalTable: "ClubList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionList_UserList_ClientId",
                        column: x => x.ClientId,
                        principalTable: "UserList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_ReservationList_UserList_ClientId",
                        column: x => x.ClientId,
                        principalTable: "UserList",
                        principalColumn: "Id");
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
                name: "IX_CourseList_CoachId",
                table: "CourseList",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningDayList_ClubId",
                table: "OpeningDayList",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationList_ClientId",
                table: "ReservationList",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationList_CourseId",
                table: "ReservationList",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionList_ClientId",
                table: "SubscriptionList",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionList_ClubId",
                table: "SubscriptionList",
                column: "ClubId");

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
                name: "OpeningDayList");

            migrationBuilder.DropTable(
                name: "ReservationList");

            migrationBuilder.DropTable(
                name: "SubscriptionList");

            migrationBuilder.DropTable(
                name: "CourseList");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.DropTable(
                name: "ClubList");

            migrationBuilder.DropTable(
                name: "AddressList");
        }
    }
}
