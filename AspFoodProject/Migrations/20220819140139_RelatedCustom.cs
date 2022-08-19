using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFoodProject.Migrations
{
    public partial class RelatedCustom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterName",
                table: "Registerations");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Registerations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Recipes",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailID",
                table: "Recipes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipes",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Registerations_CustomerId",
                table: "Registerations",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registerations_Customers_CustomerId",
                table: "Registerations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registerations_Customers_CustomerId",
                table: "Registerations");

            migrationBuilder.DropIndex(
                name: "IX_Registerations_CustomerId",
                table: "Registerations");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Registerations");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "EmailID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "RegisterName",
                table: "Registerations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
