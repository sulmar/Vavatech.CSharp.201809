using System;

namespace Vavatech.Shop.Models
{
    public class Product : Item
    {
        public Product(string name, decimal unitPrice, string color)
            : base(name, unitPrice)
        {
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string Color { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {Color}";
        }

        public void Print()
        {
            System.Console.WriteLine("barcode product");
        }
    }

}
