using System;
using System.Collections.Generic;
using System.Linq;

namespace TescoHack.Api.Models
{
    public class Game
    {
        public string Id { get; set; }
        public Team Team { get; set; }
        public Quest Quest { get; set; }

        public static Game Init()
        {
            return new Game
            {
                Team = new Team
                {
                    Name = "The Smiths",
                    Characters = new List<Character>
                    {
                        new Character
                        {
                            Name = "Tony",
                            Score = 0,
                            //CheckInTime = DateTime.Now,
                            //CheckOutTime = DateTime.Now
                        },
                        new Character
                        {
                            Name = "Lisa",
                            Score = 0,
                        }
                    }
                },
                Quest = new Quest()
                {
                    Missions = new List<Mission>
                    {
                        //new Mission
                        //{
                        //    Name = "Potatoe",
                        //    Finished = true,
                        //    Score = 5
                        //},
                        //new Mission
                        //{
                        //    Name = "Tomatoe",
                        //    Finished = true,
                        //    Score = 5
                        //}
                    }
                }
            };
        }

        public void FinishMission(string characterName, string missionName)
        {
            var character = Team.Characters.FirstOrDefault(x => x.Name == characterName);
            var mission = Quest.Missions.FirstOrDefault(x => x.Name == missionName);

        }
    }

    public class Quest
    {
        public List<Mission> Missions { get; set; }
    }

    public class Mission
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool Finished { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Team
    {
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
    }

    public class Character
    {
        public string Name { get; set; }
        public int Energy { get { return CalculateEnergy(); } }

        private int CalculateEnergy()
        {
            if (!CheckInTime.HasValue) return Score + 100;
            var endTime = DateTime.Now;
            if (CheckOutTime.HasValue) endTime = CheckOutTime.Value;
            var energy = Score - (endTime.Subtract(CheckInTime.Value)).Seconds;
            energy = Math.Max(0, energy);
            energy = Math.Min(100, energy);
            return energy;
        }

        public int Score { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }


    }
}
