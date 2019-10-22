using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvoyaIgra
{
    public interface IPlayer
    {
        string Name { get; set; }
        int Score { get; set; }
    }
}