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
        [ClassInitialize]
        public static void ShoppingCartInitializer(TestContext context)
        {
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
        public void ShoppingCart_AllProducts_
    }
}
