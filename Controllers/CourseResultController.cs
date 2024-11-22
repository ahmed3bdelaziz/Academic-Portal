using Microsoft.AspNetCore.Mvc;
using Task7.Models;
using Task7.Repository;
using Task7.ViewModel;

namespace Task7.Controllers
{
	public class CourseResultController : Controller
	{
		private readonly ICourseResultRepository _repository;

		public CourseResultController(ICourseResultRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var courseResults = _repository.GetAll();
			return View(courseResults);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var courseResult = _repository.GetById(id.Value);
			if (courseResult == null)
			{
				return NotFound();
			}

			return View(courseResult);
		}

		[HttpGet]
		public IActionResult Add()
		{
			var viewModel = new CourseResultViewModel
			{
				Courses = _repository.GetCourses(),
				Trainees = _repository.GetTrainees()
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult SaveAdd(CourseResultViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.Courses = _repository.GetCourses();
				viewModel.Trainees = _repository.GetTrainees();
				return View("Add", viewModel);
			}

			var courseResult = new CourseResult
			{
				Degree = viewModel.Degree,
				CourseId = viewModel.CourseId,
				TraineeId = viewModel.TraineeId
			};

			_repository.Add(courseResult);
			_repository.Save();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var courseResult = _repository.GetById(id);
			if (courseResult == null)
			{
				return NotFound();
			}

			var viewModel = new CourseResultViewModel
			{
				Id = courseResult.Id,
				Degree = courseResult.Degree,
				CourseId = courseResult.CourseId,
				TraineeId = courseResult.TraineeId,
				Courses = _repository.GetCourses(),
				Trainees = _repository.GetTrainees()
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult SaveEdit(CourseResultViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.Courses = _repository.GetCourses();
				viewModel.Trainees = _repository.GetTrainees();
				return View("Edit", viewModel);
			}

			var existingCourseResult = _repository.GetById(viewModel.Id);
			if (existingCourseResult == null)
			{
				return NotFound();
			}

			existingCourseResult.Degree = viewModel.Degree;
			existingCourseResult.CourseId = viewModel.CourseId;
			existingCourseResult.TraineeId = viewModel.TraineeId;

			_repository.Update(existingCourseResult);
			_repository.Save();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var courseResult = _repository.GetById(id);
			if (courseResult == null)
			{
				return NotFound();
			}

			return View(courseResult);
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
