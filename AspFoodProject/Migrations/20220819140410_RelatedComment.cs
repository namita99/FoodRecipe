using Microsoft.EntityFrameworkCore.Migrations;

namespace AspFoodProject.Migrations
{
    public partial class RelatedComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "query",
                table: "Comments",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "query",
                table: "Comments");
        }
    }
}
