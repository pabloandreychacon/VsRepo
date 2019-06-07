using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public partial class Item
    {
        public virtual List<OrderDetail> OrderDetailsList { get; set; }
    }
}