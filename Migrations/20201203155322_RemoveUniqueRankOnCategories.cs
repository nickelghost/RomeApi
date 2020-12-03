using Microsoft.EntityFrameworkCore.Migrations;

namespace RomeApi.Migrations
{
    public partial class RemoveUniqueRankOnCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_categories_rank",
                table: "categories");

            migrationBuilder.CreateIndex(
                name: "ix_categories_rank",
                table: "categories",
                column: "rank");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_categories_rank",
                table: "categories");

            migrationBuilder.CreateIndex(
                name: "ix_categories_rank",
                table: "categories",
                column: "rank",
                unique: true);
        }
    }
}
