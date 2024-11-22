using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task7;
using Task7.Models;
using Task7.Repository;

public class InstructorRepository :IInstructorRepository
{
	private readonly ApplicationDbContext _context;

	public InstructorRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public IEnumerable<Instructor> GetAllInstructors()
	{
		return _context.Instructors.Include(i => i.Department).ToList();
	}

	public Instructor? GetInstructorById(int id)
	{
		return _context.Instructors
					   .Include(i => i.Department)
					   .Include(i => i.Courses)
					   .FirstOrDefault(i => i.Id == id);
	}

	public IEnumerable<Department> GetDepartments()
	{
		return _context.Departments.ToList();
	}

	public void AddInstructor(Instructor instructor)
	{
		_context.Instructors.Add(instructor);
	}

	public void UpdateInstructor(Instructor instructor)
	{
		_context.Instructors.Update(instructor);
	}

	public void DeleteInstructor(Instructor instructor)
	{
		_context.Instructors.Remove(instructor);
	}

	public void Save()
	{
		_context.SaveChanges();
	}
}
