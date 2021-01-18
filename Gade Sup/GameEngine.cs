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
        private string empty = ". ", obsticale = "X", gold = " * ", weapon = "W", hero = "H", leader = "L", goblin = "G", mage = "M";
        Hero H;
        public Shop Vendor;

        public Map GameMap { get => gameMap; set => gameMap = value; }
        public string Empty { get => empty;  }
        public string Obsticale { get => obsticale; }
        public string Gold { get => gold;  }
        public string Weapon { get => weapon;  }
        public string Hero { get => hero;  }
        public string Leader { get => leader; }
        public string Goblin { get => goblin; }
        public string Mage { get => mage; }

        public GameEngine()
        {
            GameMap = new Map(14, 14, 8, 8, 6, 3, 5);
            H = GameMap.H;
            Vendor = new Shop(H);
        }


       
    }
}
