using System;

using eder_web_api.modules.auth.enums;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eder_web_api.Migrations
{
    /// <inheritdoc />
    public partial class added_role_table_and_added_default_role_records : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    normalized_name = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => x.id);
                });
            migrationBuilder.CreateIndex(
name: "ux_user_roles_role_type_normalized_name",
table: "user_roles",
columns: new[] { "role_type", "normalized_name" },
unique: true);

            migrationBuilder.Sql($"""
        INSERT INTO user_roles (id, name, normalized_name, role_type)
        VALUES
          ('{Guid.NewGuid()}', '{RoleName.ADMIN}',        UPPER('{RoleName.ADMIN}'),        {(int)RoleType.PLATFORM}),
          ('{Guid.NewGuid()}', '{RoleName.CHAIR_PERSON}', UPPER('{RoleName.CHAIR_PERSON}'), {(int)RoleType.TENANT}),
          ('{Guid.NewGuid()}', '{RoleName.SECRETARY}',    UPPER('{RoleName.SECRETARY}'),    {(int)RoleType.TENANT}),
          ('{Guid.NewGuid()}', '{RoleName.TREASURER}',    UPPER('{RoleName.TREASURER}'),    {(int)RoleType.TENANT}),
          ('{Guid.NewGuid()}', '{RoleName.USER}',         UPPER('{RoleName.USER}'),         {(int)RoleType.TENANT})
        ON CONFLICT (role_type, normalized_name) DO NOTHING;
        """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_roles");
        }
    }
}
