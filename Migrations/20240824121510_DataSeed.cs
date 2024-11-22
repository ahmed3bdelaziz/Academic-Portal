using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task7.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "Dr. Smith", "Computer Science" },
                    { 2, "Dr. Johnson", "Mathematics" },
                    { 3, "Dr. Williams", "Physics" },
                    { 4, "Dr. Davis", "Chemistry" },
                    { 5, "Dr. Miller", "Biology" }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "Address", "Grade", "Img", "Name" },
                values: new object[,]
                {
                    { 1, "789 Oak St", "A", "https://placehold.co/200x200/FFA500/FFFFFF", "Alice Brown" },
                    { 2, "101 Pine St", "B", "https://placehold.co/200x200/808080/000000", "Bob Green" },
                    { 3, "202 Maple St", "A", "https://placehold.co/200x200/000000/FFFFFF", "Charlie Black" },
                    { 4, "303 Birch St", "C", "https://placehold.co/200x200/FF0000/FFFFFF", "Diana White" },
                    { 5, "404 Cedar St", "B", "https://placehold.co/200x200/00FF00/FFFFFF", "Eva Blue" },
                    { 6, "505 Willow St", "A", "https://placehold.co/200x200/0000FF/FFFFFF", "Frank Gray" },
                    { 7, "606 Ash St", "B", "https://placehold.co/200x200/FFFF00/000000", "Grace Adams" },
                    { 8, "707 Cedar St", "A", "https://placehold.co/200x200/800080/FFFFFF", "Henry Hill" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "DepartmentId", "Img", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "123 Main St", 1, "https://placehold.co/200x200/000000/FFFFFF", "John Doe", 50000m },
                    { 2, "456 Elm St", 2, "https://placehold.co/200x200/FF0000/FFFFFF", "Jane Roe", 55000m },
                    { 3, "789 Oak St", 3, "https://placehold.co/200x200/00FF00/FFFFFF", "Michael Brown", 60000m },
                    { 4, "101 Pine St", 4, "https://placehold.co/200x200/0000FF/FFFFFF", "Emily White", 65000m },
                    { 5, "202 Oak St", 1, "https://placehold.co/200x200/FFFF00/000000", "Nancy Green", 70000m },
                    { 6, "303 Maple St", 5, "https://placehold.co/200x200/800080/FFFFFF", "Linda Gray", 72000m }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "InstructorId", "MaximumDegree", "MinimumDegree", "Name" },
                values: new object[,]
                {
                    { 1, 1, 100, 60, "Introduction to Programming" },
                    { 2, 2, 100, 70, "Advanced Mathematics" },
                    { 3, 3, 100, 80, "Quantum Mechanics" },
                    { 4, 4, 100, 65, "Organic Chemistry" },
                    { 5, 1, 100, 55, "Data Structures" },
                    { 6, 2, 100, 60, "Linear Algebra" },
                    { 7, 5, 100, 75, "Machine Learning" },
                    { 8, 6, 100, 70, "Genetics" },
                    { 9, 1, 100, 65, "Database Systems" },
                    { 10, 2, 100, 60, "Statistical Analysis" }
                });

            migrationBuilder.InsertData(
                table: "CourseResults",
                columns: new[] { "Id", "CourseId", "Degree", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1, 95m, 1 },
                    { 2, 2, 85m, 2 },
                    { 3, 3, 78m, 3 },
                    { 4, 4, 92m, 4 },
                    { 5, 5, 88m, 5 },
                    { 6, 6, 80m, 1 },
                    { 7, 7, 90m, 2 },
                    { 8, 8, 77m, 3 },
                    { 9, 9, 85m, 4 },
                    { 10, 10, 91m, 5 },
                    { 11, 1, 82m, 6 },
                    { 12, 2, 70m, 7 },
                    { 13, 3, 88m, 8 },
                    { 14, 4, 65m, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CourseResults",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
