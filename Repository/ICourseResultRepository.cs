using System.Collections.Generic;
using Task7.Models;

namespace Task7.Repository
{
	public interface ICourseResultRepository
	{
		List<CourseResult> GetAll();
		CourseResult? GetById(int id);
		void Add(CourseResult courseResult);
		void Update(CourseResult courseResult);
		void Delete(int id);
		List<Course> GetCourses();
		List<Trainee> GetTrainees();
		void Save();
	}
}
