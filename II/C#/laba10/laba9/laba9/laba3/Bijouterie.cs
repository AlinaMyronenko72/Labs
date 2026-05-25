using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Bijouterie : Accessory,IName<Bijouterie>
    {
        private int numberOfRhinestones;

        public Bijouterie()
        {
            numberOfRhinestones = 0;
        }
        public Bijouterie(string name, double price, string brand, string color, int numberOfRhinestones) : base(name, price, brand, color)
        {
            this.numberOfRhinestones = numberOfRhinestones;

        }

        public int NumberOfRhinestones
        {
            get
            {
                return numberOfRhinestones;
            }
            set
            {
                if (value < 0)
                    throw new NegativeException();
                numberOfRhinestones = value;
            }
        }

        public int CompareTo(Bijouterie other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Number of rhinestones:{numberOfRhinestones}";
        }
    }
}