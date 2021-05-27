using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurryLounge.Checkout
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NVPAPICaller caller = new NVPAPICaller();
            string token = "";
            string retMsg = "";

            if (Session["payment_amt"] != null)
            {
                string amt = Session["payment_amt"].ToString();
                bool ret = caller.ShortcutExpressCheckout(amt, ref token, ref retMsg);
                if (ret)
                {
                    Session["token"] = token;
                    Response.Redirect(retMsg);
                }
                else
                {
                    Response.Redirect("ErrorCheckout.aspx?" + retMsg);
                }
            }
            else
            {
                Response.Redirect("ErrorCheckout.aspx?Error=AmtMissing");
            }
        }
    }
}