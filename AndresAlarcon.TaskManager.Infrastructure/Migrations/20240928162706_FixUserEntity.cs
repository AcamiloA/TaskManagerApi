using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndresAlarcon.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_User_UserId",
                schema: "TaskManager",
                table: "Board");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_CreatedBy",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UpdatedBy",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_CreatedBy",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UpdatedBy",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "TaskManager",
                table: "Board",
                newName: "AssignedTo");

            migrationBuilder.RenameIndex(
                name: "IX_Board_UserId",
                schema: "TaskManager",
                table: "Board",
                newName: "IX_Board_AssignedTo");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                schema: "TaskManager",
                table: "User",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "TaskManager",
                table: "Board",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                schema: "TaskManager",
                table: "Board",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_User_AssignedTo",
                schema: "TaskManager",
                table: "Board",
                column: "AssignedTo",
                principalSchema: "TaskManager",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_User_AssignedTo",
                schema: "TaskManager",
                table: "Board");

            migrationBuilder.DropColumn(
                name: "Salt",
                schema: "TaskManager",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "AssignedTo",
                schema: "TaskManager",
                table: "Board",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Board_AssignedTo",
                schema: "TaskManager",
                table: "Board",
                newName: "IX_Board_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "TaskManager",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "TaskManager",
                table: "Role",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                schema: "TaskManager",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "TaskManager",
                table: "Role",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "TaskManager",
                table: "Board",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                schema: "TaskManager",
                table: "Board",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreatedBy",
                schema: "TaskManager",
                table: "Role",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UpdatedBy",
                schema: "TaskManager",
                table: "Role",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_User_UserId",
                schema: "TaskManager",
                table: "Board",
                column: "UserId",
                principalSchema: "TaskManager",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_CreatedBy",
                schema: "TaskManager",
                table: "Role",
                column: "CreatedBy",
                principalSchema: "TaskManager",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UpdatedBy",
                schema: "TaskManager",
                table: "Role",
                column: "UpdatedBy",
                principalSchema: "TaskManager",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
