//Assignment2
// Created by :Group-11

using Group11_Assignment2;
using Group11_Assignment2Tests;
using NUnit.Framework;


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

        // 4.Test for invalid product name (empty string)

        [Test]
        public void InvalidProductName_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "", 1000, 200);
            Assert.That(result, Is.False);
            Assert.That(product.ProductName, Is.EqualTo("Unknown"));
        }

        // 5.Test for valid product creation
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

        // 6.Test for invalid item price less than 5
        [Test]
        public void InvalidItemPriceLessThan5_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "Pen", 4, 100);
            Assert.That(result, Is.False);
            Assert.That(product.ItemPrice, Is.EqualTo(0));
        }

        // 7.Test for invalid item price greater than 5000
        [Test]
        public void InvalidItemPriceGreaterThan5000_Test()
        {
            var product = new Product();
            bool result = product.TryCreateProduct(10, "Laptop", 5001, 100);
            Assert.That(result, Is.False);
            Assert.That(product.ItemPrice, Is.EqualTo(0));
        }

        // 8.Test for stock increase functionality
        [Test]
        public void IncreaseStock_Test()
        {
            var product = new Product();
            product.TryCreateProduct(10, "Table", 1000, 10);
            product.IncreaseStock(5);
            Assert.That(product.StockAmount, Is.EqualTo(15));
        }
        // 9.Test for stock decrease functionality
        [Test]
        public void DecreaseStock_Test()
        {
            var product = new Product();
            product.TryCreateProduct(10, "Chair", 500, 10);
            product.DecreaseStock(3);
            Assert.That(product.StockAmount, Is.EqualTo(7));
        }
        // 10.Test for decreasing stock with invalid amount (more than available)

        [Test]
        public void DecreaseStockWithInvalidAmount_Test()
        {
            var product = new Product();
            product.TryCreateProduct(10, "Couch", 1200, 10);
            product.DecreaseStock(15); 
            Assert.That(product.StockAmount, Is.EqualTo(10)); 
        }
    }
}
