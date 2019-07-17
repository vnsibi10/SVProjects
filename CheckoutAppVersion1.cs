using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            CartItem oCItem = new CartItem();
            Console.WriteLine("Enter the items to Purchase based on item list(Enter P for Payment after you done with purchase)");
            String item;
            while ((item = Console.ReadLine().Trim().ToLower()) != "p")
            {
                oCItem.ItemCode = item;
                oCItem.AddToCart();
            }
            Console.Write("Apply Discount(Enter Y for Yes/any Character for No): ");
            bool isDiscAppl = Console.ReadLine().Trim().ToLower()=="y";
            oCItem.IsDiscApplied = isDiscAppl ? true : false;

            Console.WriteLine("CheckOut Price: " + oCItem.CartTotal());
            
            Console.WriteLine("Haven't finished the implementation of Discounted approach. All methods are in place...Based on the input/Discount code, we need to call the right method for all distinct items in the list...Thank You...");
            Console.ReadLine();
        }
    }

    public class CartItemList
    {
        string itemApple = "Apple";
        string itemOrange = "Orange";
        string itemPeach = "Peach";

        public  List<Tuple<string, float>> PriceList;

        public List<Tuple<string, float>> GetPriceList()
        {            
            PriceList = new List<Tuple<string, float>>()
            {
                new Tuple<string, float>(itemApple, .60f),
                new Tuple<string, float>(itemOrange, .25f),
                new Tuple<string, float>(itemPeach, .20f)

            };
            return PriceList;
        }        
    }

    public class CartItem 
    {
        private float m_Price = 0;
        private string m_Code = "";
        private bool m_IsDiscApplied = false;
        private List<string> ItemPurchaseList = new List<string>();

        public float Price
        {
            get { return m_Price; }
            set { m_Price = value; }
        }
        public string ItemCode
        {
            get { return m_Code; }
            set { m_Code = value; }
        }
        public bool IsDiscApplied
        {
            get { return m_IsDiscApplied; }
            set { m_IsDiscApplied = value; }
        }
        public List<string> AddToCart()
        {
            ItemPurchaseList.Add(ItemCode);
            return ItemPurchaseList;
        }        

        public float GetItemPrice(string itemVal)
        {            
            CartItemList oCIL = new CartItemList();
            List<Tuple<string, float>> ItemPriceList = oCIL.GetPriceList();
            var myItem = ItemPriceList.FirstOrDefault((t) => t.Item1.Trim().ToLower() == itemVal.Trim().ToLower());
            Price = myItem.Item2;
            return Price;
        }

        public int GetItemCount(string itemVal)
        {
            int itemCount = 0;
            foreach (string item in ItemPurchaseList)
            {
                if (item.Trim().ToLower() == itemVal.Trim().ToLower())
                {
                    itemCount += 1;
                }
            }
            return itemCount;
        }

        public float BuyOneGetOneStrategy(string itemVal)
        {
            float disItemTotalPrice = 0;
            int itemCount = 0;
            float itemPrice = 0;
            int disItem = 0;
            int remItem = 0;

            itemPrice = GetItemPrice(itemVal);
            itemCount = GetItemCount(itemVal);
           
            disItem = itemCount / 2;
            remItem = itemCount % 2;

            disItemTotalPrice = (disItem * itemPrice + remItem * itemPrice);
            return disItemTotalPrice;
        }

        public float BuyThreeForThePriceOfTwo(string itemVal)
        {
            float disItemTotalPrice = 0;
            int itemCount = 0;
            float itemPrice = 0;
            int disItem = 0;
            int remItem = 0;

            itemPrice = GetItemPrice(itemVal);
            itemCount = GetItemCount(itemVal);

            disItem = itemCount / 3;
            remItem = itemCount % 3;

            disItemTotalPrice = (disItem * itemPrice * 2 + remItem * itemPrice);
            return disItemTotalPrice;
        }

        public float PriceWithOutDisc(string itemVal)
        {
            float ItemTotalPrice = 0;
            int itemCount = 0;
            float itemPrice = 0;            

            itemPrice = GetItemPrice(itemVal);
            itemCount = GetItemCount(itemVal);

            ItemTotalPrice = itemCount * itemPrice ;
            return ItemTotalPrice;
        }


        public float CartTotal()
        {
            float totalPrice = 0;
            List<string> distinctItems = new List<string>();
            distinctItems.AddRange(ItemPurchaseList.Distinct());
            if (!IsDiscApplied)
            {
                foreach (string item in distinctItems)
                {
                    Price = PriceWithOutDisc(item);
                    totalPrice += Price; ;
                }
            }
            else
            {
                //Discounted Approach
                //Based on the Input(Dicount code or flag), Call the right method for all distinct items 
            }
            return totalPrice;

        }
    }

   









}

