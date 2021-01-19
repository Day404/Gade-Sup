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
        protected Tile[] vision = new Tile[8];
        protected int hp;
        protected int dmg;
        protected Weapon Floor ;
        public int Wallet { get => wallet; set => wallet = value; }
        public Tile[] Vision { get => vision; set => vision = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Dmg { get => dmg; set => dmg = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }

        public enum Movement { Up, Down, Left, Right, Idle }
        public Character(int varY, int varX) : base(varY, varX)
        {
           
        }
        private void Equip(Weapon W)
        {
            Floor = W;
        }
        public void PickUp(Item Item)
        {
            if (Item.NewTile == TileType.Gold)
            {
                //var Gold = new Gold(Item.varY, Item.varX);

                //wallet += Gold.GoldDrop;
                Random Ran = new Random();

                wallet += Ran.Next(1, 6);
                
            }
            if (Item.NewTile == TileType.Weapon)
            {
                Equip((Weapon)Item);
            }
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
                    varY--;
                    break;
                case Movement.Down:
                    varY++;
                    break;
                case Movement.Left:
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
        public Hero(int Hp, int varY, int varX) : base(varY, varX)
        {
            NewTile = TileType.Hero;
            //wallet = 0;
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
            Text = "\nPlayer Stats:\nHp: " + hp + "/" + maxHp + "\nDamage: " + dmg + "\nGold: " + wallet + "\n[" + varX + "," + varY + "]";
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
            NewTile = TileType.Goblin;
            maxHp = Hp;
            
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

    class Mage : Enemy
    {
        public Mage(int Hp, int Dmg, int varY, int varX) : base(Hp, Dmg, varY, varX)
        {
            NewTile = TileType.Mage;
            maxHp = Hp;
            
        }

        public override bool CheckRange(Character Target)
        {
            for (int i = 0; i < 8; i++)
            {
                if (vision[i].NewTile == TileType.Hero || vision[i].NewTile == TileType.Enemy)
                {
                    return true;
                }
            }
            return false;
        }

        public override Movement ReturnMove(Movement Move)
        {
            return Movement.Idle;
        }
    }

    class Leader : Enemy
    {
        private Tile leadTarget;
        public Tile LeadTarget { get => leadTarget; set => leadTarget = value; }
        public Leader(int Hp, int Dmg, int varY, int varX) : base(Hp, Dmg, varY, varX)
        {
            NewTile = TileType.Leader;
            maxHp = Hp;
        }

        public override Movement ReturnMove(Movement Move)
        {
            //if (leadTarget.varY < varY && vision[0].NewTile == TileType.EmptyTile)
            //{
            //    return Movement.Up;
            //}
            //if (leadTarget.varY > varY && vision[1].NewTile == TileType.EmptyTile)
            //{
            //    return Movement.Down;
            //}
            //if (leadTarget.varX < varX && vision[2].NewTile == TileType.EmptyTile)
            //{
            //    return Movement.Left;
            //}
            //if (leadTarget.varX > varX && vision[3].NewTile == TileType.EmptyTile)
            //{
            //    return Movement.Right;
            //}
            Movement Value = Movement.Idle;

            switch (Move)
            {
                case Movement.Up:
                    if (leadTarget.varY < varY && vision[0].NewTile == TileType.EmptyTile)
                    {
                        Value = Movement.Up;
                    }
                    break;
                case Movement.Down:
                    if (leadTarget.varY > varY && vision[1].NewTile == TileType.EmptyTile)
                    {
                        Value = Movement.Down;
                    }
                    break;
                case Movement.Left:
                    if (leadTarget.varX < varX && vision[2].NewTile == TileType.EmptyTile)
                    {
                        Value = Movement.Left;
                    }
                    break;
                case Movement.Right:
                    if (leadTarget.varX > varX && vision[3].NewTile == TileType.EmptyTile)
                    {
                        Value = Movement.Right;
                    }
                    break;               
            }
            

            int Roll = Rng.Next(0, 4);

            switch (Roll)
            {
                case 0:
                    if (vision[0].NewTile == TileType.EmptyTile)
                    {
                        Value = Movement.Up;
                    }
                    break;
                case 1:
                    if (vision[1].NewTile == TileType.EmptyTile)
                    {
                        Value = Movement.Down;
                    }
                    break;
                case 2:
                    if (vision[2].NewTile == TileType.EmptyTile)
                    {
                        Value = Movement.Left;
                    }
                    break;
                case 4:
                    if (vision[3].NewTile == TileType.EmptyTile)
                    {
                        Value = Movement.Right;
                    }
                    break;
            }

            return Value;
        }

    }
}
