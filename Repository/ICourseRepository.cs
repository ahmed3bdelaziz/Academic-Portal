using System.Collections.Generic;
using Task7.Models;

namespace Task7.Repository
{
	public interface ICourseRepository
	{
		List<Course> GetAll();
		Course? GetById(int id);
		void Add(Course course);
		void Update(Course course);
		void Delete(int id);
		List<Instructor> GetInstructors();
		void Save();
	}
}
