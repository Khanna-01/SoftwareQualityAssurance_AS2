using System;

namespace Group11_Assignment2
{
    public class Product
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public double ItemPrice { get; private set; }
        public int StockAmount { get; private set; }

        public bool TryCreateProduct(int prodID, string prodName, double itemPrice, int stockAmount)
        {
            if (prodID < 5 || prodID > 50000)
            {
                Console.WriteLine("Invalid ProductID");
                return false;
            }

            if (string.IsNullOrEmpty(prodName))
            {
                Console.WriteLine("Invalid ProductName");
                ProductName = "Unknown"; // Assign "Unknown" if product name is invalid
                return false;
            }

            if (itemPrice < 5 || itemPrice > 5000)
            {
                Console.WriteLine("Invalid ItemPrice");
                return false;
            }

            if (stockAmount < 5 || stockAmount > 500000)
            {
                Console.WriteLine("Invalid StockAmount");
                return false;
            }

            ProductID = prodID;
            ProductName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;

            return true;
        }


        public void IncreaseStock(int amount)
        {
            if (amount > 0)
            {
                StockAmount += amount;
            }
        }

        public void DecreaseStock(int amount)
        {
            if (amount > 0 && StockAmount - amount >= 0)
            {
                StockAmount -= amount;
            }
        }

    }
}
