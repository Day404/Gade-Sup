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
        private string empty = ". ", obsticale = "X", gold = " * ", weapon = "w", hero = "H", leader = "L", goblin = "G", mage = "M";
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

        public bool Move(Character.Movement Move)
        {
            bool Value = false;

            switch (Move)
            {
                case Character.Movement.Up:
                    if (H.Vision[0].NewTile == Tile.TileType.EmptyTile)
                    {
                        H.Move(Character.Movement.Up);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY + 1, H.varX] = new EmptyTile(H.varY - 1, H.varX);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    else if (H.Vision[0].NewTile == Tile.TileType.Gold)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX == H.varX)                          
                            {
                                H.PickUp(GameMap.Items[i]);
                                H.Wallet += 3;
                            
                            }
                        }
                        H.ToString();
                        H.Move(Character.Movement.Up);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY + 1, H.varX] = new EmptyTile(H.varY - 1, H.varX);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    else if (H.Vision[0].NewTile == Tile.TileType.Weapon)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX == H.varX)
                            {
                                H.PickUp(GameMap.Items[i]);

                            }
                        }
                        H.ToString();
                        H.Move(Character.Movement.Up);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY + 1, H.varX] = new EmptyTile(H.varY - 1, H.varX);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    break;
                    /////////////////////////////////////////////////////////////////////////////////////
                case Character.Movement.Down:
                    if (H.Vision[1].NewTile == Tile.TileType.EmptyTile)
                    {
                        H.Move(Character.Movement.Down);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY - 1, H.varX] = new EmptyTile(H.varY + 1, H.varX);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    else if (H.Vision[1].NewTile == Tile.TileType.Gold)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX == H.varX)
                            {
                                H.PickUp(GameMap.Items[i]);

                            }
                        }
                        
                        H.Move(Character.Movement.Down);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY - 1, H.varX] = new EmptyTile(H.varY + 1, H.varX);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    else if (H.Vision[1].NewTile == Tile.TileType.Weapon)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX == H.varX)
                            {
                                H.PickUp(GameMap.Items[i]);

                            }
                        }
                        
                        H.Move(Character.Movement.Down);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY - 1, H.varX] = new EmptyTile(H.varY + 1, H.varX);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    break;
                    /////////////////////////////////////////////////////////////////////////////////
                case Character.Movement.Left:
                    if (H.Vision[2].NewTile == Tile.TileType.EmptyTile)
                    {
                        H.Move(Character.Movement.Left);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY, H.varX + 1] = new EmptyTile(H.varY , H.varX + 1);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    else if (H.Vision[2].NewTile == Tile.TileType.Gold)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX == H.varX)
                            {
                                H.PickUp(GameMap.Items[i]);
                                

                            }
                        }
                        
                        H.Move(Character.Movement.Left);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY , H.varX + 1] = new EmptyTile(H.varY , H.varX + 1);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    else if (H.Vision[2].NewTile == Tile.TileType.Weapon)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX == H.varX)
                            {
                                H.PickUp(GameMap.Items[i]);

                            }
                        }
                        
                        H.Move(Character.Movement.Left);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY, H.varX + 1] = new EmptyTile(H.varY , H.varX + 1);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    break;
                    /////////////////////////////////////////////////////////////////////////////////
                case Character.Movement.Right:
                    if (H.Vision[3].NewTile == Tile.TileType.EmptyTile)
                    {
                        H.Move(Character.Movement.Right);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY, H.varX - 1] = new EmptyTile(H.varY, H.varX - 1);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    else if (H.Vision[3].NewTile == Tile.TileType.Gold)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX == H.varX)
                            {
                                H.PickUp(GameMap.Items[i]);


                            }
                        }

                        H.Move(Character.Movement.Right);
                        GameMap.MapDisplay[H.varY, H.varX] = H;
                        GameMap.MapDisplay[H.varY, H.varX - 1] = new EmptyTile(H.varY, H.varX - 1);
                        GameMap.UpdateVision();
                        Value = true;
                    }
                    else if (H.Vision[3].NewTile == Tile.TileType.Weapon)
                    {
                        for (int i = 0; i < GameMap.Items.Length; i++)
                        {
                            if (GameMap.Items[i].varY == H.varY && GameMap.Items[i].varX == H.varX)
                            {
                                H.PickUp(GameMap.Items[i]);

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
       
    }
}
