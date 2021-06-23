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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CourseCode", "CourseTitle", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "49705ea3-a395-4b85-9efc-a59d69cf443a", "STY1001", "Software Engineering Concepts", "merc312@gmail.com", "Chamila", "Gunasena" },
                    { "f0cbae92-d7c3-4d75-ab8c-f230b0756d8e", "STY1001", "Software Engineering Concepts", "pardeep27malhi@gmail.com", "Pardeep", "Malhi" },
                    { "47295cc2-ef91-443a-b3df-8559426802e4", "STY1001", "Software Engineering Concepts", "ntwalicris@yahoo.fr", "Crispain", "Ntwali" },
                    { "d0bf5e4b-4a3e-48ad-a47b-4cf98a14927d", "STY1001", "Software Engineering Concepts", "praveenshashika@yahoo.com", "Praveen", "Perera" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
