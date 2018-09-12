using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.Models.SearchCriteria
{

    public abstract class SearchCriteria
    {

    }


    //public class PeriodSearchCriteria : SearchCriteria
    //{
    //    public DateTime? From { get; set; }
    //    public DateTime? To { get; set; }
    //}

    //public class AmountSearchCriteria
    //{
    //    public decimal? From { get; set; }
    //    public decimal? To { get; set; }
    //}

    public class Range<T>
       where T : struct // constrain
    { 
        public T? From { get; set; }
        public T? To { get; set; }
    }

    public class OrderSearchCriteria 
    {
        public Range<DateTime> Period { get; set; }
        public Range<decimal> Amount { get; set; }

    }

    public class CustomerSearchCriteria : SearchCriteria
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
