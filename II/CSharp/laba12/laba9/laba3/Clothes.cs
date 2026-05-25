using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Clothes : Product,IName<Clothes>
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

        public int CompareTo(Clothes other)
        {
            throw new NotImplementedException();
        }
        public override void GetData(BinaryWriter file)
        {

            file.Write(Name);
            file.Write(Price);
            file.Write(Material);
            file.Write(CountryOfOrigin);
        }
        public override void SetData(BinaryReader file)
        {

            Name = file.ReadString();
            Price = file.ReadDouble();
            Material = file.ReadString();
            CountryOfOrigin = file.ReadString();
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Material:{material}, Contry:{countryOfOrigin}";
        }
    }
}