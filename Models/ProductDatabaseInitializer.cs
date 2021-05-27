using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurryLounge.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(x => context.Categories.Add(x));
            GetProducts().ForEach(x => context.Products.Add(x));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Appetisers"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Main Dishes"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Desserts"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Drink"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Extras"
                }
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Lamb Samosa",
                    Description = "Crispy triangular pastry filled with minced lamb and spices.",
                    ImagePath="Samosa.jpg",
                    UnitPrice = 6.50,
                    CategoryID = 1
               },
              new Product
                {
                    ProductID = 2,
                    ProductName = "Chicken Samosa",
                    Description = "Crispy triangular pastry filled with chicken and spices.",
                    ImagePath="Samosa.jpg",
                    UnitPrice = 6.50,
                    CategoryID = 1
               },
              new Product
                {
                    ProductID = 3,
                    ProductName = "Vegetable Samosa",
                    Description = "Crispy triangular pastry filled with spiced vegetables.",
                    ImagePath="Samosa.jpg",
                    UnitPrice = 6.50,
                    CategoryID = 1
               },
              new Product
                {
                    ProductID = 4,
                    ProductName = "Seekh Kebab",
                    Description = "Minced lamb cooked with spices.",
                    ImagePath="Seekh.jpg",
                    UnitPrice = 7.50,
                    CategoryID = 1
               },
              new Product
                {
                    ProductID = 5,
                    ProductName = "Tandoori Chicken",
                    Description = "Pieces of chicken marinated in a Tandoori spices",
                    ImagePath="TandooriC.jpg",
                    UnitPrice = 7.50,
                    CategoryID = 1
               },
              new Product
                {
                    ProductID = 6,
                    ProductName = "Tandoori Shrimp",
                    Description = "Shrimp marinated in a Tandoori spices.",
                    ImagePath="TandooriS.jpg",
                    UnitPrice = 7.50,
                    CategoryID = 1
               },
               new Product
               {
                    ProductID = 7,
                    ProductName = "Chicken Bhuna",
                    Description = "Chicken cooked in tomatoes, garlic, onion and coriander. Spice Level: Medium.",
                    ImagePath="BhunaC.jpg",
                    UnitPrice = 11.95,
                    CategoryID = 2
               },
               new Product
               {
                    ProductID = 8,
                    ProductName = "Chicken Khorma",
                    Description = "Chicken slow-cooked in a coconut sauce with spices. Spice Level: Mild.",
                    ImagePath="KhormaC.jpg",
                    UnitPrice = 11.95,
                    CategoryID = 2
               },
               new Product
               {
                    ProductID = 9,
                    ProductName = "Chicken Madras",
                    Description = "Chicken cooked in red chillies, garlic and coriander. Spice Level: Hot.",
                    ImagePath="MadrasC.jpg",
                    UnitPrice = 11.95,
                    CategoryID = 2
               },
               new Product
               {
                    ProductID = 10,
                    ProductName = "Lamb Bhuna",
                    Description = "Lamb cooked in tomatoes, garlic, onion and coriander. Spice Level: Medium.",
                    ImagePath="BhunaL.jpg",
                    UnitPrice = 11.95,
                    CategoryID = 2
               },
               new Product
               {
                    ProductID = 11,
                    ProductName = "Lamb Khorma",
                    Description = "Lamb slow-cooked in a coconut sauce with spices. Spice Level: Mild.",
                    ImagePath="KhormaL.jpg",
                    UnitPrice = 11.95,
                    CategoryID = 2
               },
               new Product
               {
                    ProductID = 12,
                    ProductName = "Lamb Madras",
                    Description = "Lamb cooked in red chillies, garlic and coriander. Spice Level: Hot.",
                    ImagePath="MadrasL.jpg",
                    UnitPrice = 11.95,
                    CategoryID = 2
               },
               new Product
               {
                    ProductID = 13,
                    ProductName = "Ras Malai",
                    Description = "A cold dessert which consists of flattened balls of chhana soaked in malai (clotted cream) flavoured with cardamom.",
                    ImagePath="Rasmalai.jpg",
                    UnitPrice = 6.95,
                    CategoryID = 3
               },
               new Product
               {
                    ProductID = 14,
                    ProductName = "Gulab Jamun",
                    Description = "Milk dumplings, soaked in a sugar syrup. Served Hot.",
                    ImagePath="GulabJamun.jpg",
                    UnitPrice = 6.95,
                    CategoryID = 3
               },
               new Product
               {
                    ProductID = 15,
                    ProductName = "Still Water",
                    Description = "Soft drink.",
                    ImagePath="Water.jpg",
                    UnitPrice = 4.00,
                    CategoryID = 4
               },
               new Product
               {
                    ProductID = 16,
                    ProductName = "Sparkling Mineral Water",
                    Description = "Soft drink.",
                    ImagePath="WaterS.jpg",
                    UnitPrice = 4.00,
                    CategoryID = 4
               },
               new Product
               {
                    ProductID = 17,
                    ProductName = "Coke",
                    Description = "Soft drink.",
                    ImagePath="",
                    UnitPrice = 4.00,
                    CategoryID = 4
               },
               new Product
               {
                    ProductID = 18,
                    ProductName = "Poppadom",
                    Description = "Classic Poppadom.",
                    ImagePath="Poppadom.jpg",
                    UnitPrice = 0.99,
                    CategoryID = 5
               },
               new Product
               {
                    ProductID = 19,
                    ProductName = "Pickle Onion",
                    Description = "Small cup of chopped pickle onion.",
                    ImagePath="PickleOnion.jpg",
                    UnitPrice = 0.99,
                    CategoryID = 5
               },
               new Product
               {
                    ProductID = 20,
                    ProductName = "Mint Chutney",
                    Description = "SMint yogurt sauce.",
                    ImagePath="Mint.jpg",
                    UnitPrice = 0.99,
                    CategoryID = 5
               },
               new Product
               {
                    ProductID = 21,
                    ProductName = "Mango Chutney",
                    Description = "Sweet mango sauce.",
                    ImagePath="ChutneyM.jpg",
                    UnitPrice = 0.99,
                    CategoryID = 5
               },
               new Product
               {
                    ProductID = 22,
                    ProductName = "Boiled Rice",
                    Description = "Plain boiled basmati rice",
                    ImagePath="RiceB.jpg",
                    UnitPrice = 2.99,
                    CategoryID = 5
               },
               new Product
               {
                    ProductID = 23,
                    ProductName = "Pilau Rice",
                    Description = "Basmati rice flavoured with saffron",
                    ImagePath="",
                    UnitPrice = 2.99,
                    CategoryID = 5
               },
               new Product
               {
                    ProductID = 24,
                    ProductName = "Plain Naan",
                    Description = "Traditional Naan bread",
                    ImagePath="Naan.jpg",
                    UnitPrice = 2.99,
                    CategoryID = 5
               },
               new Product
               {
                    ProductID = 25,
                    ProductName = "Roti",
                    Description = "Traditional indian bread with whole wheat flour",
                    ImagePath="Roti.jpg",
                    UnitPrice = 2.99,
                    CategoryID = 5
               }
            };

            return products;
        }

    }
}
