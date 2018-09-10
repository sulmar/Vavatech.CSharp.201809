using System;

namespace Vavatech.Shop.Models
{
    public abstract class Item : Base
    {
        protected Item(string name, decimal unitPrice)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UnitPrice = unitPrice;
        }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }


        public void Print()
        {
            System.Console.WriteLine("barcode item");
        }


        public override string ToString()
        {
            return $"{Name} {UnitPrice}";
        }

    }

}
