using CheersMandu.Data.interfaces;
using CheersMandu.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CheersMandu.Controllers
{
    public class HomeController:Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(homeViewModel);
        }
    }
}
