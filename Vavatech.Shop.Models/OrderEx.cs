using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.Models
{
    public partial class Order : Base
    {
        public Order(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            Details = new List<OrderDetail>();

            this.OrderDate = DateTime.Today;
            this.Customer = customer;
        }

        public static Order Create(Customer customer)
        {
            return new Order(customer);
        }

        public void AddDetail(OrderDetail detail)
        {
            this.Details.Add(detail);
        }
    }
}
