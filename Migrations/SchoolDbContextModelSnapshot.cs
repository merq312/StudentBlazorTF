// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerBlazorEF.Models;

namespace BlazorStudent.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServerBlazorEF.Models.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = "49705ea3-a395-4b85-9efc-a59d69cf443a",
                            CourseCode = "STY1001",
                            CourseTitle = "Software Engineering Concepts",
                            Email = "merc312@gmail.com",
                            FirstName = "Chamila",
                            LastName = "Gunasena"
                        },
                        new
                        {
                            StudentId = "f0cbae92-d7c3-4d75-ab8c-f230b0756d8e",
                            CourseCode = "STY1001",
                            CourseTitle = "Software Engineering Concepts",
                            Email = "pardeep27malhi@gmail.com",
                            FirstName = "Pardeep",
                            LastName = "Malhi"
                        },
                        new
                        {
                            StudentId = "47295cc2-ef91-443a-b3df-8559426802e4",
                            CourseCode = "STY1001",
                            CourseTitle = "Software Engineering Concepts",
                            Email = "ntwalicris@yahoo.fr",
                            FirstName = "Crispain",
                            LastName = "Ntwali"
                        },
                        new
                        {
                            StudentId = "d0bf5e4b-4a3e-48ad-a47b-4cf98a14927d",
                            CourseCode = "STY1001",
                            CourseTitle = "Software Engineering Concepts",
                            Email = "praveenshashika@yahoo.com",
                            FirstName = "Praveen",
                            LastName = "Perera"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
