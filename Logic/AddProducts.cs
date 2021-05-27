using CurryLounge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurryLounge.Logic
{
    public class AddProducts
    {
        public bool AddProduct(string Name, string Desc, string Price, string Category, string ImagePath)
        {
            var product = new Product
            {
                ProductName = Name,
                Description = Desc,
                UnitPrice = Convert.ToDouble(Price),
                ImagePath = ImagePath,
                CategoryID = Convert.ToInt32(Category)
            };

            using (ProductContext db = new ProductContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            return true;
        }
    }
}