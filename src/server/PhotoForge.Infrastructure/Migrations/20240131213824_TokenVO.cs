using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TokenVO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                schema: "Auth",
                table: "UserSession",
                newName: "Token_Value");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                schema: "Auth",
                table: "UserSession",
                newName: "RefreshToken_Value");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_ExpirationDate",
                schema: "Auth",
                table: "UserSession",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Token_ExpirationDate",
                schema: "Auth",
                table: "UserSession",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken_ExpirationDate",
                schema: "Auth",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "Token_ExpirationDate",
                schema: "Auth",
                table: "UserSession");

            migrationBuilder.RenameColumn(
                name: "Token_Value",
                schema: "Auth",
                table: "UserSession",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "RefreshToken_Value",
                schema: "Auth",
                table: "UserSession",
                newName: "RefreshToken");
        }
    }
}
