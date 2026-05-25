using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Accessory : Product, IName<Accessory>
    {
        protected string brand;
        protected string color;

        public Accessory()
        {
            brand = " ";
            color = " ";

        }
        public Accessory(string name, double price, string brand, string color) : base(name, price)
        {
            this.brand = brand;
            this.color = color;
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public int CompareTo(Accessory other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()},Brand:{brand}, Color:{color}";

        }
    }
}