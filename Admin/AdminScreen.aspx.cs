using CurryLounge.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurryLounge.Admin
{
    public partial class AdminScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string actionProduct = Request.QueryString["ProductAction"];
            if (actionProduct == "add")
            {
                LabelAddStatus.Text = "Product is added!";
            }

            if (actionProduct == "remove")
            {
                LabelRemoveStatus.Text = "Product is removed!";
            }
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Images/");
            if (ProductImage.HasFile)
            {
                String fileExt = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
                String[] allowedExt = { ".jpeg", ".jpg", ".png" , ".gif" };
                for (int i = 0; i < allowedExt.Length; i++)
                {
                    if (fileExt == allowedExt[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    ProductImage.PostedFile.SaveAs(path + ProductImage.FileName);
                    ProductImage.PostedFile.SaveAs(path + "Thumbs/" + ProductImage.FileName);
                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }

                // Add product data to DB.
                AddProducts p = new AddProducts();
                bool addSuccess = p.AddProduct(AddProductName.Text, AddProductDescription.Text,
                    AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName);
                if (addSuccess)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Cannot add new product to database.";
                }
            }
            else
            {
                LabelAddStatus.Text = "Cannot accept file type.";
            }
        }

        public IQueryable GetCategories()
        {
            var db = new CurryLounge.Models.ProductContext();
            IQueryable q = db.Categories;
            return q;
        }

        public IQueryable GetProducts()
        {
            var db = new CurryLounge.Models.ProductContext();
            IQueryable q = db.Products;
            return q;
        }

        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {
            using (var db = new CurryLounge.Models.ProductContext())
            {
                int productId = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
                var item = (from x in db.Products where x.ProductID == productId select x).FirstOrDefault();
                if (item != null)
                {
                    db.Products.Remove(item);
                    db.SaveChanges();

                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Cannot locate product.";
                }
            }
        }
    }
}