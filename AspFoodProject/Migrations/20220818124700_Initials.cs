using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFoodProject.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(maxLength: 100, nullable: false),
                    EventAddress = table.Column<string>(maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 120, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDateTime1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hours1 = table.Column<string>(nullable: true),
                    Phase = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Competitions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CustomerId",
                table: "Competitions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EventAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDateTime1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hours1 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CustomerId",
                table: "Events",
                column: "CustomerId");
        }
    }
}
