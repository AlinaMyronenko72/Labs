using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Dress : Clothes,IName<Dress>
    {
        private string typeOfSkirt;

        public Dress()
        {
            typeOfSkirt = " ";
        }
        public Dress(string name, double price, string material, string countryOfOrigin, string typeOfSkirt) : base(name, price, material, countryOfOrigin)
        {
            this.typeOfSkirt = typeOfSkirt;
            
        }

        public string TypeOfSkirt
        {
            get
            {
                return typeOfSkirt;
            }
            set
            {
                typeOfSkirt = value;
            }
        }

        public int CompareTo(Dress other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()},Skirt:{typeOfSkirt}";
        }
    }
}