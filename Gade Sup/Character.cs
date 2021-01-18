using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Sup
{
    abstract class Character : Tile
    {
        protected int hp, maxHp, dmg;
        protected int wallet;

        public int Wallet { get => wallet; set => wallet = value; }

        public enum Movement {Idle, Up, Down, left, Right }
        public Character(int varY, int varX) : base(varY, varX)
        {
           
        }

        public void Move(Movement Move)
        {
            switch (Move)
            {
                case Movement.Idle:
                    varY = varY;
                    varX = varX;
                    break;
                case Movement.Up:
                    varY++;
                    break;
                case Movement.Down:
                    varY--;
                    break;
                case Movement.left:
                    varX--;
                    break;
                case Movement.Right:
                    varX++;
                    break;
            }
        }

        public abstract override string ToString();
    }

    class Hero : Character
    {
        public Hero(int Hp,  int varY, int varX) : base(varY, varX)
        {
            NewTile = TileType.Hero;
            wallet = 12;
            hp = Hp;
            maxHp = Hp;
            dmg = 2;
        }

        public override string ToString()
        {
            string Text = "";
            Text = "\nPlayer Stats:\nHp: " + hp + "/" + maxHp + "\nDamage: " + dmg + "\nGold: "+ wallet +"\n[" + varX + "," + varY + "]";
            return Text;

        }
    }

    abstract class Enemy : Character
    {
        protected Random Rng = new Random();
        protected Enemy(int Hp, int Dmg, int varY, int varX) : base(varY, varX)
        {
            NewTile = TileType.Enemy;
            hp = Hp;
            maxHp = Hp;
            dmg = Dmg;
        }

        public override string ToString()
        {
            string Text = "\n" + nameof(Enemy) + " at " + "\n[" + varX + "," + varY + "](Damage: " + dmg + ")";
            return Text;
        }
    }

    class Leader : Enemy
    {
        private Tile leadTarget;
        public Tile LeadTarget { get => leadTarget; set => leadTarget = value; }
        public Leader(int Hp, int Dmg, int varY, int varX) : base(Hp, Dmg, varY, varX)
        {
            Hp = 20;
            Dmg = 2;
        }

        
    }
}
