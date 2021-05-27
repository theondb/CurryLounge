using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CurryLounge.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public System.DateTime OrderDate { get; set; }

        public string Username { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Field is required: First Name")]
        [StringLength(200)]
        public string Firstname { get; set; }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Field is required: Surname")]
        [StringLength(200)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Field is required: Address")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Field is required: City")]
        [StringLength(50)]
        public string City { get; set; }

        //[Required(ErrorMessage = "Field is required: County")]
        //[StringLength(50)]
        //public string County { get; set; }

        [Required(ErrorMessage = "Field is required: Postcode")]
        [StringLength(10)]
        public string Postcode { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Field is required: Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email address is invalid.") ]
        public string Email { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public string TransactionId { get; set; }

        [ScaffoldColumn(false)]
        public bool HasBeenDelivered { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }


    }
}