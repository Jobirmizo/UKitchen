using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityKitchen.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImgUrlIsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Meals",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Meals");
        }
    }
}
