using System;
using System.Collections.Generic;

namespace Vavatech.Shop.Models
{

    public class Order : Base
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }

        public Customer Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public List<OrderDetail> Details { get; set; }
    }


    public class OrderDetail : Base
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalAmount
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }


}
