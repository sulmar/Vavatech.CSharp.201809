using System;

namespace Vavatech.Shop.Models
{
    public class Customer : Base
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string lastName)
            : this()
        {
            this.Id = id;
            this.LastName = lastName;
        }



        private decimal salary;

        public decimal Salary
        {
            get
            {
                return salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Wartość nie może być ujemna");
                }
                this.salary = value;
            }
        }


        public string Address { get; set; }

        public string FullName
        {
            get
            {
                // return string.Format("{0} {2}", FirstName, LastName);
                return $"{FirstName} {LastName}";
            }
        }

        public override string ToString() => FullName;


        //public decimal GetSalary()
        //{
        //    return salary;
        //}

        //public void SetSalary(decimal value)
        //{
        //    if (value<0)
        //    {
        //        throw new Exception("Wartość nie może być ujemna");
        //    }
        //    this.salary = value;
        //}


    }

}
