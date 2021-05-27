using CurryLounge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurryLounge.Checkout
{
    public partial class ReadCheckout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NVPAPICaller caller = new NVPAPICaller();
                string retMsg = "";
                string token = "";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();
                token = Session["token"].ToString();

                bool ret = caller.GetCheckoutDetails(token, ref PayerID, ref decoder, ref retMsg);
                if (ret)
                {
                    Session["payerId"] = PayerID;

                    var order = new Order();
                    order.OrderDate = Convert.ToDateTime(decoder["TIMESTAMP"].ToString());
                    order.Username = User.Identity.Name;
                    order.Firstname = decoder["FIRSTNAME"].ToString();
                    order.Surname = decoder["LASTNAME"].ToString();
                    order.Address = decoder["SHIPTOSTREET"].ToString();
                    order.City = decoder["SHIPTOCITY"].ToString();
                    //order.County = decoder["SHIPTOSTATE"].ToString();
                    order.Postcode = decoder["SHIPTOZIP"].ToString();
                    //order.Country = decoder["SHIPTOCOUNTRYCODE"].ToString();
                    order.Email = decoder["EMAIL"].ToString();
                    order.Total = Convert.ToDecimal(decoder["AMT"].ToString());

                    // Verify total payment amount as set on Checkout.aspx.
                    try
                    {
                        decimal paymentAmountOnCheckout = Convert.ToDecimal(Session["payment_amt"].ToString());
                        decimal paymentAmoutFromPayPal = Convert.ToDecimal(decoder["AMT"].ToString());
                        if (paymentAmountOnCheckout != paymentAmoutFromPayPal)
                        {
                            Response.Redirect("ErrorCheckout.aspx?" + "Desc=Amount%20total%20mismatch.");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("ErrorCheckout.aspx?" + "Desc=Amount%20total%20mismatch.");
                    }

                    // Get DB context.
                    ProductContext db = new ProductContext();

                    // Add order to DB.
                    db.Orders.Add(order);
                    db.SaveChanges();

                    // Get the shopping cart items and process them.
                    using (CurryLounge.Logic.ShoppingBasketActions shoppingBasket = new CurryLounge.Logic.ShoppingBasketActions())
                    {
                        List<BasketItem> userOrderList = shoppingBasket.GetBasketItems();

                        // Add OrderDetail information to the DB for each product purchased.
                        for (int i = 0; i < userOrderList.Count; i++)
                        {
                            // Create a new OrderDetail object.
                            var orderDetail = new OrderDetails();
                            orderDetail.OrderId = order.OrderId;
                            orderDetail.Username = User.Identity.Name;
                            orderDetail.ProductId = userOrderList[i].ProductId;
                            orderDetail.Quantity = userOrderList[i].Quantity;
                            orderDetail.UnitPrice = userOrderList[i].Product.UnitPrice;

                            // Add OrderDetail to DB.
                            db.OrderDetails.Add(orderDetail);
                            db.SaveChanges();
                        }

                        // Set OrderId.
                        Session["currentOrderId"] = order.OrderId;

                        // Display Order information.
                        List<Order> orderList = new List<Order>();
                        orderList.Add(order);
                        DeliveryInfo.DataSource = orderList;
                        DeliveryInfo.DataBind();

                        // Display OrderDetails.
                        OrderItemList.DataSource = userOrderList;
                        OrderItemList.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?" + retMsg);
                }
            }
        }

        protected void CheckoutConfirm_Click(object sender, EventArgs e)
        {
            Session["userCheckoutCompleted"] = "true";
            Response.Redirect("~/Checkout/CompleteCheckout.aspx");
        }
    }    
    
}