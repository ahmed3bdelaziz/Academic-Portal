using System.Collections.Generic;
using Task7.Models;

namespace Task7.Repository
{
	public interface IInstructorRepository
	{
		IEnumerable<Instructor> GetAllInstructors();
		Instructor? GetInstructorById(int id);
		IEnumerable<Department> GetDepartments();
		void AddInstructor(Instructor instructor);
		void UpdateInstructor(Instructor instructor);
		void DeleteInstructor(Instructor instructor);
		void Save();
	}
}
