using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CurryLounge.Models
{
    public class BasketItem
    {
        [Key]
        public string ItemId { get; set; }

        public string BasketId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }


    }
}