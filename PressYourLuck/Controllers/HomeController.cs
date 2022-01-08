using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PressYourLuck.Helpers;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Controllers
{
    public class HomeController : Controller
    {
        private AuditContext _auditContext;
        private readonly ILogger<HomeController> _logger;
        private CookieOptions cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(30) };

        public HomeController(AuditContext auditContext)
        {
            _auditContext = auditContext;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            CoinsHelper.SetSessionTotal(HttpContext, CoinsHelper.GetGrandTotal(HttpContext));
         
            if (string.IsNullOrEmpty(Helpers.CoinsHelper.GetName(HttpContext)))
            {
                return RedirectToAction("Index", "Player");
            }
            else
            {
                homeViewModel.Name = Helpers.CoinsHelper.GetName(HttpContext);
                homeViewModel.TotalCoins = Helpers.CoinsHelper.GetGrandTotal(HttpContext);
            }
            return View(homeViewModel);
        }
        [HttpPost]
        public IActionResult Index(HomeViewModel homeViewModel)
        {
            double currentBet = homeViewModel.OriginalBet;

            homeViewModel.Name = Helpers.CoinsHelper.GetName(HttpContext);
            homeViewModel.TotalCoins = Helpers.CoinsHelper.GetGrandTotal(HttpContext);
            if (currentBet > 0)
            {
                CoinsHelper.SetSessionTotal(HttpContext, homeViewModel.TotalCoins - currentBet);
                CoinsHelper.SetCurrentTotal(HttpContext, currentBet);
/*                Helpers.CoinsHelper.SaveTotalCoins(HttpContext, homeViewModel.Name, homeViewModel.TotalCoins, cookieOptions);
*//*                Helpers.CoinsHelper.SaveCurrentBet(HttpContext, currentBet);
*/               
                List<Tile> tileList = GameHelper.GenerateNewGame();
                GameHelper.SaveCurrentGame(HttpContext, tileList);
                return RedirectToAction("Index", "Game"); 
            }
            else
            {
                ViewBag.Error = "Your Bet should more than \"0\" coins.";
            }
            return View(homeViewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
