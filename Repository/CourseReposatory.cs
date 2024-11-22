using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task7.Models;

namespace Task7.Repository
{
	public class CourseRepository : ICourseRepository
	{
		private readonly ApplicationDbContext _context;

		public CourseRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<Course> GetAll()
		{
			return _context.Courses.Include(c => c.Instructor).ToList();
		}

		public Course? GetById(int id)
		{
			return _context.Courses.Include(c => c.Instructor).FirstOrDefault(c => c.Id == id);
		}

		public void Add(Course course)
		{
			_context.Courses.Add(course);
		}

		public void Update(Course course)
		{
			_context.Courses.Update(course);
		}

		public void Delete(int id)
		{
			var course = _context.Courses.Find(id);
			if (course != null)
			{
				_context.Courses.Remove(course);
			}
		}

		public List<Instructor> GetInstructors()
		{
			return _context.Instructors.ToList();
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
