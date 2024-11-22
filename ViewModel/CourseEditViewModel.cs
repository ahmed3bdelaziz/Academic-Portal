using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task7.Models;

public class CourseEditViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Course Name is required.")]
    [StringLength(100, ErrorMessage = "Course Name cannot exceed 100 characters.")]
    [Display(Name = "Course Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Maximum Degree is required.")]
    [Range(0, 100, ErrorMessage = "Maximum Degree must be between 0 and 100.")]
    [Display(Name = "Maximum Degree")]
    public int MaximumDegree { get; set; }

    [Required(ErrorMessage = "Minimum Degree is required.")]
    [Range(0, 100, ErrorMessage = "Minimum Degree must be between 0 and 100.")]
    [Display(Name = "Minimum Degree")]
    public int MinimumDegree { get; set; }

    [Required(ErrorMessage = "Instructor is required.")]
    [Display(Name = "Instructor")]
    public int InstructorId { get; set; }

    [Display(Name = "Instructors")]
    public List<Instructor> Instructors { get; set; } = new List<Instructor>();




}
