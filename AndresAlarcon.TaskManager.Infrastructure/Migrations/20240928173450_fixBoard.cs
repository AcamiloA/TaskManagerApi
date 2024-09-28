using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndresAlarcon.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                schema: "TaskManager",
                table: "Board",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                schema: "TaskManager",
                table: "Board",
                newName: "Priority");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "TaskManager",
                table: "Board",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Priority",
                schema: "TaskManager",
                table: "Board",
                newName: "PriorityId");
        }
    }
}
