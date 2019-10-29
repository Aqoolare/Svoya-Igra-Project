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

        public Config(int NumberOfThemes, int NumberOfQuestions)
        {
            Players = new List<IPlayer>();
            Questions = new Dictionary<int, IQuestion[]>();
            for (int i = 0; i < NumberOfThemes; i++)
            {
                Questions.Add(i, new Question[NumberOfQuestions]);
                for (int j = 0; j < NumberOfQuestions; j++)
                {
                    Questions[i][j] = new Question();
                }
            }
            Themes = new string[NumberOfThemes];
        }
    }
}
