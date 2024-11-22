using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task7.Models;
using Task7.Models.Repository;
using Task7.Repository;

namespace Task7.Controllers
{
	public class TraineesController : Controller
	{
		private readonly ITraineeRepository TraineeReposatory;

		public TraineesController(ITraineeRepository traineeRepository)
		{
			TraineeReposatory = traineeRepository;
		}

		public IActionResult Index()
		{
			var traineesList = TraineeReposatory.GetAll();
			return View(traineesList);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var trainee = TraineeReposatory.GetByIDWithCourseResultsAndCourses((int)id); // Updated method

			if (trainee == null)
			{
				return NotFound();
			}

			return View(trainee);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SaveAdd(Trainee newTrainee)
		{
			if (ModelState.IsValid)
			{
				TraineeReposatory.Add(newTrainee);
				TraineeReposatory.Save(); // Save the changes
				return RedirectToAction("Index");
			}

			// If model state is invalid, redisplay the form with errors
			return View("Add", newTrainee);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var trainee = TraineeReposatory.GetByID(id);
			if (trainee == null)
			{
				return NotFound();
			}
			return View(trainee);
		}

		[HttpPost]
		public IActionResult SaveEdit(int id, Trainee traineeToBeEdited)
		{
			if (id != traineeToBeEdited.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					TraineeReposatory.Update(traineeToBeEdited);
					TraineeReposatory.Save(); // Save changes
					return RedirectToAction("Index");
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TraineeReposatory.GetAll().Any(t => t.Id == id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}

			// If model state is invalid, redisplay the form with errors
			return View("Edit", traineeToBeEdited);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var traineeToDelete = TraineeReposatory.GetByID(id);
			if (traineeToDelete == null)
			{
				return NotFound();
			}
			return View(traineeToDelete);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var traineeToDelete = TraineeReposatory.GetByID(id);
			if (traineeToDelete != null)
			{
				TraineeReposatory.Delete(id);
				TraineeReposatory.Save(); // Save changes
			}

			return RedirectToAction("Index");
		}
	}
}
