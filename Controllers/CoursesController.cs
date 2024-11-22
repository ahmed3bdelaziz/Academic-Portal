using Microsoft.AspNetCore.Mvc;
using Task7.Models;
using Task7.Repository;
using Task7.ViewModel;

namespace Task7.Controllers
{
	public class CoursesController : Controller
	{
		private readonly ICourseRepository _repository;

		public CoursesController(ICourseRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var coursesList = _repository.GetAll();
			return View(coursesList);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var course = _repository.GetById(id.Value);
			if (course == null)
			{
				return NotFound();
			}

			return View(course);
		}

		[HttpGet]
		public IActionResult Add()
		{
			var instructors = _repository.GetInstructors();
			var model = new CourseEditViewModel
			{
				Instructors = instructors
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult SaveAdd(CourseEditViewModel model)
		{
			if (!ModelState.IsValid)
			{
				// Repopulate instructors in case of validation failure
				model.Instructors = _repository.GetInstructors();
				return View("Add", model);
			}

			var course = new Course
			{
				Name = model.Name,
				MaximumDegree = model.MaximumDegree,
				MinimumDegree = model.MinimumDegree,
				InstructorId = model.InstructorId
			};

			_repository.Add(course);
			_repository.Save();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var course = _repository.GetById(id);
			if (course == null)
			{
				return NotFound();
			}

			var viewModel = new CourseEditViewModel
			{
				Id = course.Id,
				Name = course.Name,
				MaximumDegree = course.MaximumDegree,
				MinimumDegree = course.MinimumDegree,
				InstructorId = course.InstructorId,
				Instructors = _repository.GetInstructors()
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult SaveEdit(CourseEditViewModel model)
		{
			if (ModelState.IsValid)
			{
				var existingCourse = _repository.GetById(model.Id);
				if (existingCourse == null)
				{
					return NotFound();
				}

				existingCourse.Name = model.Name;
				existingCourse.MaximumDegree = model.MaximumDegree;
				existingCourse.MinimumDegree = model.MinimumDegree;
				existingCourse.InstructorId = model.InstructorId;

				_repository.Update(existingCourse);
				_repository.Save();

				return RedirectToAction("Index");
			}

			// If model state is invalid, repopulate the view model and return the view
			model.Instructors = _repository.GetInstructors();
			return View("Edit", model);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var courseToDelete = _repository.GetById(id);
			if (courseToDelete == null)
			{
				return NotFound();
			}
			return View(courseToDelete);
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
