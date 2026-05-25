using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    public class CarnivalCostume : Clothes, IName
    {
        private string celebration;

        public CarnivalCostume()
        {
            celebration = " ";
        }
        public CarnivalCostume(string name, double price, string material, string countryOfOrigin, string celebration) : base(name, price, material, countryOfOrigin)
        {
            this.celebration = celebration;

        }

        public string Celebration
        {
            get
            {
                return celebration;
            }
            set
            {
                celebration = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()},Celebration:{celebration}";
        }
    }
}