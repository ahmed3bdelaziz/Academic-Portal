using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task7.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(100, ErrorMessage = "Department Name cannot exceed 100 characters.")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manager Name is required.")]
        [StringLength(100, ErrorMessage = "Manager Name cannot exceed 100 characters.")]
        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }

        [Display(Name = "Instructors")]
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
    }
}
