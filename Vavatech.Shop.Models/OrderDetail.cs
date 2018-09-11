using System;

namespace Vavatech.Shop.Models
{
    public class OrderDetail : Base
    {
        public OrderDetail(Item item, int quantity)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            Quantity = quantity;

            UnitPrice = item.UnitPrice;
        }

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
