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
        private string empty = ".", obsticale = "X", gold = "*", weapon = "W", hero = "H", leader = "L", goblin = "G", mage = "M";
        Hero H;
        Enemy[] Enemies ;
        public Shop Vendor;
        private Random Ran = new Random();
        public Map GameMap { get => gameMap; set => gameMap = value; }
        public string Empty { get => empty; }
        public string Obsticale { get => obsticale; }
        public string Gold { get => gold; }
        public string Weapon { get => weapon; }
        public string Hero { get => hero; }
        public string Leader { get => leader; }
        public string Goblin { get => goblin; }
        public string Mage { get => mage; }

        public GameEngine()
        {
            
            
            GameMap = new Map(14, 14, 8, 8, 6, 20, 3);
            H = GameMap.H;
            Vendor = new Shop(H);
            Enemies = new Enemy[GameMap.Enemies.Length];
            for (int i = 0; i < GameMap.Enemies.Length; i++)
            {
                Enemies[i] = GameMap.Enemies[i];
            }
        }

        public bool Move(Character.Movement Move)
        {
            bool Value = false;

            switch (Move)
            {
                case Character.Movement.Up:
                    if (H.Vision[0].NewTile == Tile.TileType.EmptyTile || H.Vision[0].NewTile == Tile.TileType.Gold || H.Vision[0].NewTile == Tile.TileType.Weapon)
                    {
                        if (H.Vision[0].NewTile == Tile.TileType.Gold)
                        {
                            for (int i = 0; i < GameMap.Items.Length; i++)
                            {
                                if (GameMap.Items[i].varY + 1 == H.varY && GameMap.Items[i].varX == H.varX)
                                {
                                    H.PickUp(GameMap.Items[i]);
                                    //H.Wallet.GoldDrop += Ran.Next(1, 6);


                                }
                            }
                        }
                        else if (H.Vision[0].NewTile == Tile.TileType.Weapon)
                        {
                            for (int i = 0; i < GameMap.Items.Length; i++)
                            {
                                if (GameMap.Items[i].varY + 1 == H.varY && GameMap.Items[i].varX == H.varX)
                                {
                                    H.PickUp(GameMap.Items[i]);

                                }
                            }
                        }
                        H.Move(Character.Movement.Up);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY + 1, H.varX] = new EmptyTile(H.varY + 1, H.varX);                       
                        GameMap.UpdateVision();
                        Value = true;
                    }

                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Character.Movement.Down:
                    if (H.Vision[1].NewTile == Tile.TileType.EmptyTile || H.Vision[1].NewTile == Tile.TileType.Gold || H.Vision[1].NewTile == Tile.TileType.Weapon)
                    {
                        if (H.Vision[1].NewTile == Tile.TileType.Gold)
                        {
                            for (int i = 0; i < GameMap.Items.Length; i++)
                            {
                                if (GameMap.Items[i].varY - 1 == H.varY && GameMap.Items[i].varX == H.varX)
                                {
                                    H.PickUp(GameMap.Items[i]);
                                    //H.Wallet.GoldDrop += Ran.Next(1, 6);
                                }
                            }
                        }
                        else if (H.Vision[1].NewTile == Tile.TileType.Weapon)
                        {
                            for (int i = 0; i < GameMap.Items.Length; i++)
                            {
                                if (GameMap.Items[i].varY - 1 == H.varY && GameMap.Items[i].varX == H.varX)
                                {
                                    H.PickUp(GameMap.Items[i]);

                                }
                            }
                        }
                        H.Move(Character.Movement.Down);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY - 1, H.varX] = new EmptyTile(H.varY + 1, H.varX);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                   
                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Character.Movement.Left:
                    if (H.Vision[2].NewTile == Tile.TileType.EmptyTile || H.Vision[2].NewTile == Tile.TileType.Gold || H.Vision[2].NewTile == Tile.TileType.Weapon)
                    {
                        if (H.Vision[2].NewTile == Tile.TileType.Gold)
                        {
                            for (int i = 0; i < GameMap.Items.Length; i++)
                            {
                                if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX + 1 == H.varX)
                                {
                                    H.PickUp(GameMap.Items[i]);
                                    //H.Wallet.GoldDrop += Ran.Next(1, 6);

                                }
                            }
                        }
                        else if (H.Vision[2].NewTile == Tile.TileType.Weapon)
                        {
                            for (int i = 0; i < GameMap.Items.Length; i++)
                            {
                                if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX + 1 == H.varX)
                                {
                                    H.PickUp(GameMap.Items[i]);

                                }
                            }
                        }
                            H.Move(Character.Movement.Left);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY, H.varX + 1] = new EmptyTile(H.varY, H.varX + 1);
                        GameMap.UpdateVision();
                        H.ToString();
                        Value = true;
                    }
                    
                    break;
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Character.Movement.Right:
                    if (H.Vision[3].NewTile == Tile.TileType.EmptyTile || H.Vision[3].NewTile == Tile.TileType.Gold || H.Vision[3].NewTile == Tile.TileType.Weapon)
                    {
                        if (H.Vision[3].NewTile == Tile.TileType.Gold)
                        {
                            for (int i = 0; i < GameMap.Items.Length; i++)
                            {
                                if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX - 1 == H.varX)
                                {
                                    H.PickUp(GameMap.Items[i]);
                                    H.Wallet.GoldDrop += Ran.Next(1, 6);

                                }
                            }
                        }
                        else if (H.Vision[3].NewTile == Tile.TileType.Weapon)
                        {
                            for (int i = 0; i < GameMap.Items.Length; i++)
                            {
                                if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX - 1 == H.varX)
                                {
                                    H.PickUp(GameMap.Items[i]);

                                }
                            }
                        }
                            H.Move(Character.Movement.Right);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY, H.varX - 1] = new EmptyTile(H.varY, H.varX - 1);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    
                    break;
                /////////////////////////////////////////////////////////////////////////////////
                case Character.Movement.Idle:
                    GameMap.UpdateVision();
                    Value = false;
                    break;

            }

            return Value;
        }

        public void EnemyMove()
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                EnemyMove(Enemies[i].NewTile, i);
            }
        }
        private void EnemyPickup(int Direction, int Index)
        {
            switch (Direction)
            {
                case 0:
                    if (Enemies[Index].Vision[0].NewTile == Tile.TileType.Gold)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY + 1 == Enemies[Index].varY && GameMap.Items[i].varX == Enemies[Index].varX)
                            {
                                Enemies[Index].PickUp(GameMap.Items[i]);
                                //H.Wallet.GoldDrop += Ran.Next(1, 6);
                            }
                        }
                    }
                    else if (Enemies[Index].Vision[0].NewTile == Tile.TileType.Weapon)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY + 1 == Enemies[Index].varY && GameMap.Items[i].varX == Enemies[Index].varX)
                            {
                                Enemies[Index].PickUp(GameMap.Items[i]);

                            }
                        }
                    }
                    break;
                case 1:
                    if (Enemies[Index].Vision[1].NewTile == Tile.TileType.Gold)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY - 1 == Enemies[Index].varY && GameMap.Items[i].varX == Enemies[Index].varX)
                            {
                                Enemies[Index].PickUp(GameMap.Items[i]);
                                //H.Wallet.GoldDrop += Ran.Next(1, 6);
                            }
                        }
                    }
                    else if (Enemies[Index].Vision[1].NewTile == Tile.TileType.Weapon)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY - 1 == Enemies[Index].varY && GameMap.Items[i].varX == Enemies[Index].varX)
                            {
                                Enemies[Index].PickUp(GameMap.Items[i]);

                            }
                        }
                    }
                    break;
                case 2:
                    if (Enemies[Index].Vision[2].NewTile == Tile.TileType.Gold)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY  == Enemies[Index].varY && GameMap.Items[i].varX + 1 == Enemies[Index].varX)
                            {
                                Enemies[Index].PickUp(GameMap.Items[i]);
                                //H.Wallet.GoldDrop += Ran.Next(1, 6);
                            }
                        }
                    }
                    else if (Enemies[Index].Vision[2].NewTile == Tile.TileType.Weapon)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY  == Enemies[Index].varY && GameMap.Items[i].varX + 1 == Enemies[Index].varX)
                            {
                                Enemies[Index].PickUp(GameMap.Items[i]);

                            }
                        }
                    }
                    break;
                case 3:
                    if (Enemies[Index].Vision[3].NewTile == Tile.TileType.Gold)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY  == Enemies[Index].varY && GameMap.Items[i].varX -1 == Enemies[Index].varX)
                            {
                                Enemies[Index].PickUp(GameMap.Items[i]);
                                //H.Wallet.GoldDrop += Ran.Next(1, 6);
                            }
                        }
                    }
                    else if (Enemies[Index].Vision[3].NewTile == Tile.TileType.Weapon)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY  == Enemies[Index].varY && GameMap.Items[i].varX - 1 == Enemies[Index].varX)
                            {
                                Enemies[Index].PickUp(GameMap.Items[i]);

                            }
                        }
                    }
                    break;
            }
        }
        private void EnemyMove(Tile.TileType Type, int Index)
        {

            switch (Type)
            {
                case Tile.TileType.Leader:
                    if (H.varY < Enemies[Index].varY && Enemies[Index].Vision[0].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[0].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[0].NewTile == Tile.TileType.Weapon)
                    {
                        EnemyPickup(0, Index);

                        Enemies[Index].Move(Character.Movement.Up);
                        GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                        GameMap.MapDisplay[Enemies[Index].varY + 1, Enemies[Index].varX] = new EmptyTile(Enemies[Index].varY + 1, Enemies[Index].varX);
                        GameMap.UpdateVision();

                    }
                    else if (H.varY > Enemies[Index].varY && Enemies[Index].Vision[1].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[1].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[1].NewTile == Tile.TileType.Weapon)
                    {
                        EnemyPickup(1, Index);
                        Enemies[Index].Move(Character.Movement.Down);
                        GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                        GameMap.MapDisplay[Enemies[Index].varY - 1, Enemies[Index].varX] = new EmptyTile(Enemies[Index].varY - 1, Enemies[Index].varX);
                        GameMap.UpdateVision();

                    }
                    else if (H.varX < Enemies[Index].varX && Enemies[Index].Vision[2].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[2].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[2].NewTile == Tile.TileType.Weapon)
                    {
                        EnemyPickup(2, Index);
                        Enemies[Index].Move(Character.Movement.Left);
                        GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                        GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX + 1] = new EmptyTile(Enemies[Index].varY, Enemies[Index].varX + 1);
                        GameMap.UpdateVision();

                    }
                    else if (H.varX > Enemies[Index].varX && Enemies[Index].Vision[3].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[3].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[3].NewTile == Tile.TileType.Weapon)
                    {
                        EnemyPickup(3, Index);
                        Enemies[Index].Move(Character.Movement.Down);
                        GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                        GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX + 1] = new EmptyTile(Enemies[Index].varY, Enemies[Index].varX + 1);
                        GameMap.UpdateVision();

                    }
                    else
                    {
                        switch (Ran.Next(0, 4))
                        {
                            case 0:
                                if (Enemies[Index].Vision[0].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[0].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[0].NewTile == Tile.TileType.Weapon)
                                {
                                    EnemyPickup(0, Index);
                                    Enemies[Index].Move(Character.Movement.Up);
                                    GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                                    GameMap.MapDisplay[Enemies[Index].varY + 1, Enemies[Index].varX] = new EmptyTile(Enemies[Index].varY + 1, Enemies[Index].varX);
                                    GameMap.UpdateVision();

                                }
                                break;
                            ///////////////////////////////////////////////////////////////////////////
                            case 1:
                                if (Enemies[Index].Vision[1].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[1].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[1].NewTile == Tile.TileType.Weapon)
                                {
                                    EnemyPickup(1, Index);
                                    Enemies[Index].Move(Character.Movement.Down);
                                    GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                                    GameMap.MapDisplay[Enemies[Index].varY - 1, Enemies[Index].varX] = new EmptyTile(Enemies[Index].varY - 1, Enemies[Index].varX);
                                    GameMap.UpdateVision();

                                }
                                break;
                            ///////////////////////////////////////////////////////////////////////////
                            case 2:
                                if (Enemies[Index].Vision[2].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[2].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[2].NewTile == Tile.TileType.Weapon)
                                {
                                    EnemyPickup(2, Index);
                                    Enemies[Index].Move(Character.Movement.Left);
                                    GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                                    GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX + 1] = new EmptyTile(Enemies[Index].varY, Enemies[Index].varX + 1);
                                    GameMap.UpdateVision();

                                }
                                break;
                            ///////////////////////////////////////////////////////////////////////////
                            case 3:
                                if (Enemies[Index].Vision[3].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[3].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[3].NewTile == Tile.TileType.Weapon)
                                {
                                    EnemyPickup(3, Index);
                                    Enemies[Index].Move(Character.Movement.Right);
                                    GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                                    GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX - 1] = new EmptyTile(Enemies[Index].varY, Enemies[Index].varX - 1);
                                    GameMap.UpdateVision();

                                }
                                break;

                        }
                    }
                    break;
                    break;
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Tile.TileType.Goblin:
                    switch (Ran.Next(0, 4))
                    {
                        case 0:
                            if (Enemies[Index].Vision[0].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[0].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[0].NewTile == Tile.TileType.Weapon)
                            {
                                EnemyPickup(0, Index);
                                Enemies[Index].Move(Character.Movement.Up);
                                GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                                GameMap.MapDisplay[Enemies[Index].varY + 1, Enemies[Index].varX] = new EmptyTile(Enemies[Index].varY + 1, Enemies[Index].varX);
                                GameMap.UpdateVision();
                                
                            }
                            break;
                            ///////////////////////////////////////////////////////////////////////////
                        case 1:
                            if (Enemies[Index].Vision[1].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[1].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[1].NewTile == Tile.TileType.Weapon)
                            {
                                EnemyPickup(1, Index);
                                Enemies[Index].Move(Character.Movement.Down);
                                GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                                GameMap.MapDisplay[Enemies[Index].varY - 1, Enemies[Index].varX] = new EmptyTile(Enemies[Index].varY - 1, Enemies[Index].varX);
                                GameMap.UpdateVision();
                                
                            }
                            break;
                            ///////////////////////////////////////////////////////////////////////////
                        case 2:
                            if (Enemies[Index].Vision[2].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[2].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[2].NewTile == Tile.TileType.Weapon)
                            {
                                EnemyPickup(3, Index);
                                Enemies[Index].Move(Character.Movement.Left);
                                GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                                GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX + 1] = new EmptyTile(Enemies[Index].varY, Enemies[Index].varX + 1);
                                GameMap.UpdateVision();
                                
                            }
                            break;
                            ///////////////////////////////////////////////////////////////////////////
                        case 3:
                            if (Enemies[Index].Vision[3].NewTile == Tile.TileType.EmptyTile || Enemies[Index].Vision[3].NewTile == Tile.TileType.Gold || Enemies[Index].Vision[3].NewTile == Tile.TileType.Weapon)
                            {
                                EnemyPickup(3,Index);
                                Enemies[Index].Move(Character.Movement.Right);
                                GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX] = Enemies[Index];
                                GameMap.MapDisplay[Enemies[Index].varY, Enemies[Index].varX - 1] = new EmptyTile(Enemies[Index].varY, Enemies[Index].varX - 1);
                                GameMap.UpdateVision();
                                
                            }
                            break;

                    }
                    break;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Tile.TileType.Mage:
                    break;
            }

        }
       
    }
}
