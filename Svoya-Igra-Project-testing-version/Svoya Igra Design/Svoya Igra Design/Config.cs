using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svoya_Igra_Design
{
    [Serializable]
    public class Config
    {
        public Dictionary<int, Question[]> Questions { get; set; }
        public string[] Themes { get; set; }

        public Config() { }

        public Config(int NumberOfThemes, int NumberOfQuestions)
        {
            Questions = new Dictionary<int, Question[]>();
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
