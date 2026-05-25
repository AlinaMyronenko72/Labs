using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Dress : Clothes,IName
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

        public override string ToString()
        {
            return $"{base.ToString()},Skirt:{typeOfSkirt}";
        }
    }
}