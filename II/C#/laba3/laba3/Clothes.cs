using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Clothes : Product, IName
    {
        protected string material;
        protected string countryOfOrigin;

        public Clothes()
        {
            material = " ";
            countryOfOrigin = " ";
        }
        public Clothes(string name, double price, string material, string countryOfOrigin) : base(name, price)
        {
            this.material = material;
            this.countryOfOrigin = countryOfOrigin;
        }

        public string CountryOfOrigin
        {
            get
            {
                return countryOfOrigin;
            }
            set
            {
                countryOfOrigin = value;
            }
        }

        public string Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Material:{material}, Contry:{countryOfOrigin}";
        }
    }
}