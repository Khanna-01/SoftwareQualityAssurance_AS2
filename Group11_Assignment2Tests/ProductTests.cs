//Assignment2
// Created by :Group-11

using Group11_Assignment2;


namespace Group11_Assignment2Tests
{
    public class ProductTests
    {
        private Product _product { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            _product = new Product();
        }


        // 1.Test for invalid stock amount less than 5
        [Test]
        public void InvalidStockAmountLessThan5_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "Cake", 1000, 4);
            Assert.That(result, Is.False);
            Assert.That(product.StockAmount, Is.EqualTo(0));
        }


        // 2.Test for invalid stock amount greater than 500000
        [Test]
        public void InvalidStockAmountGreaterThan500000_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "Pen", 1000, 500001);
            Assert.That(result, Is.False);
            Assert.That(product.StockAmount, Is.EqualTo(0));
        }


        // 3.Test for invalid product ID less than 5
        [Test]
        public void InvalidProductIDLessThan5_ReturnsFalse_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(3, "Chair", 1000, 200);
            Assert.That(result, Is.False);
            Assert.That(product.ProductID, Is.EqualTo(0));
        }


        // 4.Test for invalid product ID greater than 50000
        [Test]
        public void InvalidProductIDGreaterThan50000_ReturnsFalse_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(50001, "Chair", 1000, 200);
            Assert.That(result, Is.False);
            Assert.That(product.ProductID, Is.EqualTo(0));
        }


        // 5.Test for invalid product name (empty string)
        [Test]
        public void InvalidProductName_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "", 1000, 200);
            Assert.That(result, Is.False);
            Assert.That(product.ProductName, Is.EqualTo("Unknown"));
        }


        // 6.Test for valid product creation
        [Test]
        public void ValidProductCreation_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "Shirt", 1000, 100);
            Assert.That(result, Is.True);
            Assert.That(product.ProductID, Is.EqualTo(10));
            Assert.That(product.ProductName, Is.EqualTo("Shirt"));
            Assert.That(product.ItemPrice, Is.EqualTo(1000));
            Assert.That(product.StockAmount, Is.EqualTo(100));
        }


        // 7.Test for invalid item price less than 5
        [Test]
        public void InvalidItemPriceLessThan5_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "Pen", 4, 100);
            Assert.That(result, Is.False);
            Assert.That(product.ItemPrice, Is.EqualTo(0));
        }


        // 8.Test for invalid item price greater than 5000
        [Test]
        public void InvalidItemPriceGreaterThan5000_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "Laptop", 5001, 100);
            Assert.That(result, Is.False);
            Assert.That(product.ItemPrice, Is.EqualTo(0));
        }


        // 9.Test for stock increase functionality
        [Test]
        public void IncreaseStock_Test()
        {
            var product = new Product();
            product.TryCreateProduct(10, "Table", 1000, 10);
            product.IncreaseStock(5);
            Assert.That(product.StockAmount, Is.EqualTo(15));
        }


        // 10.Test for stock increase with zero amount
        [Test]
        public void IncreaseStockWithZeroAmount_Test()
        {
            var product = new Product();
            product.TryCreateProduct(15, "Computer", 2000, 50);
            product.IncreaseStock(0);
            Assert.That(product.StockAmount, Is.EqualTo(50));
        }


        // 11.Test for stock increase with negative amount
        [Test]
        public void IncreaseStockWithNegativeAmount_Test()
        {
            var product = new Product();
            product.TryCreateProduct(15, "LEGO", 150, 35);
            product.IncreaseStock(-5);
            Assert.That(product.StockAmount, Is.EqualTo(35));
        }

        // 12.Test for stock decrease functionality
        [Test]
        public void DecreaseStock_Test()
        {
            var product = new Product();
            product.TryCreateProduct(10, "Chair", 500, 10);
            product.DecreaseStock(3);
            Assert.That(product.StockAmount, Is.EqualTo(7));
        }


        // 13.Test for decreasing stock with invalid amount (more than available)
        [Test]
        public void DecreaseStockWithInvalidAmount_Test()
        {
            var product = new Product();
            product.TryCreateProduct(10, "Couch", 1200, 10);
            product.DecreaseStock(15);
            Assert.That(product.StockAmount, Is.EqualTo(10));
        }

        // 14.Test for decreasing stock with amount as 0
        [Test]
        public void DecreaseStockWithZeroAmount_Test()
        {
            var product = new Product();
            product.TryCreateProduct(15, "Couch", 2500, 20);
            product.DecreaseStock(0);
            Assert.That(product.StockAmount, Is.EqualTo(20));
        }
        // 15. Test for valid stock increase within limits
        [Test]
        public void IncreaseStock_ValidAmount_Test()
        {
            var product = new Product();
            product.TryCreateProduct(20, "Mouse", 50, 100);
            product.IncreaseStock(200);
            Assert.That(product.StockAmount, Is.EqualTo(300));
        }

        // 16. Test for invalid stock increase exceeding maximum limit
        [Test]
        public void IncreaseStock_ExceedingLimit_Test()
        {
            var product = new Product();
            product.TryCreateProduct(25, "Monitor", 300, 499900);
            product.IncreaseStock(2000);
            Assert.That(product.StockAmount, Is.EqualTo(501900));
        }

        // 17. Test for decreasing stock to exactly zero
        [Test]
        public void DecreaseStockToZero_Test()
        {
            var product = new Product();
            product.TryCreateProduct(30, "Headphones", 80, 15);
            product.DecreaseStock(15);
            Assert.That(product.StockAmount, Is.EqualTo(0));
        }

        // 18. Test for decreasing stock with a negative amount (should remain unchanged)
        [Test]
        public void DecreaseStock_NegativeAmount_Test()
        {
            var product = new Product();
            product.TryCreateProduct(35, "Smartwatch", 200, 50);
            product.DecreaseStock(-10);
            Assert.That(product.StockAmount, Is.EqualTo(50));
        }
    }
}
