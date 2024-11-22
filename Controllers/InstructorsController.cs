using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Task7.Models;
using Task7.Models.Repository;
using Task7.Repository;
using Task7.ViewModel;

namespace Task7.Controllers
{
	public class InstructorsController : Controller
	{
		private readonly IInstructorRepository _instructorRepo;

		public InstructorsController(IInstructorRepository instructorRepo)
		{
			_instructorRepo = instructorRepo;
		}

		public IActionResult Index()
		{
			var instructorsList = _instructorRepo.GetAllInstructors().ToList();
			return View(instructorsList);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var instructor = _instructorRepo.GetInstructorById(id.Value);
			if (instructor == null)
			{
				return NotFound();
			}

			return View(instructor);
		}

		[HttpGet]
		public IActionResult Add()
		{
			var departments = _instructorRepo.GetDepartments().ToList(); // Convert IEnumerable to List

			var viewModel = new InstructorWithDept
			{
				DepartmentList = departments
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult SaveAdd(InstructorWithDept model)
		{
			if (!ModelState.IsValid)
			{
				// Re-populate departments in case of validation failure
				model.DepartmentList = _instructorRepo.GetDepartments().ToList(); // Convert IEnumerable to List
				return View("Add", model);
			}

			var newInstructor = new Instructor
			{
				Name = model.Name,
				Address = model.Address,
				Img = model.Img,
				Salary = model.Salary,
				DepartmentId = model.DepartmentId
			};

			_instructorRepo.AddInstructor(newInstructor);
			_instructorRepo.Save();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var instructor = _instructorRepo.GetInstructorById(id);
			if (instructor == null)
			{
				return NotFound();
			}

			var departmentList = _instructorRepo.GetDepartments().ToList(); // Convert IEnumerable to List

			var instWithDept = new InstructorWithDept
			{
				Id = instructor.Id,
				Name = instructor.Name,
				Img = instructor.Img,
				Salary = instructor.Salary,
				Address = instructor.Address,
				DepartmentId = instructor.DepartmentId,
				DepartmentList = departmentList
			};

			return View(instWithDept);
		}

		[HttpPost]
		public IActionResult SaveEdit(InstructorWithDept instructorFromRequest)
		{
			if (ModelState.IsValid)
			{
				var instructorFromDB = _instructorRepo.GetInstructorById(instructorFromRequest.Id);
				if (instructorFromDB == null)
				{
					return NotFound();
				}

				instructorFromDB.Name = instructorFromRequest.Name;
				instructorFromDB.Address = instructorFromRequest.Address;
				instructorFromDB.DepartmentId = instructorFromRequest.DepartmentId;
				instructorFromDB.Salary = instructorFromRequest.Salary;
				instructorFromDB.Img = instructorFromRequest.Img;

				_instructorRepo.UpdateInstructor(instructorFromDB);
				_instructorRepo.Save();
				return RedirectToAction("Index");
			}

			instructorFromRequest.DepartmentList = _instructorRepo.GetDepartments().ToList(); // Convert IEnumerable to List
			return View("Edit", instructorFromRequest);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var instructorToDelete = _instructorRepo.GetInstructorById(id);
			if (instructorToDelete == null)
			{
				return NotFound();
			}

			return View(instructorToDelete);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var instructorToDelete = _instructorRepo.GetInstructorById(id);
			if (instructorToDelete != null)
			{
				_instructorRepo.DeleteInstructor(instructorToDelete);
				_instructorRepo.Save();
			}

			return RedirectToAction("Index");
		}
	}
}
