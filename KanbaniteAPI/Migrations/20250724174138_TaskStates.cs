using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbaniteAPI.Migrations
{
    /// <inheritdoc />
    public partial class TaskStates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "task_state_id",
                table: "tasks",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "tasks_states",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    project_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tasks_states", x => x.id);
                    table.ForeignKey(
                        name: "fk_tasks_states_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_task_state_id",
                table: "tasks",
                column: "task_state_id");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_states_project_id",
                table: "tasks_states",
                column: "project_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_tasks_states_task_state_id",
                table: "tasks",
                column: "task_state_id",
                principalTable: "tasks_states",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tasks_tasks_states_task_state_id",
                table: "tasks");

            migrationBuilder.DropTable(
                name: "tasks_states");

            migrationBuilder.DropIndex(
                name: "ix_tasks_task_state_id",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "task_state_id",
                table: "tasks");
        }
    }
}
