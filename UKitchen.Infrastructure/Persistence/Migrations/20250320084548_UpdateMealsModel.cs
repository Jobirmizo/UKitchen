using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityKitchen.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Meals_MealsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MealsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MealsId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MealId",
                table: "Orders",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Meals_MealId",
                table: "Orders",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Meals_MealId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MealId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "MealsId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MealsId",
                table: "Orders",
                column: "MealsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Meals_MealsId",
                table: "Orders",
                column: "MealsId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
