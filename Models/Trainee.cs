using System.ComponentModel.DataAnnotations;

namespace Task7.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Trainee Name is required.")]
        [StringLength(100, ErrorMessage = "Trainee Name cannot exceed 100 characters.")]
        [Display(Name = "Trainee Name")]
        public string Name { get; set; }

        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string Img { get; set; }

        [StringLength(200, ErrorMessage = "Trainee Address cannot exceed 200 characters.")]
        [Display(Name = "Trainee Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Trainee Grade is required.")]
        [RegularExpression(@"^[A-F]$", ErrorMessage = "Grade must be a letter between A and F.")]
        [Display(Name = "Trainee Grade")]
        public string Grade { get; set; }

        public ICollection<CourseResult> CourseResults { get; set; } = new HashSet<CourseResult>();
    }
}
