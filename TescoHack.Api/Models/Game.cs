using System;
using System.Collections.Generic;

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
                            Name = "Tony"
                        },
                        new Character
                        {
                            Name = "Lisa"
                        }
                    }
                },
                Quest = new Quest()
            };
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
    }

    public class Team
    {
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
    }

    public class Character
    {
        public string Name { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
