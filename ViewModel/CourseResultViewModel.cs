using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task7.Models;

namespace Task7.ViewModel
{
    public class CourseResultViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Degree is required.")]
        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100.")]
        [Display(Name = "Degree")]
        public decimal Degree { get; set; }

        [Required(ErrorMessage = "Course is required.")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Display(Name = "Courses")]
        public List<Course> Courses { get; set; } = new List<Course>();

        [Required(ErrorMessage = "Trainee is required.")]
        [Display(Name = "Trainee")]
        public int TraineeId { get; set; }

        [Display(Name = "Trainees")]
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
    }
}
