using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Sup
{
    class Map
    {
        private Tile[,] mapDisplay;
        private int width, height;
        private Random Rng = new Random();
        public Hero H;
        private Item[] Items;
        private int ItemIndex = 0;
        private Tile Spawn;
        public int Width { get => width;  }
        public int Height { get => height;  }
        public Tile[,] MapDisplay { get => mapDisplay; set => mapDisplay = value; }

        public Map(int MinX, int MaxX, int MinY, int MaxY, int GoldDrops, int WeaponDrops)
        {
            Items = new Item[GoldDrops + WeaponDrops];
            this.height = Rng.Next(MinY, MaxY + 1);
            this.width = Rng.Next(MinX, MaxX + 1);

            this.mapDisplay = new Tile[height, width];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (y == 0 || y == Height - 1 || x == 0 || x == Width - 1)
                    {
                        this.mapDisplay[y, x] = new Obstacle(y, x);
                    }
                    else
                    {
                        this.mapDisplay[y, x] = new EmptyTile(y, x);
                    }
                  
                }
                               
            }

            H = (Hero)Create(Tile.TileType.Hero);

            for (int i = 0; i < GoldDrops; i++)
            {
                Items[ItemIndex] = (Item)Create(Tile.TileType.Gold);
                ItemIndex++;
            }

            for (int i = GoldDrops; i < WeaponDrops + GoldDrops; i++)
            {
                Items[ItemIndex] = (Item)Create(Tile.TileType.Weapon);
                ItemIndex++;
            }


        }

        private Tile Create(Tile.TileType Type)
        {
            int Height = height, Width = width; 
            
            int Ypos = Rng.Next(1, Height - 1);
            int Xpos = Rng.Next(1, Width - 1);

            while (mapDisplay[Ypos, Xpos].NewTile != Tile.TileType.EmptyTile)
            {
                Ypos = Rng.Next(1, Height++);
                Xpos = Rng.Next(1, Width++);
            }

            switch (Type)
            {
                case Tile.TileType.Hero:
                    mapDisplay[Ypos, Xpos] = new Hero(100,Ypos, Xpos);
                    Spawn = new Hero(100, Ypos, Xpos);
                    break;
                case Tile.TileType.Gold:
                    mapDisplay[Ypos, Xpos] = new Gold(Ypos, Xpos);
                    Spawn = new Gold(Ypos, Xpos);
                    //Items[ItemIndex] = new Gold(Ypos, Xpos);
                    break;
                case Tile.TileType.Weapon:
                    if (Rng.Next(0, 2) == 0)
                    {
                        if (Rng.Next(0, 2) == 0)
                        {
                            mapDisplay[Ypos, Xpos] = new MeleeWeapon(MeleeWeapon.Types.Dagger, Ypos, Xpos);
                            Spawn = mapDisplay[Ypos, Xpos];
                        }
                        else
                        {
                            mapDisplay[Ypos, Xpos] = new MeleeWeapon(MeleeWeapon.Types.Longsword, Ypos, Xpos);
                            Spawn = mapDisplay[Ypos, Xpos];
                        }

                    }
                    else
                    {
                        if (Rng.Next(0, 2) == 0)
                        {
                            mapDisplay[Ypos, Xpos] = new RangedWeapon(RangedWeapon.Types.Longbow, Ypos, Xpos);
                            Spawn = mapDisplay[Ypos, Xpos];
                        }
                        else
                        {
                            mapDisplay[Ypos, Xpos] = new RangedWeapon(RangedWeapon.Types.Rifle, Ypos, Xpos);
                            Spawn = mapDisplay[Ypos, Xpos];
                        }
                    }
                    
                    break;
            }
            return Spawn;
            
            
        }
    }
}
