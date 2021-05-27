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
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Category> GetCategories()
        {
            var db = new CurryLounge.Models.ProductContext();
            IQueryable<Category> q = db.Categories;
            return q;
        }

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var db = new CurryLounge.Models.ProductContext();
            IQueryable<Product> q = db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                q = q.Where(x => x.CategoryID == categoryId);
            }
            return q;
        }
    }
}