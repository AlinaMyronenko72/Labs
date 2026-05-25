using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1TP1
{

    class Product
    {
        public string name;
        public double price;
        public int count;
        public string end = "end";

        public Product() { name = ""; price = 0; count = 0; }
        public void Read()
        {

            Console.Write($"Name: ");
            name = Console.ReadLine();
            Console.Write($"Price: ");
            price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Count: ");
            count = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine($"Name:{name} Price:{price}  Count:{count}");           

        }
        
        public override string ToString()
        {
            string s = name + " " + price.ToString() + " " + count.ToString();
            return s;
        }
       

    }
    class Program
    {

        private static int Max(Product[] array)
        {

            double max = array[0].price;
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].name == "end")
                    break;
                if (array[i].price > max)
                {
                    max = array[i].price;
                    j = i;

                }

            }
            return j;
        }
        private static void SortPrice(Product[] array)
        {
            Product temp;
            for (int i = 0; array[i].name != "end"; i++)
            {

                for (int j = i + 1; array[j].name != "end"; j++)
                {

                    if (array[i].price > array[j].price)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }

                }
            }
        }
        private static void SortCount(Product[] array)
        {
            Product temp;
            for (int i = 0; array[i].name != "end"; i++)
            {

                for (int j = i + 1; array[j].name != "end"; j++)
                {

                    if (array[i].count > array[j].count)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }

                }
            }
        }
        private static void SortName(Product[] array)
        {
            Product temp;
            for (int i = 0; array[i].name != "end"; i++)
            {

                for (int j = i + 1; array[j].name != "end"; j++)
                {


                    if (String.Compare(array[i].name, array[j].name) > 0)
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            Product[] array = new Product[1000];
            for (int i = 0; i < 1000; i++)
            {
                array[i] = new Product();
                array[i].Read();
                if (array[i].name == "end")
                    break;
            }

            for (int i = 0; array[i].name != "end"; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
            Console.WriteLine("\n");
            Console.WriteLine("Max product: ");
            int k = Max(array);
            Console.WriteLine(array[k]);
            SortPrice(array);
            Console.WriteLine("\n");
            Console.WriteLine("Sort price: ");
            for (int i = 0; array[i].name != "end"; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
            Console.WriteLine("\n");
            Console.WriteLine("Sort count: ");
            SortCount(array);
            for (int i = 0; array[i].name != "end"; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
            Console.WriteLine("\n");
            Console.WriteLine("Sort name: ");
            SortName(array);
            for (int i = 0; array[i].name != "end"; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
            Console.ReadKey();
        }
    }
}
