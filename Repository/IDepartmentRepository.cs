using System.Collections.Generic;
using Task7.Models;

namespace Task7.Repository
{
	public interface IDepartmentRepository
	{
		List<Department> GetAll();
		Department? GetById(int id);
		void Add(Department department);
		void Update(Department department);
		void Delete(int id);
		void Save();
	}
}
