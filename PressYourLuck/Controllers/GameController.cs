using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PressYourLuck.Helpers;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Controllers
{
    public class GameController : Controller
    {
        private AuditContext _auditContext;
        private Audit audit = new Audit();

        public GameController(AuditContext auditContext)
        {
            _auditContext = auditContext;
        }
        public IActionResult Index()
        {
            List<Tile> tileList = GameHelper.GetCurrentGame(HttpContext);

            /* var tileList = GameHelper.GenerateNewGame();
             string JSONTileList = GameHelper.SerializeTileList(HttpContext, tileList);*/
            /* var tileList = new List<Tile>();*/
            /*tileList = GameHelper.DeserializeTileList(HttpContext, JSONTileList);*/

            if (tileList.Count != 12)
            {
                tileList = GameHelper.GenerateNewGame();
                GameHelper.SaveCurrentGame(HttpContext, tileList);
            }
            /*else
            {
                tileList = GameHelper.DeserializeTileList(HttpContext, JSONTileList);
            }*/
            /* var currentBet = Helpers.CoinsHelper.GetCurrentBet();
             ViewBag["current-bet"] = currentBet;*/
/*            if (CoinsHelper.GetCurrentBet(HttpContext) <= 0)
            {
                return RedirectToAction("Index", "Home");
            }*/
            return View(tileList);
/*         
*/      }
        public IActionResult Exit()
        {
            if (CoinsHelper.GetCurrentTotal(HttpContext) == 0)
            {
                if (CoinsHelper.GetSessionTotal(HttpContext) == 0.0 && CoinsHelper.GetCurrentTotal(HttpContext) == 0)
                {
                    CoinsHelper.SetName(HttpContext, "");
                    CoinsHelper.SetGrandTotal(HttpContext, 0.00);
                    
                    return RedirectToAction("Index", "Player");
                }
                audit.Amount = CoinsHelper.GettLostPerSession(HttpContext);
                audit.PlayerName = CoinsHelper.GetName(HttpContext);
                audit.CreatedDate = DateTime.Now;
                audit.AuditTypeId = 4;
                _auditContext.Add(audit);
                _auditContext.SaveChanges();
            }
            else {
                audit.Amount = CoinsHelper.GetCurrentTotal(HttpContext);
                audit.AuditTypeId = 3;
                audit.CreatedDate = DateTime.Now;
                audit.PlayerName = CoinsHelper.GetName(HttpContext);
                _auditContext.Add(audit);
                _auditContext.SaveChanges();
                TempData["Message"] = $"BIG WINNER!You chased out for {(CoinsHelper.GetCurrentTotal(HttpContext).ToString("N2"))} coins!Care to press your luck again ?";

            }
            CoinsHelper.SetSessionTotal(HttpContext, CoinsHelper.GetCurrentTotal(HttpContext) + CoinsHelper.GetSessionTotal(HttpContext));
            CoinsHelper.SetGrandTotal(HttpContext, CoinsHelper.GetSessionTotal(HttpContext));
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Reveal(int id)
        {
            List<Tile> tileList = GameHelper.GetCurrentGame(HttpContext);
            bool isCardFound = false;
            int cardFoundedIndex = -1;
            double tileValue = double.Parse(tileList[id].Value);
            foreach(Tile i in tileList)
            {if (i.TileIndex == id && double.Parse(i.Value) != 0.00)
                {
                    isCardFound = true;
                    cardFoundedIndex = i.TileIndex;
                }
            }
            if (isCardFound)
            {
                TempData["Message"] = $"Congrats you’ve found a {tileValue} multipler!  All remaining values have doubled.Will you Press Your Luck ?";
                tileList[cardFoundedIndex].Visible = true;
            }
            else
            {
                TempData["Message"] = "On no!You busted out. Better luck next time!";
                foreach (Tile i in tileList)
                {
                    i.Visible = true;
                }
                if(CoinsHelper.GetSessionTotal(HttpContext) == 0.0)
                {
                    TempData["Message"] = "You’ve lost all your coins and must enter more to keep playing";
                }
            }
            GameHelper.SaveCurrentGame(HttpContext, GameHelper.UpdateCurrentGame(isCardFound, cardFoundedIndex, tileList));
            CoinsHelper.SetCurrentTotal(HttpContext, GameHelper.UpdateScore(HttpContext, tileValue));
            return RedirectToAction("Index", "Game");
        }
    }
}
