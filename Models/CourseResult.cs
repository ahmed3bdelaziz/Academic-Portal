using System.ComponentModel.DataAnnotations;

namespace Task7.Models
{
    public class CourseResult
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Degree is required.")]
        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100.")]
        [Display(Name = "Degree")]
        public decimal Degree { get; set; }

        [Required(ErrorMessage = "Course is required.")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Required(ErrorMessage = "Trainee is required.")]
        [Display(Name = "Trainee")]
        public int TraineeId { get; set; }

        public Trainee Trainee { get; set; }
    }
}
