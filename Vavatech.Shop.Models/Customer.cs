using System;

namespace Vavatech.Shop.Models
{
    public class Customer : Base
    {
        #region Properties

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }


        public Address WorkAddress { get; set; }
        public Address HomeAddress { get; set; }


        #endregion

        public Customer()
        {

        }

        public Customer(int id, string lastName)
            : this()
        {
            this.Id = id;
            this.LastName = lastName;
        }


        #region Salary
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

        #endregion


        public string FullName
        {
            get
            {
                // return string.Format("{0} {2}", FirstName, LastName);
                return $"{Id} {VatNumber} {FirstName} {LastName}";
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
