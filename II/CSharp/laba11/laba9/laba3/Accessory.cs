using System;
using System.Collections.Generic;
using System.IO;
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
        public override void GetData(BinaryWriter file)
        {
           
            file.Write(Name);
            file.Write(Price);
            file.Write(Brand);
            file.Write(Color);
        }
        public override void SetData(BinaryReader file)
        {

            Name = file.ReadString();
            Price = file.ReadDouble();
            Brand = file.ReadString();
            Color = file.ReadString();
        }
        public override string ToString()
        {
            return $"{base.ToString()},Brand:{brand}, Color:{color}";

        }
    }
}