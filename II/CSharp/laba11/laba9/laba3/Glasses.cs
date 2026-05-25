using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Glasses : Accessory,IName<Glasses>
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

        public int CompareTo(Glasses other)
        {
            throw new NotImplementedException();
        }
        public override void GetData(BinaryWriter file)
        {

            file.Write(Name);
            file.Write(Price);
            file.Write(Brand);
            file.Write(Color);
            file.Write(TypeOfRim);
        }
        public override void SetData(BinaryReader file)
        {

            Name = file.ReadString();
            Price = file.ReadDouble();
            Brand = file.ReadString();
            Color = file.ReadString();
            TypeOfRim = file.ReadString();

        }
        public override string ToString()
        {
            return $"{base.ToString()}, Rim:{typeOfRim}";
        }
    }
}