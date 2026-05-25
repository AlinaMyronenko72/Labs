using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Glasses : Accessory, IName
    {
        private string typeOfRim;

        public Glasses()
        {
            typeOfRim = " ";
        }
        public Glasses(string name, double price, string brand, string color, string typeOfRim) : base(name,price,brand, color)
        {
            this.typeOfRim = typeOfRim;
            
        }

        public string TypeOfRim
        {
            get
            {
                return typeOfRim;
            }
            set
            {
                typeOfRim = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Rim:{typeOfRim}";
        }
    }
}