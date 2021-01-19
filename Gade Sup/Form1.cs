﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gade_Sup
{
    public partial class frmDisplay : Form
    {

        GameEngine Engine = new GameEngine();
        Hero H;


        public frmDisplay()
        {

            InitializeComponent();
            H = Engine.GameMap.H;
            rtbStats.Text = "";
            StatUpdate();
            ShopUpdate();
            DisplayMap();
            btnBuy.Enabled = false;

            
        }

        public void StatUpdate()
        {
            lblPStats.Text += H.ToString();
        }
         
        public void GoodGold()
        {                  
            btnBuy.Enabled = false;
            if(Engine.Vendor.CanBuy(cmbShopList.SelectedIndex) == true)
            {
                btnBuy.Enabled = true;
            }
        }
        public void ShopUpdate()
        {
            cmbShopList.Items.Clear();

            for (int i = 0; i < 3; i++)
            {
                cmbShopList.Items.Add(Engine.Vendor.DisplayWeapon(i));
            }
            
        }
        public void TargetsUpdate()
        {
            cmbTargets.Items.Clear();
            for (int i = 0; i < Engine.GameMap.Enemies.Length; i++)
            {
                cmbTargets.Items.Add(Engine.GameMap.Enemies[i]);
            }
            
        }
        public void DisplayMap()
        {
            lblMap.Text = "";

            for (int y = 0; y < Engine.GameMap.Height ; y++)
            {
                for (int x = 0; x < Engine.GameMap.Width ; x++)
                {
                    if (Engine.GameMap.MapDisplay[y, x].NewTile == Tile.TileType.EmptyTile)
                    {
                        lblMap.Text += Engine.Empty;
                    }
                    if (Engine.GameMap.MapDisplay[y, x].NewTile == Tile.TileType.Obstacle)
                    {
                        lblMap.Text += Engine.Obsticale;
                    }
                    if (Engine.GameMap.MapDisplay[y, x].NewTile == Tile.TileType.Gold)
                    {
                        lblMap.Text += Engine.Gold;
                    }
                    if (Engine.GameMap.MapDisplay[y, x].NewTile == Tile.TileType.Hero)
                    {
                        lblMap.Text += Engine.Hero;
                    }
                    if (Engine.GameMap.MapDisplay[y, x].NewTile == Tile.TileType.Goblin)
                    {
                        lblMap.Text += Engine.Goblin;
                    }
                    if (Engine.GameMap.MapDisplay[y, x].NewTile == Tile.TileType.Mage)
                    {
                        lblMap.Text += Engine.Mage;
                    }
                    if (Engine.GameMap.MapDisplay[y, x].NewTile == Tile.TileType.Leader)
                    {
                        lblMap.Text += Engine.Leader;
                    }
                    if (Engine.GameMap.MapDisplay[y, x].NewTile == Tile.TileType.Weapon)
                    {
                        lblMap.Text += Engine.Weapon;
                    }
                    
                }
                lblMap.Text += "\n";
                TargetsUpdate();
            }
        }

        
        private void lblMap_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Engine.Move(Character.Movement.Up);
            Engine.EnemyMove();
            DisplayMap();
            StatUpdate();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Engine.Move(Character.Movement.Left);
            DisplayMap();
            StatUpdate();
            Engine.EnemyMove();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Engine.Move(Character.Movement.Down);
            DisplayMap();
            StatUpdate();
            Engine.EnemyMove();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Engine.Move(Character.Movement.Right);
            DisplayMap();
            StatUpdate();
            Engine.EnemyMove();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            //GoodGold();
            Engine.Vendor.Buy(cmbShopList.SelectedIndex);
            StatUpdate();
            ShopUpdate();
        }

        private void cmbShopList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Engine.Vendor.CanBuy(cmbShopList.SelectedIndex) == true)
            {
                btnBuy.Enabled = true;
            }
            else
            {
                btnBuy.Enabled = false;
            }
        }
    }
}
