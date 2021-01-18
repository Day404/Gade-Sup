using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Sup
{
    class GameEngine 
    {
        private Map gameMap;       
        private string empty = " . ", obsticale = "X ", gold = " * ", weapon = "W", hero = "H";
        Hero H;
        public Shop Vendor;

        public Map GameMap { get => gameMap; set => gameMap = value; }
        public string Empty { get => empty;  }
        public string Obsticale { get => obsticale; }
        public string Gold { get => gold;  }
        public string Weapon { get => weapon;  }
        public string Hero { get => hero;  }

        public GameEngine()
        {
            GameMap = new Map(10, 10, 10, 10, 6);
            H = GameMap.H;
            Vendor = new Shop(H);
        }


       
    }
}
