using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Sup
{
    
    class Shop
    {
        private Weapon[] ShopList;
        private Random Rng = new Random();
        Weapon ReturnType;
        Character Bot;

        public Shop(Character Buyer)
        {
            ShopList = new Weapon[3];
            Bot = Buyer;

            for (int i = 0; i < 3; i++)
            {
                ShopList[i] = RandomWeapon();
            }
        }

        private Weapon RandomWeapon()
        {
            int Roll = Rng.Next(0, 4);
            
            switch (Roll)
            {
                case 0:
                    ReturnType = new MeleeWeapon(MeleeWeapon.Types.Dagger, Bot.varY, Bot.varX);
                    break;
                case 1:
                    ReturnType = new MeleeWeapon(MeleeWeapon.Types.Longsword, Bot.varY, Bot.varX);
                    break;
                case 2:
                    ReturnType = new RangedWeapon(RangedWeapon.Types.Longbow, Bot.varY, Bot.varX);
                    break;
                case 3:
                    ReturnType = new RangedWeapon(RangedWeapon.Types.Rifle, Bot.varY, Bot.varX);
                    break;
            }
            return ReturnType;
        }

        public bool CanBuy(int Index)
        {
            bool value = false;

            if (ShopList[Index].Cost < Bot.Wallet.GoldDrop)
            {
                value = true;
            }

            return value;
        }

        public void Buy(int Index)
        {
            Bot.Wallet.GoldDrop = Bot.Wallet.GoldDrop - ShopList[Index].Cost;
            Bot.PickUp(ShopList[Index]);
            ShopList[Index] = RandomWeapon();
            
        }

        public string DisplayWeapon(int Index)
        {
            string Text = "\nBuy " + ShopList[Index].Wtype + "(" + ShopList[Index].Cost + " Gold)"; 
            return Text;
        }
    }
}
