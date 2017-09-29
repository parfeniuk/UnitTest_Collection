using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopcartLibrary
{
    public class Product: EqualityComparer<Product>, IEquatable<Product>
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Product prod = obj as Product;
            if (prod == null) return false;
            else return Equals(prod);
        }

        public bool Equals(Product other)
        {
            if (other == null) return false;
            return Name == other.Name && Price == other.Price && Category == other.Category;
        }

        public override bool Equals(Product x, Product y)
        {
            if (x == null && y == null) return true;
            else if (x == null || y == null) return false;

            if (x.Equals(y)) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return GetHashCode(this);
        }

        public override int GetHashCode(Product obj)
        {
            return obj.Price.GetHashCode() ^ obj.Category.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
}
