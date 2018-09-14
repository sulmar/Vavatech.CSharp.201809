using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }

    public interface IDiscountStrategy
    {
        decimal Discount(Order order);
    }

    public class HappyDayDiscountStrategy : ICanDiscountStrategy
    {
        private DayOfWeek dayOfWeek;

        public HappyDayDiscountStrategy(DayOfWeek dayOfWeek)
        {
            this.dayOfWeek = dayOfWeek;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.DayOfWeek == dayOfWeek;
        }
    }

    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private decimal percentage;

        public PercentageDiscountStrategy(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal Discount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }

    public class OverLimitDiscountStrategy : ICanDiscountStrategy
    {
        private decimal limit;

        public OverLimitDiscountStrategy(decimal limit)
        {
            this.limit = limit;
        }

        public bool CanDiscount(Order order)
        {
            return order.TotalAmount > limit;
        }
    }

    // Wzorzec strategi
    public class OrderCalculator2 : IOrderCalculator
    {
        private ICanDiscountStrategy canDiscountStrategy;
        private IDiscountStrategy discountStrategy;

        public OrderCalculator2(
            ICanDiscountStrategy canDiscountStrategy, 
            IDiscountStrategy discountStrategy)
        {
            this.canDiscountStrategy = canDiscountStrategy;
            this.discountStrategy = discountStrategy;
        }

        public decimal Calculate(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order))
            {
                return order.TotalAmount - discountStrategy.Discount(order);
            }
            else
            {
                return order.TotalAmount;
            }


        }
    }

    public class OrderCalculator : IOrderCalculator
    {
        public decimal Bonus { get; private set; }

        public decimal Calculate(Order order)
        {
            HappyDay(order);
            HappyHours(order);



            return order.TotalAmount - Bonus;
        }

        private void HappyHours(Order order)
        {
            if (order.TotalAmount>1000)
            {
                Bonus += 10;
            }
        }

        private void HappyDay(Order order)
        {
            if (order.OrderDate.DayOfWeek == DayOfWeek.Friday)
            {
                Bonus = order.TotalAmount * 0.1m;
            }
        }
    }
}
