using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFoodProject.Migrations
{
    public partial class RelatedRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registerations",
                columns: table => new
                {
                    RegisterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterName = table.Column<string>(maxLength: 100, nullable: false),
                    RegisterAddress = table.Column<string>(maxLength: 100, nullable: false),
                    RegisterNo = table.Column<string>(nullable: false),
                    RegisterEmailID = table.Column<string>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registerations", x => x.RegisterId);
                    table.ForeignKey(
                        name: "FK_Registerations_Competitions_EventId",
                        column: x => x.EventId,
                        principalTable: "Competitions",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registerations_EventId",
                table: "Registerations",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registerations");
        }
    }
}
