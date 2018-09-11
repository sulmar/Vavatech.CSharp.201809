using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.Extensions
{
    public class DateTimeHelper
    {
        public static bool CanShopping(DateTime dateTime)
        {
            return dateTime.DayOfWeek != DayOfWeek.Sunday;
        }
    }


    public static class DateTimeExtensions
    {
        public static bool CanShopping(this DateTime dateTime)
        {
            return dateTime.DayOfWeek != DayOfWeek.Sunday;
        }
    }


    public static class ListExtensions
    {
        public static int GetIndex<T>(this List<T> list, T entity)
        {
            return list.IndexOf(entity) + 1;
        }
    }

}
