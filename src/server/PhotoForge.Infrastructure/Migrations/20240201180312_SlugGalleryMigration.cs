using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SlugGalleryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug_Value",
                schema: "Galleries",
                table: "Gallery",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug_Value",
                schema: "Galleries",
                table: "Gallery");
        }
    }
}
