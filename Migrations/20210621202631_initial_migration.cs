using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStudent.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "School" },
                values: new object[,]
                {
                    { "a2c32b70-eb38-47bc-a6a7-26baf5f92b87", "Jane", "Smith", "Medicine" },
                    { "00e5158b-2336-44d0-91e6-bfb75f4125ba", "John", "Fisher", "Engineering" },
                    { "43d6c157-74d5-44b0-bee7-9b048a05611f", "Pamela", "Baker", "Food Science" },
                    { "5217559f-6371-44f4-915e-dec16bb0a748", "Peter", "Taylor", "Mining" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
