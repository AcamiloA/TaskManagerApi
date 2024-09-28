using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndresAlarcon.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTraceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trace",
                schema: "TaskManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    LastState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastAssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trace_Board_BoardId",
                        column: x => x.BoardId,
                        principalSchema: "TaskManager",
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trace_User_CurrentAssignedTo",
                        column: x => x.CurrentAssignedTo,
                        principalSchema: "TaskManager",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trace_User_LastAssignedTo",
                        column: x => x.LastAssignedTo,
                        principalSchema: "TaskManager",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trace_BoardId",
                schema: "TaskManager",
                table: "Trace",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Trace_CurrentAssignedTo",
                schema: "TaskManager",
                table: "Trace",
                column: "CurrentAssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Trace_LastAssignedTo",
                schema: "TaskManager",
                table: "Trace",
                column: "LastAssignedTo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trace",
                schema: "TaskManager");
        }
    }
}
