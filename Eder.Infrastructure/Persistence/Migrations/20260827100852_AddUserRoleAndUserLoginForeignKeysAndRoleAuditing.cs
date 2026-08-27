using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eder.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoleAndUserLoginForeignKeysAndRoleAuditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "user_roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "user_roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "user_roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_user_login_id",
                table: "users",
                column: "user_login_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_role_id",
                table: "users",
                column: "user_role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_logins_user_login_id",
                table: "users",
                column: "user_login_id",
                principalTable: "user_logins",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_roles_user_role_id",
                table: "users",
                column: "user_role_id",
                principalTable: "user_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_user_logins_user_login_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_user_roles_user_role_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_user_login_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_user_role_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "user_roles");
        }
    }
}
