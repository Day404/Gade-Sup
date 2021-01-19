using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Sup
{
    abstract class Item : Tile
    {
        protected Item(int varY, int varX) : base(varY, varX)
        {
        }

        public abstract string ToString();
    }

    class Gold : Item
    {
        private int goldDrop = 0;
        private Random Rng = new Random();

        public int GoldDrop { get => goldDrop; set => goldDrop = value; }

        public Gold(int varY, int varX) : base(varY, varX)
        {
            goldDrop += 0;
            NewTile = TileType.Gold;
        }

        public override string ToString()
        {           
            return nameof(NewTile);
        }
    }

    abstract class Weapon : Item
    {
        protected int dmg, range, dur, cost;
        protected string wtype;
        public int Dmg { get => dmg; set => dmg = value; }
        public virtual int Range { get => range; set => range = value; }
        public int Dur { get => dur; set => dur = value; }
        public int Cost { get => cost; set => cost = value; }
        public string Wtype { get => wtype; set => wtype = value; }

        
        public Weapon(int varY, int varX) : base(varY, varX)
        {
            NewTile = TileType.Weapon;
            
        }



        public override string ToString()
        {
            return nameof(NewTile);
        }
    }

    class MeleeWeapon : Weapon
    {
        public enum Types {Dagger, Longsword, BareHands }
        public override int Range { get => base.Range; set => base.Range = 1; }
        public MeleeWeapon(Types DorL ,int varY = 0, int varX = 0) : base(varY, varX)
        {
            switch (DorL)
            {
                case Types.Dagger:
                    range = 1;
                    dmg = 3;
                    dur = 10;
                    cost = 3;
                    wtype = "Dagger";
                    break;
                case Types.Longsword:
                    range = 1;
                    dmg = 4;
                    dur = 6;
                    cost = 5;
                    wtype = "Longsword";
                    break;
                case Types.BareHands:
                    range = 1;
                    dmg = 2;
                    wtype = "Bare Hands";
                    break;
            }
        }
    }

    class RangedWeapon : Weapon
    {
        public enum Types {Rifle, Longbow }
        public override int Range { get => base.Range ; set => base.Range = value; }
        public RangedWeapon(Types RorL, int varY = 0, int varX = 0) : base(varY, varX)
        {
            switch (RorL)
            {
                case Types.Longbow:
                    wtype = "Longbow";
                    dur = 4;
                    range = 2;
                    dmg = 4;
                    cost = 6;
                    break;
                case Types.Rifle:
                    wtype = "Rifle";
                    dur = 3;
                    range = 3;
                    dmg = 5;
                    cost = 7;
                    break;
            }
        }
    }
}
