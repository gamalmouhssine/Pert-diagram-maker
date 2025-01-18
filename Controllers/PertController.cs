using Microsoft.AspNetCore.Mvc;
using PertChartGenerator.Models;
using PertChartGenerator.Services;

namespace PertChartGenerator.Controllers
{
    public class PertController : Controller
    {
        private readonly PertCalculator _pertCalculator;

        public PertController(PertCalculator pertCalculator)
        {
            _pertCalculator = pertCalculator;
        }

        public IActionResult Index()
        {
            var defaultActivities = GetDefaultActivities();
            return View(defaultActivities);
        }
        private List<ActivityInputModel> GetDefaultActivities()
        {
            return new List<ActivityInputModel>
                {
                    new ActivityInputModel { Name = "A", PrecedenceString = "-", OptimisticTime = 3, MostLikelyTime = 4, PessimisticTime = 5 },
                    new ActivityInputModel { Name = "B", PrecedenceString = "-", OptimisticTime = 7, MostLikelyTime = 8, PessimisticTime = 9 },
                    new ActivityInputModel { Name = "C", PrecedenceString = "-", OptimisticTime = 0, MostLikelyTime = 1, PessimisticTime = 2 },
                    new ActivityInputModel { Name = "D", PrecedenceString = "C", OptimisticTime = 0, MostLikelyTime = 1, PessimisticTime = 2 },
                    new ActivityInputModel { Name = "E", PrecedenceString = "A", OptimisticTime = 5, MostLikelyTime = 6, PessimisticTime = 7 },
                    new ActivityInputModel { Name = "F", PrecedenceString = "A", OptimisticTime = 2, MostLikelyTime = 3, PessimisticTime = 4 },
                    new ActivityInputModel { Name = "G", PrecedenceString = "B", OptimisticTime = 4, MostLikelyTime = 5, PessimisticTime = 6 },
                    new ActivityInputModel { Name = "H", PrecedenceString = "E,F,G", OptimisticTime = 2, MostLikelyTime = 3, PessimisticTime = 4 },
                    new ActivityInputModel { Name = "I", PrecedenceString = "D", OptimisticTime = 0, MostLikelyTime = 1, PessimisticTime = 2 },
                    new ActivityInputModel { Name = "J", PrecedenceString = "I", OptimisticTime = 1, MostLikelyTime = 2, PessimisticTime = 3 },
                    new ActivityInputModel { Name = "K", PrecedenceString = "H", OptimisticTime = 1, MostLikelyTime = 2, PessimisticTime = 3 },
                    new ActivityInputModel { Name = "L", PrecedenceString = "J,K", OptimisticTime = 4, MostLikelyTime = 5, PessimisticTime = 6 }
                };
        }

        [HttpPost]
        public IActionResult Calculate(List<ActivityInputModel> inputs)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", inputs);
            }

            var activities = inputs.Select(input => new Activity
            {
                Name = input.Name,
                Precedence = string.IsNullOrEmpty(input.PrecedenceString)
                    ? new List<string>()
                    : input.PrecedenceString.Split(',').Select(p => p.Trim()).ToList(),
                OptimisticTime = input.OptimisticTime,
                MostLikelyTime = input.MostLikelyTime,
                PessimisticTime = input.PessimisticTime
            }).ToList();

            var result = _pertCalculator.CalculatePert(activities);
            return View("Result", result);
        }

        public IActionResult Reset()
        {
            return RedirectToAction("Index");
        }
    }
}