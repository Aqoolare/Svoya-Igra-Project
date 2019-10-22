using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvoyaIgra
{
    public class Config
    {
        public List<IPlayer> Players { get; set; }
        public Dictionary<string,List<IQuestion>> Questions { get; set; }
        public List<string> Themes { get; set; }
    }
}