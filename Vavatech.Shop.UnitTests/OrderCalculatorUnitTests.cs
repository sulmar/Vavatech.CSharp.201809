using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Xunit;

namespace Vavatech.Shop.UnitTests
{
    public class OrderCalculatorUnitTests
    {
        [Fact]
        public void CalculateTest()
        {
            // Arrange
            Customer customer = new Customer(1, "Sulecki");
            Order order = Order.Create(customer);

            Product product = new Product("Mouse", 100, "Red");
            Service service = new Service("Developing", 100);

            order.AddDetail(new OrderDetail(product, 10));
            order.AddDetail(new OrderDetail(service, 4));

            IOrderCalculator calculator = new OrderCalculator();

            // Acts
            decimal result = calculator.Calculate(order);

            // Asserts
            Assert.True(result > 0);
            Assert.Equal(1400, result);

            // Polecam: Install-Package FluentAssertions

        }

        [Fact]
        public void CalculateDiscountTest()
        {
            // Arrange
            Customer customer = new Customer(1, "Sulecki");
            Order order = Order.Create(customer);
            order.OrderDate = DateTime.Parse("2018-09-14");

            Product product = new Product("Mouse", 100, "Red");
            Service service = new Service("Developing", 100);

            order.AddDetail(new OrderDetail(product, 10));
            order.AddDetail(new OrderDetail(service, 4));

            IOrderCalculator calculator = new OrderCalculator();

            // Acts
            decimal result = calculator.Calculate(order);

            // Asserts
            Assert.True(result > 0);
            Assert.Equal(1260, result);

            // Polecam: Install-Package FluentAssertions

        }


        [Fact]
        public void CalculateDiscount2Test()
        {
            // Arrange
            Customer customer = new Customer(1, "Sulecki");
            Order order = Order.Create(customer);
            order.OrderDate = DateTime.Parse("2018-09-14");

            Product product = new Product("Mouse", 100, "Red");
            Service service = new Service("Developing", 100);

            order.AddDetail(new OrderDetail(product, 10));
            order.AddDetail(new OrderDetail(service, 4));

            ICanDiscountStrategy canDiscount = new HappyDayDiscountStrategy(DayOfWeek.Friday);
            IDiscountStrategy discount = new PercentageDiscountStrategy(0.1m);

            IOrderCalculator calculator = new OrderCalculator2(canDiscount, discount);

            // Acts
            decimal result = calculator.Calculate(order);

            // Asserts
            Assert.True(result > 0);
            Assert.Equal(1260, result);

            // Polecam: Install-Package FluentAssertions

        }


        [Fact]
        public void CalculateDiscount3Test()
        {
            // Arrange
            Customer customer = new Customer(1, "Sulecki");
            Order order = Order.Create(customer);
            order.OrderDate = DateTime.Parse("2018-09-14");

            Product product = new Product("Mouse", 100, "Red");
            Service service = new Service("Developing", 100);

            order.AddDetail(new OrderDetail(product, 10));
            order.AddDetail(new OrderDetail(service, 4));

            ICanDiscountStrategy canDiscount = new OverLimitDiscountStrategy(1000);
            IDiscountStrategy discount = new PercentageDiscountStrategy(0.1m);

            IOrderCalculator calculator = new OrderCalculator2(canDiscount, discount);

            // Acts
            decimal result = calculator.Calculate(order);

            // Asserts
            Assert.True(result > 0);
            Assert.Equal(1260, result);

            // Polecam: Install-Package FluentAssertions

        }
    }
}
