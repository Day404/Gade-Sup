using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Sup
{
    abstract class Character : Tile
    {
        protected int maxHp;
        protected int wallet;
        protected Tile[] vision;
        protected int hp;
        protected int dmg;

        public int Wallet { get => wallet; set => wallet = value; }
        public Tile[] Vision { get => vision; set => vision = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Dmg { get => dmg; set => dmg = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }

        public enum Movement {Idle, Up, Down, left, Right }
        public Character(int varY, int varX) : base(varY, varX)
        {
            Vision = new Tile[8];
        }
        public virtual void Attack(Character Target)
        {
            Target.Hp = Target.Hp - Dmg;
        }

        public bool IsDead()
        {
            if (Hp < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Character Target)
        {
            int Value = Math.Abs(Target.varY - varY) + Math.Abs(Target.varX - varX);
            return Value;
        }

        public virtual bool CheckRange(Character Target)
        {
            if (DistanceTo(Target) <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public abstract Movement ReturnMove(Movement Move);
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

        public override Movement ReturnMove(Movement Move)
        {
            if (vision[Convert.ToInt32(Move)].NewTile != TileType.EmptyTile)
            {
                return Movement.Idle;
            }
            else
            {
                return Move;
            }
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

    class Goblin : Enemy
    {
        public Goblin(int Hp, int Dmg, int varY, int varX) : base(Hp, Dmg, varY, varX)
        {
            Hp = 10;
            maxHp = 10;
            Dmg = 1;
        }

        public override Movement ReturnMove(Movement Move)
        {
            int Roll = Rng.Next(0, 4);
            while (vision[Roll].NewTile != TileType.EmptyTile)
            { 
                Roll = Rng.Next(0, 4);
            }
            return (Movement)Roll;
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
