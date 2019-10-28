using System;
using SvoyaIgra;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svoya_Igra_Design
{
    public class Config : IConfig
    {
        public List<IPlayer> Players { get; set; }
        public Dictionary<int, IQuestion[]> Questions { get; set; }
        public string[] Themes { get; set; }

        public Config()
        {
            Players = new List<IPlayer>();
            Questions = new Dictionary<int, IQuestion[]>();
            for (int i = 0; i < 6; i++)
            {
                Questions.Add(i, new Question[6]);
                for (int j = 0; j < 6; j++)
                {
                    Questions[i][j] = new Question();
                }
            }
            Themes = new string[6];
        }
    }
}
