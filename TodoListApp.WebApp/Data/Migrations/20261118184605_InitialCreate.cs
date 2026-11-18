using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable CA1861 // Prefer static readonly fields over constant array arguments
#pragma warning disable SA1118 // Parameter must not span multiple lines
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers

namespace TodoListApp.WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AssigneeId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TodoListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoTasks_TodoLists_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TodoTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_TodoTasks_TodoTaskId",
                        column: x => x.TodoTaskId,
                        principalTable: "TodoTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoTaskTags",
                columns: table => new
                {
                    TodoTaskId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTaskTags", x => new { x.TodoTaskId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TodoTaskTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoTaskTags_TodoTasks_TodoTaskId",
                        column: x => x.TodoTaskId,
                        principalTable: "TodoTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "urgent" },
                    { 2, "home" },
                    { 3, "study" }
                });

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, "Everyday personal tasks and reminders.", "seed-user-1", "Personal errands" },
                    { 2, "Tasks related to current work assignments.", "seed-user-1", "Work projects" },
                    { 3, "Study plan for ASP.NET Core and Entity Framework.", "seed-user-2", "Learning goals" }
                });

            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "Id", "AssigneeId", "CreatedDate", "Description", "DueDate", "Status", "Title", "TodoListId" },
                values: new object[,]
                {
                    { 1, "seed-user-1", new DateTime(2026, 11, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Milk, bread, eggs, and vegetables.", new DateTime(2026, 11, 2, 18, 0, 0, 0, DateTimeKind.Utc), "NotStarted", "Buy groceries", 1 },
                    { 2, "seed-user-1", new DateTime(2026, 11, 3, 10, 0, 0, 0, DateTimeKind.Utc), "Summarize sprint progress for the weekly meeting.", new DateTime(2026, 11, 5, 17, 0, 0, 0, DateTimeKind.Utc), "InProgress", "Prepare status report", 2 },
                    { 3, "seed-user-2", new DateTime(2026, 11, 4, 8, 30, 0, 0, DateTimeKind.Utc), "Finish migrations, seeding, and DbContext configuration.", new DateTime(2026, 11, 10, 23, 59, 0, 0, DateTimeKind.Utc), "Completed", "Complete EF Core module", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Text", "TodoTaskId" },
                values: new object[,]
                {
                    { 1, "seed-user-1", new DateTime(2026, 11, 1, 10, 15, 0, 0, DateTimeKind.Utc), "Do not forget oat milk.", 1 },
                    { 2, "seed-user-1", new DateTime(2026, 11, 3, 11, 0, 0, 0, DateTimeKind.Utc), "Include charts for completed stories.", 2 },
                    { 3, "seed-user-2", new DateTime(2026, 11, 4, 12, 45, 0, 0, DateTimeKind.Utc), "Migration applied successfully on LocalDB.", 3 }
                });

            migrationBuilder.InsertData(
                table: "TodoTaskTags",
                columns: new[] { "TagId", "TodoTaskId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TodoTaskId",
                table: "Comments",
                column: "TodoTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_TodoListId",
                table: "TodoTasks",
                column: "TodoListId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoTaskTags_TagId",
                table: "TodoTaskTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TodoTaskTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TodoTasks");

            migrationBuilder.DropTable(
                name: "TodoLists");
        }
    }
}
