using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Helpers
{
    public static class GameHelper
    {
        //This creates a collection of 12 tiles with randomly generated values
        public static List<Tile> GenerateNewGame()
        {
            var tileList = new List<Tile>();
            Random r = new Random();
            for (int i = 0; i < 12; i++)
            {
                double randomValue = 0;
                if (r.Next(1,4) != 1)
                {
                    randomValue = (r.NextDouble() + 0.5) * 2;
                }

                var tile = new Tile()
                {
                    TileIndex = i,
                    Visible = false,
                    Value = randomValue.ToString("N2")
                };

                tileList.Add(tile);
            }
            return tileList;
        }

        /*
        * There are MANY other helpers you may want to create here.  I've created some
        *  placeholder as well as hints for others you may find useful:
        *
        * 
        * HINT: Remember that your HttpContext is not available in this class so you may
        * need to pass it into methods that need it!
        * 
        */


        // - GetCurrentGame - If there is no current game state in session Generate a New Game
        // and store it in session, otherwise deserialize the List<Tile> from session
        public static List<Tile> GetCurrentGame(HttpContext httpContext)
        {
            var tileList = new List<Tile>();
            
            tileList = DeserializeTileList(httpContext, httpContext.Session.GetString("tile-list"));

            return tileList;
        }

        // - SaveCurrentGame - Save the current state of the game to session. 
        public static void SaveCurrentGame(HttpContext httpContext, List<Tile> tileList)
        { 
            httpContext.Session.SetString("tile-list", JsonConvert.SerializeObject(tileList));
        }
        public static List<Tile> UpdateCurrentGame(bool isCardFounded, int index, List<Tile> tileList)
        {
            if (isCardFounded)
            {
                foreach(Tile i in tileList)
                {
                    if(i.TileIndex != index)
                    {
                         i.Value= (double.Parse(i.Value) * 2).ToString("N2");
                    }
                }
            }
           
            return tileList;
        }
        /* - PickATileAndUpdateGame - code that contains the game logic as 
         * mentioned in Part 4 of the assignment. Hint: you'll need to pass in the
         * id of the selected tile as one of the parameters.
         */
        public static double UpdateScore(HttpContext httpContext, double tileValue)
        {
            double tempCurrentBet = CoinsHelper.GetCurrentTotal(httpContext);
            double profit = 0.00;
            if(tileValue != 0) 
            {   
                profit =(tempCurrentBet * tileValue) - tempCurrentBet;
            }
            else
            {
                CoinsHelper.SetLostPerSession(httpContext, CoinsHelper.GetCurrentTotal(httpContext).ToString("N2"));
                tempCurrentBet = 0.00;
                profit = 0.00;
            }
            CoinsHelper.SetProfit(httpContext, profit);
            return tempCurrentBet + profit;
        }

        // - ClearCurrentGame - clear the current game state from session
        public static void ClearCurrentGame(/* parameters? */)
        {
            //code goes here
        }

        //- Finally, methods to serialize and deserialzie the Tile list.
        public static string SerializeTileList(HttpContext httpContext, List<Tile> tileList)
        {
            var result = "";
            result  = JsonConvert.SerializeObject(tileList);
            return result;
        }

        public static List<Tile> DeserializeTileList(HttpContext httpContext, string JSONTileList)
        {
            var results = new List<Tile>();
            if (!string.IsNullOrEmpty(JSONTileList))
            {
                results = JsonConvert.DeserializeObject<List<Tile>>(JSONTileList);
            }
            return results;
        }
    }
}
