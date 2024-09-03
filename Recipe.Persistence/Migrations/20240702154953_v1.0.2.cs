using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Migrations
{
    /// <inheritdoc />
    public partial class v102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VisibleId",
                table: "Recipes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "VisibleId",
                table: "Ingredients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "VisibleId",
                table: "DailyMealRecipes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "VisibleId",
                table: "DailyMealLists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "VisibleId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "VisibleId",
                table: "Categories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "VisibleId",
                table: "Books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_VisibleId",
                table: "Recipes",
                column: "VisibleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_VisibleId",
                table: "Ingredients",
                column: "VisibleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyMealRecipes_VisibleId",
                table: "DailyMealRecipes",
                column: "VisibleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyMealLists_VisibleId",
                table: "DailyMealLists",
                column: "VisibleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VisibleId",
                table: "Comments",
                column: "VisibleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_VisibleId",
                table: "Categories",
                column: "VisibleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_VisibleId",
                table: "Books",
                column: "VisibleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipes_VisibleId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_VisibleId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_DailyMealRecipes_VisibleId",
                table: "DailyMealRecipes");

            migrationBuilder.DropIndex(
                name: "IX_DailyMealLists_VisibleId",
                table: "DailyMealLists");

            migrationBuilder.DropIndex(
                name: "IX_Comments_VisibleId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Categories_VisibleId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_VisibleId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "VisibleId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "VisibleId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "VisibleId",
                table: "DailyMealRecipes");

            migrationBuilder.DropColumn(
                name: "VisibleId",
                table: "DailyMealLists");

            migrationBuilder.DropColumn(
                name: "VisibleId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "VisibleId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "VisibleId",
                table: "Books");
        }
    }
}
