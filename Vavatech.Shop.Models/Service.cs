namespace Vavatech.Shop.Models
{
    public class Service : Item
    {
        public Service()
            : base()
        {

        }

        public Service(string name, decimal unitPrice) 
            : base(name, unitPrice)
        {
        }
    }

}
