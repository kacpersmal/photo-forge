using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseGalleryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Galleries");

            migrationBuilder.CreateTable(
                name: "Gallery",
                schema: "Galleries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AccessCode_Hash = table.Column<byte[]>(type: "bytea", nullable: true),
                    AccessCode_Salt = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryResource",
                schema: "Galleries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GalleryId = table.Column<Guid>(type: "uuid", nullable: false),
                    PrimaryResource_Name = table.Column<string>(type: "text", nullable: false),
                    PrimaryResource_DisplayName = table.Column<string>(type: "text", nullable: false),
                    PrimaryResource_Location = table.Column<string>(type: "text", nullable: false),
                    ThumbnailResource_Name = table.Column<string>(type: "text", nullable: true),
                    ThumbnailResource_DisplayName = table.Column<string>(type: "text", nullable: true),
                    ThumbnailResource_Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryResource_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalSchema: "Galleries",
                        principalTable: "Gallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalleryUser",
                columns: table => new
                {
                    GalleryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersWithAccessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryUser", x => new { x.GalleryId, x.UsersWithAccessId });
                    table.ForeignKey(
                        name: "FK_GalleryUser_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalSchema: "Galleries",
                        principalTable: "Gallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryUser_User_UsersWithAccessId",
                        column: x => x.UsersWithAccessId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryResource_GalleryId",
                schema: "Galleries",
                table: "GalleryResource",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryUser_UsersWithAccessId",
                table: "GalleryUser",
                column: "UsersWithAccessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryResource",
                schema: "Galleries");

            migrationBuilder.DropTable(
                name: "GalleryUser");

            migrationBuilder.DropTable(
                name: "Gallery",
                schema: "Galleries");
        }
    }
}
