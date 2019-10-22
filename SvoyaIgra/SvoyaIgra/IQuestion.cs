using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvoyaIgra
{
    public interface IQuestion
    {
        string Content { get; set; }
        string Theme { get; set; }
        QuestionType QType { get; set; }
        int Cost { get; set; }
        List<IAnswer> AnswerList { get; set; }
        IAnswer GetAnswer();
    }
}