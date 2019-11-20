using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svoya_Igra_Design
{
    [Serializable]
    public class NotCompletedGameCfg
    {
        public Config Cfg { get; set; }
        public List<Player> Players { get; set; }
        public int NumberOfTeam { get; set; }
        public int NumberOFMotion { get; set; }
        public NotCompletedGameCfg() { }
        public NotCompletedGameCfg(Config cfg, List<Player> players, int numOfTeam, int numOfMotion)
        {
            Cfg = cfg;
            Players = players;
            NumberOfTeam = numOfTeam;
            NumberOFMotion = numOfMotion;
        }
    }
}
