using CurryLounge.Logic;
using CurryLounge.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurryLounge
{
    public partial class ShoppingBasket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingBasketActions usersShoppingBasket = new ShoppingBasketActions())
            {
                decimal basketTotal = 0;
                basketTotal = usersShoppingBasket.GetTotal();
                if (basketTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", basketTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingBasketTitle.InnerText = "Shopping orders is Empty";
                    UpdateBtn.Visible = false;
                    CheckoutImageBtn.Visible = false;
                }
            }
        }

        public List<BasketItem> GetShoppingBasketItems()
        {
            ShoppingBasketActions actions = new ShoppingBasketActions();
            return actions.GetBasketItems();
        }

        public List<BasketItem> UpdateBasketItems()
        {
            using (ShoppingBasketActions usersShoppingBasket = new ShoppingBasketActions())
            {
                String basketId = usersShoppingBasket.GetBasketId();

                ShoppingBasketActions.ShoppingBasketUpdates[] basketUpdates = new ShoppingBasketActions.ShoppingBasketUpdates[BasketList.Rows.Count];
                for (int i = 0; i < BasketList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(BasketList.Rows[i]);
                    basketUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)BasketList.Rows[i].FindControl("Remove");
                    basketUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)BasketList.Rows[i].FindControl("PurchaseQuantity");
                    basketUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingBasket.UpdateShoppingBasketDatabase(basketId, basketUpdates);
                BasketList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingBasket.GetTotal());
                return usersShoppingBasket.GetBasketItems();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateBasketItems();
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            using (ShoppingBasketActions shoppingBasket = new ShoppingBasketActions())
            {
                Session["payment_amt"] = shoppingBasket.GetTotal();
            }
            Response.Redirect("Checkout/Checkout.aspx");
        }

    }
}