using Microsoft.EntityFrameworkCore;
using Task7.Models;

namespace Task7
{
    public class ApplicationDbContext : DbContext
    {
		public ApplicationDbContext():base()
		{
		}

		public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Department>()
                .HasMany(d => d.Instructors)
                .WithOne(i => i.Department)
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseResults)
                .WithOne(cr => cr.Course)
                .HasForeignKey(cr => cr.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Trainee>()
                .HasMany(t => t.CourseResults)
                .WithOne(cr => cr.Trainee)
                .HasForeignKey(cr => cr.TraineeId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<CourseResult>()
                .HasKey(cr => cr.Id);

            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CourseResults)
                .HasForeignKey(cr => cr.CourseId);

            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Trainee)
                .WithMany(t => t.CourseResults)
                .HasForeignKey(cr => cr.TraineeId);


            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science", ManagerName = "Dr. Smith" },
                new Department { Id = 2, Name = "Mathematics", ManagerName = "Dr. Johnson" },
                new Department { Id = 3, Name = "Physics", ManagerName = "Dr. Williams" },
                new Department { Id = 4, Name = "Chemistry", ManagerName = "Dr. Davis" },
                new Department { Id = 5, Name = "Biology", ManagerName = "Dr. Miller" }
            );

            // Seed Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "John Doe", Address = "123 Main St", Img = "https://placehold.co/200x200/000000/FFFFFF", Salary = 50000, DepartmentId = 1 },
                new Instructor { Id = 2, Name = "Jane Roe", Address = "456 Elm St", Img = "https://placehold.co/200x200/FF0000/FFFFFF", Salary = 55000, DepartmentId = 2 },
                new Instructor { Id = 3, Name = "Michael Brown", Address = "789 Oak St", Img = "https://placehold.co/200x200/00FF00/FFFFFF", Salary = 60000, DepartmentId = 3 },
                new Instructor { Id = 4, Name = "Emily White", Address = "101 Pine St", Img = "https://placehold.co/200x200/0000FF/FFFFFF", Salary = 65000, DepartmentId = 4 },
                new Instructor { Id = 5, Name = "Nancy Green", Address = "202 Oak St", Img = "https://placehold.co/200x200/FFFF00/000000", Salary = 70000, DepartmentId = 1 },
                new Instructor { Id = 6, Name = "Linda Gray", Address = "303 Maple St", Img = "https://placehold.co/200x200/800080/FFFFFF", Salary = 72000, DepartmentId = 5 }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Introduction to Programming", MaximumDegree = 100, MinimumDegree = 60, InstructorId = 1 },
                new Course { Id = 2, Name = "Advanced Mathematics", MaximumDegree = 100, MinimumDegree = 70, InstructorId = 2 },
                new Course { Id = 3, Name = "Quantum Mechanics", MaximumDegree = 100, MinimumDegree = 80, InstructorId = 3 },
                new Course { Id = 4, Name = "Organic Chemistry", MaximumDegree = 100, MinimumDegree = 65, InstructorId = 4 },
                new Course { Id = 5, Name = "Data Structures", MaximumDegree = 100, MinimumDegree = 55, InstructorId = 1 },
                new Course { Id = 6, Name = "Linear Algebra", MaximumDegree = 100, MinimumDegree = 60, InstructorId = 2 },
                new Course { Id = 7, Name = "Machine Learning", MaximumDegree = 100, MinimumDegree = 75, InstructorId = 5 },
                new Course { Id = 8, Name = "Genetics", MaximumDegree = 100, MinimumDegree = 70, InstructorId = 6 },
                new Course { Id = 9, Name = "Database Systems", MaximumDegree = 100, MinimumDegree = 65, InstructorId = 1 },
                new Course { Id = 10, Name = "Statistical Analysis", MaximumDegree = 100, MinimumDegree = 60, InstructorId = 2 }
            );

            // Seed Trainees
            modelBuilder.Entity<Trainee>().HasData(
                new Trainee { Id = 1, Name = "Alice Brown", Img = "https://placehold.co/200x200/FFA500/FFFFFF", Address = "789 Oak St", Grade = "A" },
                new Trainee { Id = 2, Name = "Bob Green", Img = "https://placehold.co/200x200/808080/000000", Address = "101 Pine St", Grade = "B" },
                new Trainee { Id = 3, Name = "Charlie Black", Img = "https://placehold.co/200x200/000000/FFFFFF", Address = "202 Maple St", Grade = "A" },
                new Trainee { Id = 4, Name = "Diana White", Img = "https://placehold.co/200x200/FF0000/FFFFFF", Address = "303 Birch St", Grade = "C" },
                new Trainee { Id = 5, Name = "Eva Blue", Img = "https://placehold.co/200x200/00FF00/FFFFFF", Address = "404 Cedar St", Grade = "B" },
                new Trainee { Id = 6, Name = "Frank Gray", Img = "https://placehold.co/200x200/0000FF/FFFFFF", Address = "505 Willow St", Grade = "A" },
                new Trainee { Id = 7, Name = "Grace Adams", Img = "https://placehold.co/200x200/FFFF00/000000", Address = "606 Ash St", Grade = "B" },
                new Trainee { Id = 8, Name = "Henry Hill", Img = "https://placehold.co/200x200/800080/FFFFFF", Address = "707 Cedar St", Grade = "A" }
            );

            // Seed CourseResults
            modelBuilder.Entity<CourseResult>().HasData(
                new CourseResult { Id = 1, Degree = 95, CourseId = 1, TraineeId = 1 },
                new CourseResult { Id = 2, Degree = 85, CourseId = 2, TraineeId = 2 },
                new CourseResult { Id = 3, Degree = 78, CourseId = 3, TraineeId = 3 },
                new CourseResult { Id = 4, Degree = 92, CourseId = 4, TraineeId = 4 },
                new CourseResult { Id = 5, Degree = 88, CourseId = 5, TraineeId = 5 },
                new CourseResult { Id = 6, Degree = 80, CourseId = 6, TraineeId = 1 },
                new CourseResult { Id = 7, Degree = 90, CourseId = 7, TraineeId = 2 },
                new CourseResult { Id = 8, Degree = 77, CourseId = 8, TraineeId = 3 },
                new CourseResult { Id = 9, Degree = 85, CourseId = 9, TraineeId = 4 },
                new CourseResult { Id = 10, Degree = 91, CourseId = 10, TraineeId = 5 },
                new CourseResult { Id = 11, Degree = 82, CourseId = 1, TraineeId = 6 },
                new CourseResult { Id = 12, Degree = 70, CourseId = 2, TraineeId = 7 },
                new CourseResult { Id = 13, Degree = 88, CourseId = 3, TraineeId = 8 },
                new CourseResult { Id = 14, Degree = 65, CourseId = 4, TraineeId = 6 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
