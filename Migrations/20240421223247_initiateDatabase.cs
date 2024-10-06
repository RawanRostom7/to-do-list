using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuftbornCodeTest.Migrations
{
    /// <inheritdoc />
    public partial class initiateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoListTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDoListTasks",
                columns: new[] { "Id", "CreationDate", "Deadline", "Discription", "ModificationDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 22, 0, 32, 46, 772, DateTimeKind.Local).AddTicks(599), new DateOnly(2024, 4, 24), "Finish this ASP.NET Core migration", null, 0, null },
                    { 2, new DateTime(2024, 4, 22, 0, 32, 46, 772, DateTimeKind.Local).AddTicks(651), new DateOnly(2024, 4, 23), "Groceries shopping", null, 1, null },
                    { 3, new DateTime(2024, 4, 22, 0, 32, 46, 772, DateTimeKind.Local).AddTicks(656), new DateOnly(2024, 4, 22), "Review code for pull request", null, 0, null },
                    { 4, new DateTime(2024, 4, 22, 0, 32, 46, 772, DateTimeKind.Local).AddTicks(659), new DateOnly(2024, 4, 25), "Team meeting", null, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoListTasks");
        }
    }
}
