using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    public class Product:IName<Product>
    {
        private string name;
        protected double price;

        public Product()
        {
            price = 0;
            name = " ";
        }
        public Product(string name,double price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double Price
        {
            get
            {
                
                return price;
            }
            set
            {
                if (value < 0)
                    throw new NegativeException();
                price = value;
            }
        }
        public virtual int CompareTo(Product value)
        {
            
            int temp = this.Name.CompareTo(value.Name);
            if (temp == 0)
                temp= this.Price.CompareTo(value.Price);
            return temp;
        }
        public virtual int CompareTo(object value)
        {
            Product data = value as Product;
           // int temp = this.Name.CompareTo(data.Name);
            //if (temp == 0)
            //    temp = this.Price.CompareTo(data.Price);
            return this.CompareTo(data);
        }
        public override string ToString()
        {
            return $"Name:{name}, Price:{price}";

        }
    }
}