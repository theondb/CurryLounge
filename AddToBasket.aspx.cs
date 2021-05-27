using CurryLounge.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurryLounge
{
    public partial class AddToBasket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingBasketActions usersShoppingBasket = new ShoppingBasketActions())
                {
                    usersShoppingBasket.AddToBasket(Convert.ToInt16(rawId));
                }

            }
            else
            {
                Debug.Fail("AddToBasket.aspx is unaccessible without a ProductId.");
                throw new Exception("Cannot load AddToBasket.aspx without a ProductId.");
            }
            Response.Redirect("ShoppingBasket.aspx");
        }
    }
}