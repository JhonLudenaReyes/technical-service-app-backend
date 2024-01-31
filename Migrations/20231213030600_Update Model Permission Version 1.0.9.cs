using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelPermissionVersion109 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionspermissionId",
                table: "PermissionRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Roles_rolesRoleId",
                table: "PermissionRole");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Permissions",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "permissionName",
                table: "Permissions",
                newName: "PermissionName");

            migrationBuilder.RenameColumn(
                name: "permissionId",
                table: "Permissions",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "rolesRoleId",
                table: "PermissionRole",
                newName: "RolesRoleId");

            migrationBuilder.RenameColumn(
                name: "PermissionspermissionId",
                table: "PermissionRole",
                newName: "PermissionsPermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRole_rolesRoleId",
                table: "PermissionRole",
                newName: "IX_PermissionRole_RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionsPermissionId",
                table: "PermissionRole",
                column: "PermissionsPermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Roles_RolesRoleId",
                table: "PermissionRole",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionsPermissionId",
                table: "PermissionRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Roles_RolesRoleId",
                table: "PermissionRole");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Permissions",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "PermissionName",
                table: "Permissions",
                newName: "permissionName");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "Permissions",
                newName: "permissionId");

            migrationBuilder.RenameColumn(
                name: "RolesRoleId",
                table: "PermissionRole",
                newName: "rolesRoleId");

            migrationBuilder.RenameColumn(
                name: "PermissionsPermissionId",
                table: "PermissionRole",
                newName: "PermissionspermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRole_RolesRoleId",
                table: "PermissionRole",
                newName: "IX_PermissionRole_rolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionspermissionId",
                table: "PermissionRole",
                column: "PermissionspermissionId",
                principalTable: "Permissions",
                principalColumn: "permissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Roles_rolesRoleId",
                table: "PermissionRole",
                column: "rolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
