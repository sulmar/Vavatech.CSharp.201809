using System;
using System.Collections.Generic;

namespace Vavatech.Shop.Models
{

    public partial class Order : Base
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }

        public Customer Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public List<OrderDetail> Details { get; set; }

        public OrderStatus Status { get; set; }

        public RoomStatus RoomStatus { get; set; }

    }


    [Flags]
    public enum RoomStatus
    {
        L1 = 2^3,
        L2 = 2^2,
        P =  2^1,   
        O =  2^0, 
    }


    // Typ wyliczeniowy
    public enum OrderStatus
    {
        Draft,
        Created,
        Canceled,
        Sent,
        Delivered
    }


}
