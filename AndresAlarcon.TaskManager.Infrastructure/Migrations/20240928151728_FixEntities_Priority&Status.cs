using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndresAlarcon.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixEntities_PriorityStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_Priority_PriorityId",
                schema: "TaskManager",
                table: "Board");

            migrationBuilder.DropForeignKey(
                name: "FK_Board_Status_StatusId",
                schema: "TaskManager",
                table: "Board");

            migrationBuilder.DropTable(
                name: "Priority",
                schema: "TaskManager");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "TaskManager");

            migrationBuilder.DropIndex(
                name: "IX_Board_PriorityId",
                schema: "TaskManager",
                table: "Board");

            migrationBuilder.DropIndex(
                name: "IX_Board_StatusId",
                schema: "TaskManager",
                table: "Board");

            migrationBuilder.AlterColumn<string>(
                name: "StatusId",
                schema: "TaskManager",
                table: "Board",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PriorityId",
                schema: "TaskManager",
                table: "Board",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                schema: "TaskManager",
                table: "Board",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                schema: "TaskManager",
                table: "Board",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.CreateTable(
                name: "Priority",
                schema: "TaskManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Priority_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "TaskManager",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Priority_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "TaskManager",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "TaskManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "TaskManager",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Status_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "TaskManager",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Board_PriorityId",
                schema: "TaskManager",
                table: "Board",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_StatusId",
                schema: "TaskManager",
                table: "Board",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Priority_CreatedBy",
                schema: "TaskManager",
                table: "Priority",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Priority_UpdatedBy",
                schema: "TaskManager",
                table: "Priority",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Status_CreatedBy",
                schema: "TaskManager",
                table: "Status",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Status_UpdatedBy",
                schema: "TaskManager",
                table: "Status",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_Priority_PriorityId",
                schema: "TaskManager",
                table: "Board",
                column: "PriorityId",
                principalSchema: "TaskManager",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Board_Status_StatusId",
                schema: "TaskManager",
                table: "Board",
                column: "StatusId",
                principalSchema: "TaskManager",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
