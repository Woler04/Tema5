using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billiard.Data.Migrations
{
    public partial class dbcontextupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BilliardTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Spaces = table.Column<int>(type: "int", nullable: false),
                    isForSmokers = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilliardTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationList_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReserverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BilliardTableId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BilliardTableId1 = table.Column<int>(type: "int", nullable: true),
                    ReservationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_AspNetUsers_ReserverId",
                        column: x => x.ReserverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_BilliardTable_BilliardTableId1",
                        column: x => x.BilliardTableId1,
                        principalTable: "BilliardTable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_ReservationList_ReservationListId",
                        column: x => x.ReservationListId,
                        principalTable: "ReservationList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BilliardTableId1",
                table: "Reservation",
                column: "BilliardTableId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservationListId",
                table: "Reservation",
                column: "ReservationListId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReserverId",
                table: "Reservation",
                column: "ReserverId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationList_UserId1",
                table: "ReservationList",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "BilliardTable");

            migrationBuilder.DropTable(
                name: "ReservationList");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");
        }
    }
}
