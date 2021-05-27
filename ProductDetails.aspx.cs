using CurryLounge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurryLounge
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProducts([QueryString("productID")] int? productId)
        {
            var db = new CurryLounge.Models.ProductContext();
            IQueryable<Product> q = db.Products;
            if (productId.HasValue && productId > 0)
            {
                q = q.Where(x => x.ProductID == productId);
            }
            else
            {
                q = null;
            }
            return q;
        }
    }
}