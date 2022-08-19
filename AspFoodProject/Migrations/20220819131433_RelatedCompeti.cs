using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFoodProject.Migrations
{
    public partial class RelatedCompeti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Customers_CustomerId",
                table: "Competitions");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_CustomerId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Competitions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CustomerId",
                table: "Competitions",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Customers_CustomerId",
                table: "Competitions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
