using CurryLounge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurryLounge.Logic
{
    public class ShoppingBasketActions : IDisposable
    {
        public string ShoppingBasketId { get; set; }

        private ProductContext db = new ProductContext();

        public const string BasketSessionKey = "BasketId";

        public void AddToBasket(int id)
        {
            // Retrieve the product from the database.           
            ShoppingBasketId = GetBasketId();

            var basketItem = db.ShoppingBasketItems.SingleOrDefault(
                x => x.BasketId == ShoppingBasketId
                && x.ProductId == id);
            if (basketItem == null)
            {
                basketItem = new BasketItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    BasketId = ShoppingBasketId,
                    Product = db.Products.SingleOrDefault(
                   p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                db.ShoppingBasketItems.Add(basketItem);
            }
            else
            {
                basketItem.Quantity++;
            }
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }

        public string GetBasketId()
        {
            if (HttpContext.Current.Session[BasketSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[BasketSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempBasketId = Guid.NewGuid();
                    HttpContext.Current.Session[BasketSessionKey] = tempBasketId.ToString();
                }
            }
            return HttpContext.Current.Session[BasketSessionKey].ToString();
        }

        public List<BasketItem> GetBasketItems()
        {
            ShoppingBasketId = GetBasketId();

            return db.ShoppingBasketItems.Where(
                x => x.BasketId == ShoppingBasketId).ToList();
        }

        public decimal GetTotal()
        {
            ShoppingBasketId = GetBasketId();
            decimal? total = decimal.Zero;
            total = (decimal?)(from basketItems in db.ShoppingBasketItems
                               where basketItems.BasketId == ShoppingBasketId
                               select (int?)basketItems.Quantity *
                               basketItems.Product.UnitPrice).Sum();
            return total ?? decimal.Zero;
        }

        public ShoppingBasketActions GetBasket(HttpContext context)
        {
            using (var basket = new ShoppingBasketActions())
            {
                basket.ShoppingBasketId = basket.GetBasketId();
                return basket;
            }
        }

        public void UpdateShoppingBasketDatabase(String basketId, ShoppingBasketUpdates[] BasketItemUpdates)
        {
            using (var db = new CurryLounge.Models.ProductContext())
            {
                try
                {
                    int BasketItemCount = BasketItemUpdates.Count();
                    List<BasketItem> myBasket = GetBasketItems();
                    foreach (var basketItem in myBasket)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < BasketItemCount; i++)
                        {
                            if (basketItem.Product.ProductID == BasketItemUpdates[i].ProductId)
                            {
                                if (BasketItemUpdates[i].PurchaseQuantity < 1 || BasketItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(basketId, basketItem.ProductId);
                                }
                                else
                                {
                                    UpdateItem(basketId, basketItem.ProductId, BasketItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Cannot update Basket Database: " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeBasketID, int removeProductID)
        {
            using (var db = new CurryLounge.Models.ProductContext())
            {
                try
                {
                    var myItem = (from x in db.ShoppingBasketItems where x.BasketId == removeBasketID && x.Product.ProductID == removeProductID select x).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        db.ShoppingBasketItems.Remove(myItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Cannot remove order item: " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateBasketID, int updateProductID, int quantity)
        {
            using (var db = new CurryLounge.Models.ProductContext())
            {
                try
                {
                    var myItem = (from x in db.ShoppingBasketItems where x.BasketId == updateBasketID && x.Product.ProductID == updateProductID select x).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantity = quantity;
                        db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Cannot update order item: " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyBasket()
        {
            ShoppingBasketId = GetBasketId();
            var basketItems = db.ShoppingBasketItems.Where(
                x => x.BasketId == ShoppingBasketId);
            foreach (var basketItem in basketItems)
            {
                db.ShoppingBasketItems.Remove(basketItem);
            }
            // Save changes.             
            db.SaveChanges();
        }

        public int GetCount()
        {
            ShoppingBasketId = GetBasketId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from basketItems in db.ShoppingBasketItems
                          where basketItems.BasketId == ShoppingBasketId
                          select (int?)basketItems.Quantity).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingBasketUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        public void MigrateBasket(string basketId, string username)
        {
            var shoppingBasket = db.ShoppingBasketItems.Where(x => x.BasketId == basketId);
            foreach (BasketItem basketItem in shoppingBasket)
            {
                basketItem.BasketId = username;
            }
            HttpContext.Current.Session[BasketSessionKey] = username;
            db.SaveChanges();
        }
    }
}