/*using Microsoft.AspNetCore.Http;
*/using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Controllers
{
    public class PlayerController : Controller
    {
        
        private CookieOptions cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
        private AuditContext _auditContext;
        public Audit audit = new Audit();
        public PlayerController(AuditContext auditContext)
        {
            _auditContext = auditContext;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (ModelState.IsValid)
            {
                audit.Amount = player.TotalCoins;
                /*                audit.AuditId = 1;
                */
                audit.PlayerName =player.Name;
                audit.AuditTypeId = 1;
                audit.CreatedDate = DateTime.Now;
                _auditContext.Add(audit);
                _auditContext.SaveChanges();
                Helpers.CoinsHelper.SetName(HttpContext, player.Name);
                Helpers.CoinsHelper.SetGrandTotal(HttpContext, player.TotalCoins);
                Helpers.CoinsHelper.SetSessionTotal(HttpContext, player.TotalCoins);
               
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult CashOut()
        {
            audit.Amount = Helpers.CoinsHelper.GetSessionTotal(HttpContext);
            audit.AuditTypeId = 2;
            audit.CreatedDate = DateTime.Now;
            audit.PlayerName = Helpers.CoinsHelper.GetName(HttpContext);
            if (string.IsNullOrEmpty(audit.PlayerName))
            {
                audit.PlayerName = "";
            }
                _auditContext.Add(audit);
            _auditContext.SaveChanges();
            TempData["Message"] = $"You cashed out for {Helpers.CoinsHelper.GetSessionTotal(HttpContext).ToString("N2")} coins";
            Helpers.CoinsHelper.CashOutCoins(HttpContext);
            return RedirectToAction("Index", "Player");
        }

    } 
}
