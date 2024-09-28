using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndresAlarcon.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TaskManager");

            migrationBuilder.CreateTable(
                name: "Board",
                schema: "TaskManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                schema: "TaskManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "TaskManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "TaskManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "varchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(250)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "TaskManager",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "TaskManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_Board_CreatedBy",
                schema: "TaskManager",
                table: "Board",
                column: "CreatedBy");

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
                name: "IX_Board_UpdatedBy",
                schema: "TaskManager",
                table: "Board",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Board_UserId",
                schema: "TaskManager",
                table: "Board",
                column: "UserId");

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
                name: "IX_Role_CreatedBy",
                schema: "TaskManager",
                table: "Role",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UpdatedBy",
                schema: "TaskManager",
                table: "Role",
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

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "TaskManager",
                table: "User",
                column: "RoleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Board_User_CreatedBy",
                schema: "TaskManager",
                table: "Board",
                column: "CreatedBy",
                principalSchema: "TaskManager",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Board_User_UpdatedBy",
                schema: "TaskManager",
                table: "Board",
                column: "UpdatedBy",
                principalSchema: "TaskManager",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Priority_User_CreatedBy",
                schema: "TaskManager",
                table: "Priority",
                column: "CreatedBy",
                principalSchema: "TaskManager",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Priority_User_UpdatedBy",
                schema: "TaskManager",
                table: "Priority",
                column: "UpdatedBy",
                principalSchema: "TaskManager",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_CreatedBy",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UpdatedBy",
                schema: "TaskManager",
                table: "Role");

            migrationBuilder.DropTable(
                name: "Board",
                schema: "TaskManager");

            migrationBuilder.DropTable(
                name: "Priority",
                schema: "TaskManager");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "TaskManager");

            migrationBuilder.DropTable(
                name: "User",
                schema: "TaskManager");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "TaskManager");
        }
    }
}
