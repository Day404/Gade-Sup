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
        //protected int wallet;
        protected Tile[] vision = new Tile[8];
        protected int hp;
        protected int dmg;
        protected string dialog;
        protected Weapon floor;
        protected Gold wallet;
        public Gold Wallet { get => wallet; set => wallet = value; }
        public Tile[] Vision { get => vision; set => vision = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Dmg { get => dmg; set => dmg = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public string Dialog { get => dialog; set => dialog = value; }
        public Weapon Floor { get => floor; set => floor = value; }

        public enum Movement { Up, Down, Left, Right, Idle }
        public Character(int varY, int varX) : base(varY, varX)
        {
            dialog = "";
            wallet = new Gold(0,0);
        }
        public void Loot(Character Target)
        {
            wallet.GoldDrop += Target.wallet.GoldDrop;
            if (floor.Wtype != "Bare Hands")
            {

            }
            else
            {
                floor = Target.floor;
                dialog = "Just Looted " + floor.Wtype;
            }
            
        }
        private void Equip(Weapon W)
        {
            Floor = W;
            this.dmg = W.Dmg;
        }
        public void PickUp(Item Item)
        {
            Random Ran = new Random();
            if (Item.NewTile == TileType.Gold)
            {
                Wallet.GoldDrop += Ran.Next(1, 6);
                
            }
            if (Item.NewTile == TileType.Weapon)
            {
                Equip((Weapon)Item);
                
            }
        }
        public virtual void Attack(Character Target)
        {
            Target.Hp -= floor.Dmg;
            if(IsDead(Target) == true)
            {
                Loot(Target);
                
            }
        }

        public bool IsDead(Character Target)
        {
            if (Target.Hp < 1)
            {
                dialog = Target.GetType().Name + " was killed by " + GetType().Name;
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
                    varY = varY -1;
                    break;
                case Movement.Down:
                    varY = varY +1;
                    break;
                case Movement.Left:
                    varX = varX -1;
                    break;
                case Movement.Right:
                    varX = varX+ 1;
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
            wallet.GoldDrop += 12 ;
            hp = Hp;
            maxHp = Hp;
            floor = new MeleeWeapon(MeleeWeapon.Types.BareHands);
            
            
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
            Text = "Player Stats:\nHp: "
                   + hp
                   + "/"
                   + maxHp
                   + "\nCurrent Weapon: "
                   + floor.Wtype
                   + "\nWeapon Range: "
                   + floor.Range
                   + "\nWeapon Damage: "
                   + floor.Dmg
                   + "\nDurability: "
                   + floor.Dur
                   + "\nGold: "
                   + wallet.GoldDrop
                   + "\n["
                   + varX
                   + ","
                   + varY
                   + "]\n";
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
            string Text = "\n"
                          + floor.Wtype
                          + ": "
                          + this.GetType().Name
                          + "("
                          + hp
                          + "/"
                          + maxHp
                          + ")"
                          + " at "
                          + "\n["
                          + varX
                          + ","
                          + varY
                          + "](Damage: "
                          + floor.Dmg
                          + ")";
            return Text;
        }
    }

    class Goblin : Enemy
    {
        public Goblin(int Hp, int Dmg, int varY, int varX) : base(Hp, Dmg, varY, varX)
        {
            NewTile = TileType.Goblin;
            maxHp = Hp;
            wallet.GoldDrop = 1;
            floor = new MeleeWeapon(MeleeWeapon.Types.Dagger);
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
            wallet.GoldDrop = 3;
            floor = new MeleeWeapon(MeleeWeapon.Types.BareHands);
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
            wallet.GoldDrop = 2;
            floor = new MeleeWeapon(MeleeWeapon.Types.Longsword);
        }

        public override Movement ReturnMove(Movement Move)
        {
            
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
