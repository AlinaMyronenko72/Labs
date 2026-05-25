using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace laba3
{
    public class CarnivalCostume : Clothes,IName<CarnivalCostume>
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

        public int CompareTo(CarnivalCostume other)
        {
            throw new NotImplementedException();
        }
        public override void GetData(BinaryWriter file)
        {

            file.Write(Name);
            file.Write(Price);
            file.Write(Material);
            file.Write(CountryOfOrigin);
            file.Write(Celebration);
        }
        public override void SetData(BinaryReader file)
        {

            Name = file.ReadString();
            Price = file.ReadDouble();
            Material = file.ReadString();
            CountryOfOrigin = file.ReadString();
            Celebration = file.ReadString();

        }
        public override string ToString()
        {
            return $"{base.ToString()},Celebration:{celebration}";
        }
    }
}