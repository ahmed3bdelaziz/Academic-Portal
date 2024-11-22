using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task7.Models;

namespace Task7.Repository
{
	public class DepartmentRepository :IDepartmentRepository	
	{
		private readonly ApplicationDbContext _context;


		public DepartmentRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public List<Department> GetAll()
		{
			return _context.Departments.Include(d => d.Instructors).ToList();
		}

		public Department? GetById(int id)
		{
			return _context.Departments
				.Include(d => d.Instructors)
				.FirstOrDefault(d => d.Id == id);
		}

		public void Add(Department department)
		{
			_context.Departments.Add(department);
		}

		public void Update(Department department)
		{
			_context.Departments.Update(department);
		}

		public void Delete(int id)
		{
			var department = _context.Departments.Find(id);
			if (department != null)
			{
				_context.Departments.Remove(department);
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
