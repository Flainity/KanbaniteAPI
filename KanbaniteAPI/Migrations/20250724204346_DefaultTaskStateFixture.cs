using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbaniteAPI.Migrations
{
    /// <inheritdoc />
    public partial class DefaultTaskStateFixture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tasks_states",
                columns: new[] { "id", "name", "project_id" },
                values: new object[] { new Guid("5565ef4f-0b8f-4f0b-88f4-c5211f367543"), "Open", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tasks_states",
                keyColumn: "id",
                keyValue: new Guid("5565ef4f-0b8f-4f0b-88f4-c5211f367543"));
        }
    }
}
