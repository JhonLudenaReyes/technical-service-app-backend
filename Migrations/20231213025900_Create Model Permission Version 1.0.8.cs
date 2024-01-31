using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalService.Migrations
{
    /// <inheritdoc />
    public partial class CreateModelPermissionVersion108 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    permissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    state = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.permissionId);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    PermissionspermissionId = table.Column<int>(type: "int", nullable: false),
                    rolesRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionspermissionId, x.rolesRoleId });
                    table.ForeignKey(
                        name: "FK_PermissionRole_Permissions_PermissionspermissionId",
                        column: x => x.PermissionspermissionId,
                        principalTable: "Permissions",
                        principalColumn: "permissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_Roles_rolesRoleId",
                        column: x => x.rolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_rolesRoleId",
                table: "PermissionRole",
                column: "rolesRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
