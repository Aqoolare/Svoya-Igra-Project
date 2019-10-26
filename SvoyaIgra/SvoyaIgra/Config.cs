using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvoyaIgra
{
    public class Config
    {
        public List<IPlayer> Players { get; set; }
        public Dictionary<int,string[]> Questions { get; set; }
        public string[] Themes { get; set; }
        public Config()
        {
            Players = new List<IPlayer>();
            Questions = new Dictionary<int, string[]>();
            for (int i = 0; i < 6; i++)
            {
                Questions.Add(i, new string[6]);
            }
            Themes = new string[6];
        }
    }
}