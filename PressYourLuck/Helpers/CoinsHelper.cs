using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Helpers
{
    public static class CoinsHelper
    {
        /*public string grandTotalCoins = "grand-total";
        public string sessionTotalCoins = "session-total";
        p*/
        /*
         * Consider using this helper to Get and Set the Current Bet and the original bet
         * (both in session variables), as well as adding a Get and Set for the player's
         * total number of coins (which we'll store in Cookies)
         * 
         * HINT: Remember that HttpContext as well as Response and Request objects are not
         * available from here, so you may need to pass those in from your controller.
         * 
         * I've coded the first one for you and have created placeholders for the rest.
         * 
         */
        /*public static void SaveCurrentBet(HttpContext httpContext, double bet)
        {
            httpContext.Session.SetString("current-bet", bet.ToString("N2"));
        }


        //Return the current bet stored in session
        public static double GetCurrentBet(HttpContext httpContext)
        {
            try {return Double.Parse(httpContext.Session.GetString("current-bet")); }
            catch {}
            return 0.0;
                
        }

        //Save the original bet into session
        public static void SaveOriginalBet(HttpContext httpContext, double originalBet)
        
        {
            httpContext.Session.SetString("original-bet", originalBet.ToString("N2"));
        }


        //Get the original bet from session
        public static double GetOriginalBet(HttpContext httpContext)
        {
        
            return Double.Parse(httpContext.Session.GetString("original-bet"));
        }

        //Save the players total number of coins into a cookie.  Don't forget to
        // persist the cookie (Chapter 9!)
        public static void SaveTotalCoins(HttpContext httpContext, string Name, double TotalCoins,CookieOptions cookieOptions)
        {
            string name = Name;
            httpContext.Session.SetString("player-name", name);
            httpContext.Session.SetString("total-coins", TotalCoins.ToString());
            httpContext.Response.Cookies.Append("player-name", name, cookieOptions);
            httpContext.Response.Cookies.Append("total-coins", TotalCoins.ToString(), cookieOptions);

        }*/
        public static void CashOutCoins(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete("total-coins");
            httpContext.Response.Cookies.Delete("name");

        }

        //Get the players total number of coins from a cookie.
        /* public static double GetTotalCoins(HttpContext httpContext)
         {
             double totalCoins;
             try
             {
                 totalCoins = Double.Parse(httpContext.Request.Cookies["total-coins"]);
             }
             catch
             {
                 return 0.00;
             }
             return totalCoins;
         }*/
        public static void SetLostPerSession(HttpContext httpContext, string lostCoin)
        {
           httpContext.Session.SetString("lost-per-session", lostCoin.ToString());
        }
        public static double GettLostPerSession(HttpContext httpContext)
        {
            return double.Parse(httpContext.Session.GetString("lost-per-session"));
        }
        public static string GetName(HttpContext httpContext)
        {
            string name;
            try
            {
                name = httpContext.Request.Cookies["name"];
            }
            catch
            {
                return "";
            }
            return name;
        }
        public static void SetName(HttpContext httpContext, string name)
        {
            httpContext.Response.Cookies.Append("name", name);
        }
        public static double GetGrandTotal(HttpContext httpContext)
        { double grandTotal;
            try
            {
                grandTotal = double.Parse(httpContext.Request.Cookies["grand-total"]);
            }
            catch
            {
                grandTotal = 0.0;
            }
            return grandTotal;
        }
        public static void SetGrandTotal(HttpContext httpContext, double grandTotal)
        {
            httpContext.Response.Cookies.Append("grand-total", grandTotal.ToString("N2"));
        }
        public static double GetSessionTotal(HttpContext httpContext)
        {
            string temp = httpContext.Session.GetString("session-total");
            if(temp == null)
            {
                return 0.0;
            }
            return double.Parse(temp);
        }
        public static void SetSessionTotal(HttpContext httpContext, double sessionTotal)
        {
            httpContext.Session.SetString("session-total", sessionTotal.ToString("N2"));
        }

        public static double GetCurrentTotal(HttpContext httpContext)
        {
            return Double.Parse(httpContext.Session.GetString("current-total"));
        }
        public static void SetCurrentTotal(HttpContext httpContext, double currentTotal)
        {
            httpContext.Session.SetString("current-total", currentTotal.ToString("N2"));
        }
        public static double GetProfit(HttpContext httpContext)
        {
            return Double.Parse(httpContext.Session.GetString("profit"));
        }
        public static void SetProfit(HttpContext httpContext, double profit)
        {
            httpContext.Session.SetString("profit", profit.ToString("N2"));
        }

    }
}