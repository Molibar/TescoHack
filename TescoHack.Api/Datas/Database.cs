using System.Collections.Generic;
using System.Web.Mvc.Html;
using TescoHack.Api.Models;

namespace TescoHack.Api.Datas
{
    public class Database
    {
        public static Game Game { get; set; }
        public static Dictionary<string, List<HighScore>> HighScores { get; set; }

        public Database()
        {
            HighScores = new Dictionary<string, List<HighScore>>
            {
                {"Global", new List<HighScore>
                {
                    new HighScore{Name = "Fam. Brännström", Score = 322},
                    new HighScore{Name = "Раскольникова", Score = 321},
                    new HighScore{Name = "The Smiths", Score = 318},
                    new HighScore{Name = "Kick 'Em All", Score = 317},
                    new HighScore{Name = "葉", Score = 317},
                }},
                {"Store", new List<HighScore>
                {
                    new HighScore{Name = "Ninja Turtles", Score = 249},
                    new HighScore{Name = "Batman Kids", Score = 245},
                    new HighScore{Name = "Meow-Meow", Score = 244},
                    new HighScore{Name = "Ice Cream Hogs", Score = 241},
                    new HighScore{Name = "Cat Lovers", Score = 231},
                }},
                {"Friends", new List<HighScore>
                {
                    new HighScore{Name = "Ninja Turtles", Score = 249},
                    new HighScore{Name = "Batman Kids", Score = 245},
                    new HighScore{Name = "Meow-Meow", Score = 244},
                    new HighScore{Name = "Ice Cream Hogs", Score = 241},
                    new HighScore{Name = "Cat Lovers", Score = 231},
                }}
            };
        }
    }

    public class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}