using System;
using SvoyaIgra;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svoya_Igra_Design
{
    class Question : IQuestion
    {
        public string Content { get; set; }
        public string Theme { get; set; }
        public QuestionType QType { get; set; }
        public int Cost { get; set; }
        public List<IAnswer> AnswerList { get; set; }
        public string SingleAnswer { get; set; }

        public IAnswer GetAnswer()
        {
            throw new NotImplementedException();
        }
    }
}
