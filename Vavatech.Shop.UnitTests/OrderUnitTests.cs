using System;
using Vavatech.Shop.Models;
using Xunit;

namespace Vavatech.Shop.UnitTests
{
    public class OrderUnitTests
    {
        [Fact]
        public void CreateOrderTest1()
        {
            // Arrange
            Customer customer = new Customer(1, "Sulecki");

            // Acts
            Order order = Order.Create(customer);

            // Asserts
            Assert.NotNull(order.Customer);
            Assert.Equal(DateTime.Today, order.OrderDate.Date);
            Assert.Equal(OrderStatus.Draft, order.Status);
            Assert.Null(order.DeliveryDate);
        }
    }

    
}
