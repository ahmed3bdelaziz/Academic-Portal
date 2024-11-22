using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task7.Models;

namespace Task7.Repository
{
	public class CourseResultRepository: ICourseResultRepository
	{
		private readonly ApplicationDbContext _context;

		public CourseResultRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public List<CourseResult> GetAll()
		{
			return _context.CourseResults
				.Include(cr => cr.Course)
				.Include(cr => cr.Trainee)
				.ToList();
		}

		public CourseResult? GetById(int id)
		{
			return _context.CourseResults
				.Include(cr => cr.Course)
				.Include(cr => cr.Trainee)
				.FirstOrDefault(cr => cr.Id == id);
		}

		public void Add(CourseResult courseResult)
		{
			_context.CourseResults.Add(courseResult);
		}

		public void Update(CourseResult courseResult)
		{
			_context.CourseResults.Update(courseResult);
		}

		public void Delete(int id)
		{
			var courseResult = GetById(id);
			if (courseResult != null)
			{
				_context.CourseResults.Remove(courseResult);
			}
		}

		public List<Course> GetCourses()
		{
			return _context.Courses.ToList();
		}

		public List<Trainee> GetTrainees()
		{
			return _context.Trainees.ToList();
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
