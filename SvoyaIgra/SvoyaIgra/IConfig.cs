using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvoyaIgra
{
    public interface IConfig
    {
        //Dictionary<int, IQuestion[]> Questions { get; set; }
        string[] Themes { get; set; }
    }
}
