using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopcartLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopcartLibrary.Tests
{
    [TestClass()]
    public class ShoppingCartInitializeTests
    {
        private static ShoppingCart cart;
        private static Product product;
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            product = new Product { Name = "Мяч", Category = "Футбол", Price = 19.50M };

            Product[] products =
             {
                new Product { Name = "Каяк", Category = "Водные виды спорта", Price = 275M },
                new Product { Name = "Спасательный жилет", Category = "Водные виды спорта", Price = 48.95M },
                new Product { Name = "Мяч", Category = "Футбол", Price = 19.50M },
                new Product { Name = "Угловой флажок", Category = "Футбол", Price = 34.95M }
            };

            cart = new ShoppingCart(new LinqValueCalculator());
            cart.Products = products;
        }

        [TestMethod()]
        public void ShoppingCart_AllProductInstances_Product()
        {
            CollectionAssert.AllItemsAreInstancesOfType(cart.Products.ToArray(), typeof(Product));
        }
        [TestMethod]
        public void ShoppingCart_AllProducts_Unique()
        {
            CollectionAssert.AllItemsAreUnique(cart.Products.ToArray());
        }
        [TestMethod]
        public void ShoppingCart_AllProducts_NotNull()
        {
            CollectionAssert.AllItemsAreNotNull(cart.Products.ToArray());
        }
        [TestMethod]
        public void ShoppingCart_ProductsContains_Product()
        {
            // Using Contains extension method requires 
            // implementation of IEquitable<Product> in class Product
            // method bool Equals(Product other) should be defined
            CollectionAssert.Contains(cart.Products.ToList(), product);
        }
        [TestMethod]
        public void ShoppingCart_AddProduct_Added()
        {
            Product item = new Product()
            {
                Name = "Bicycle",
                Category = "Cycling",
                Price = 2566.3M
            };
            int expected = cart.Products.Count() + 1;
            // Add item to (IEnumerable<Product>) Products
            // In fact, new IEnumerable<Product> object will be created
            cart.Products=cart.Products.Concat(new[] {item });

            Assert.AreEqual(expected, cart.Products.Count());
        }
        [TestMethod]
        public void ShoppingCart_RemoveProduct_Removed()
        {
            Product item2 = new Product { Name = "Каяк", Category = "Водные виды спорта", Price = 275M };
            int expected = cart.Products.Count() - 1;
            // Remove item from (IEnumerable<Product>) Products
            // Returns a new collection that doesn't contain the excluded items
            
            // Requires implementation of IEqualityComparer<Product>

            cart.Products = cart.Products.Except(new[] { item2 });
            Assert.AreEqual(expected, cart.Products.Count());
        }
    }
}
