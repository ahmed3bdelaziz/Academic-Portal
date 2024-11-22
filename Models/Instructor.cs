﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task7.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Instructor Name is required.")]
        [StringLength(100, ErrorMessage = "Instructor Name cannot exceed 100 characters.")]
        [Display(Name = "Instructor Name")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]

        [Display(Name = "Profile Image")]
        public string Img { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than zero.")]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Courses")]
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
