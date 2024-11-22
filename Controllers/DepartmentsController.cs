using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task7.Models;
using Task7.Repository;

namespace Task7.Controllers
{
	public class DepartmentsController : Controller
	{
		private readonly IDepartmentRepository _repository;

		public DepartmentsController(IDepartmentRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var departmentsList = _repository.GetAll();
			return View(departmentsList);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var department = _repository.GetById(id.Value);

			if (department == null)
			{
				return NotFound();
			}

			return View(department);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SaveAdd(Department newDepartment)
		{
			if (ModelState.IsValid)
			{
				_repository.Add(newDepartment);
				_repository.Save();
				return RedirectToAction("Index");
			}

			// If model state is invalid, return to the same view with the current data
			return View("Add", newDepartment);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var department = _repository.GetById(id);
			if (department == null)
			{
				return NotFound();
			}
			return View(department);
		}

		[HttpPost]
		public IActionResult SaveEdit(int id, Department departmentToBeEdited)
		{
			if (id != departmentToBeEdited.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_repository.Update(departmentToBeEdited);
					_repository.Save();
					return RedirectToAction("Index");
				}
				catch (DbUpdateConcurrencyException)
				{
					if (_repository.GetById(id) == null)
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}

			// If model state is invalid, return to the same view with the current data
			return View("Edit", departmentToBeEdited);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var department = _repository.GetById(id);
			if (department == null)
			{
				return NotFound();
			}
			return View(department);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			_repository.Delete(id);
			_repository.Save();
			return RedirectToAction("Index");
		}
	}
}
