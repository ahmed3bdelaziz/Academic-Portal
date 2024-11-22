using System.Collections.Generic;
using Task7.Models;

namespace Task7.Repository
{
	public interface ITraineeRepository
	{
		List<Trainee> GetAll();
		Trainee? GetByID(int id);
		Trainee? GetByIDWithCourseResultsAndCourses(int id);
		void Add(Trainee trainee);
		void Update(Trainee trainee);
		void Delete(int id);
		void Save();
	}
}
