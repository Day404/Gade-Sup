using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Sup
{
    abstract class Tile
    {
        protected int vary;
        protected int varx;

        public int varY { get => vary; set => vary = value; }
        public int varX { get => varx; set => varx = value; }

        public enum TileType {Obstacle, EmptyTile, Gold, Weapon, Hero, Enemy, Leader, Mage, Goblin }

        public TileType NewTile;

        public Tile(int varY, int varX)
        {
            this.varY = varY;
            this.varX = varX;
        }
    }

    ///
    ///

    class Obstacle : Tile
    {
        public Obstacle(int varY, int varX) : base(varY, varX)
        {
            NewTile = TileType.Obstacle;
        }
    }

    ///
    ///

    class EmptyTile : Tile
    {
        public EmptyTile(int varY, int varX) : base(varY, varX)
        {
            NewTile = TileType.EmptyTile;
        }
    }
}
