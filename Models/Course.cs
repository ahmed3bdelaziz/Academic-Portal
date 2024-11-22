using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task7.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required.")]
        [StringLength(100, ErrorMessage = "Course Name cannot exceed 100 characters.")]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Maximum Degree is required.")]
        [Range(0, 100, ErrorMessage = "Maximum Degree must be between 0 and 100.")]
        public int MaximumDegree { get; set; }

        [Required(ErrorMessage = "Minimum Degree is required.")]
        [Range(0, 100, ErrorMessage = "Minimum Degree must be between 0 and 100.")]
        public int MinimumDegree { get; set; }

      
        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }

        public ICollection<CourseResult> CourseResults { get; set; } = new HashSet<CourseResult>();
    }
 

}
