using System;

namespace Vavatech.Shop.Models
{
    public abstract class Item : Base
    {
        public Item()
        {

        }

        protected Item(string name, decimal unitPrice)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UnitPrice = unitPrice;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string EAN { get; set; }
        public string Discriminator { get; set; }


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
