using CheersMandu.Data.interfaces;
using CheersMandu.Data.Repositories.Dapper;
using CheersMandu.Models;
using CheersMandu.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CheersMandu.Controllers
{
    public class DrinkController : Controller
    {
        // this controller uses the Dapper implementations

        private readonly IDrinkRepository _drinkRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DrinkController(DapperDrinkRepository drinkRepository, DapperCategoryRepository categoryRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Drink> drinks;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(p => p.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", category, StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkRepository.Drinks
                        .Where(p => p.Category.CategoryName.Equals("Alcoholic"))
                        .OrderBy(p => p.Name);
                }
                else
                {
                    drinks = _drinkRepository.Drinks
                        .Where(p => p.Category.CategoryName.Equals("Non-alcoholic"))
                        .OrderBy(p => p.Name);
                }

                currentCategory = category;
            }

            var drinkListViewModel = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            };

            return View(drinkListViewModel);
        }

        public IActionResult Details(int drinkId)
        {
            var drink = _drinkRepository.GetDrinkById(drinkId);
            if (drink == null)
                return NotFound();

            return View(drink);
        }

        public ViewResult Search(string searchString)
        {
            var drinks = string.IsNullOrEmpty(searchString)
                ? _drinkRepository.Drinks
                : _drinkRepository.Drinks
                    .Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));

            var drinkListViewModel = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = "Search results"
            };

            ViewData["searchString"] = searchString;

            return View("List", drinkListViewModel);
        }
    }
}