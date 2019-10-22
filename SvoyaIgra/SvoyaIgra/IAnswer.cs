using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvoyaIgra
{
    public interface IAnswer
    {
        string Content { get; set; }
        bool Correctness { get; set; }
    }
}