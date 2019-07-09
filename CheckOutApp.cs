using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutApp
{
    class CheckOutApp
    {

        List<Tuple<string, double>> priceList;
        List<string> itemPurchased;
        string itemApple = "Apple";
        string itemOrange = "Orange";

        public CheckOutApp()
        {

            priceList = new List<Tuple<string, double>>()
            {
                new Tuple<string, double>(itemApple, .60),
                new Tuple<string, double>(itemOrange, .25)
            };

            itemPurchased = new List<string>() { { "Apple" }, { "Orange" }, { "Apple" }, { "Apple" }, { "Orange" }, { "Apple" }, { "Orange" } };

        }

        public double CheckOutPrice(string isDiscAppl)
        {
            double checkoutPrice = 0;
            if (isDiscAppl.Trim().ToUpper() == "Y")
            {
                checkoutPrice = DiscountCheckOutPrice();
            }
            else
            {
                checkoutPrice = OriginalCheckOutPrice();
            }
            return checkoutPrice;
        }

        public double OriginalCheckOutPrice()
        {
            double origCheckOutPrice = 0;
            double itemPrice = 0;

            foreach (string val in itemPurchased)
            {
                itemPrice = getpriceofitem(val);
                origCheckOutPrice += itemPrice;
            }
            return origCheckOutPrice;
        }

        public double DiscountCheckOutPrice()
        {
            double discountCheckOutPrice = 0;
            discountCheckOutPrice = BuyOneGetOneStrategy(itemApple) + BuyThreeForThePriceOfTwo(itemOrange);
            return discountCheckOutPrice;
        }


        public double BuyOneGetOneStrategy(string itemVal)
        {
            double disTotalPrice = 0;
            int itemCount = 0;
            int disItem = 0;
            int remItem = 0;

            double itemPrice = getpriceofitem(itemVal);

            foreach (string val in itemPurchased)
            {
                if (val.Trim().ToLower() == itemVal.Trim().ToLower())
                {
                    itemCount += 1;
                }
            }

            disItem = itemCount / 2;
            remItem = itemCount % 2;

            disTotalPrice = (disItem * itemPrice + remItem * itemPrice);
            return disTotalPrice;
        }

        public double BuyThreeForThePriceOfTwo(string itemVal)
        {
            double disTotalPrice = 0;
            int itemCount = 0;
            int disItem = 0;
            int remItem = 0;

            double itemPrice = getpriceofitem(itemVal);

            foreach (string val in itemPurchased)
            {
                if (val.Trim().ToLower() == itemVal.Trim().ToLower())
                {
                    itemCount += 1;
                }
            }

            disItem = itemCount / 3;
            remItem = itemCount % 3;

            disTotalPrice = (disItem * itemPrice * 2 + remItem * itemPrice);
            return disTotalPrice;
        }



        public double getpriceofitem(string itemName)
        {
            double price = 0;
            var myItem = priceList.FirstOrDefault((t) => t.Item1 == itemName);
            price = myItem.Item2;
            return price;
        }


        static void Main(string[] args)
        {

            double chkOutPrice = 0;
            Console.Write("Apply Discount(Enter Y for Yes/any Character for No): ");
            string isDiscAppl = Console.ReadLine();

            CheckOutApp oCheckOutApp = new CheckOutApp();
            chkOutPrice = oCheckOutApp.CheckOutPrice(isDiscAppl.Trim().ToUpper());
            Console.WriteLine("CheckOut Price: " + chkOutPrice);

            Console.WriteLine("Thank You...");
            Console.ReadLine();
        }
    }
}
