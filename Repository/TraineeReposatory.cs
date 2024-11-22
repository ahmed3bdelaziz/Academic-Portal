using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Task7.Models;
using Task7.Repository;

namespace Task7.Models.Repository
{
	public class TraineeReposatory :ITraineeRepository
	{
		private readonly ApplicationDbContext _context;


		public TraineeReposatory(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Add(Trainee trainee)
		{
			_context.Add(trainee);
		}

		public void Update(Trainee trainee)
		{
			_context.Update(trainee);
		}

		public void Delete(int id)
		{
			Trainee trainee = GetByID(id);
			_context.Remove(trainee);
		}

		public List<Trainee> GetAll()
		{
			return _context.Trainees.ToList();
		}

		public Trainee? GetByID(int id)
		{
			return _context.Trainees.FirstOrDefault(t => t.Id == id);
		}

		// Add a method to include CourseResults and Courses
		public Trainee? GetByIDWithCourseResultsAndCourses(int id)
		{
			return _context.Trainees
				.Include(t => t.CourseResults)
				.ThenInclude(cr => cr.Course)
				.FirstOrDefault(t => t.Id == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
