using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace laba3
{
    
    class Program
    {
        static void Main(string[] args)
        {
            /*Glasses glasses = new Glasses("Glasses", 200000, "Dolce and Gabbana", "Blue", "Cat eye");
            glasses.ToString();
            Console.WriteLine(glasses);
            Bijouterie bijouterie = new Bijouterie("Ring", 500, "Piligrim", "Silver", 56);
            bijouterie.ToString();
            Console.WriteLine(bijouterie); 
            Dress dress=new Dress("Dress",2000,"Cotton","Turkey","Mini");
            dress.ToString();
            Console.WriteLine(dress);
            CarnivalCostume carnivalCostume = new CarnivalCostume("Santa Clause suit",4000, "Velour","Ukraine", "Christmas ");
            carnivalCostume.ToString();
            Console.WriteLine(carnivalCostume);*/
            IContainer<Product> a = new Container<Product>();
            a.Add(new CarnivalCostume("Santa Clause suit", 4000, "Velour", "Ukraine", "Christmas "));
            a.Add(new Dress("Dress", 2000, "Cotton", "Turkey", "Mini"));
            a.Add(new Glasses("Glasses", 200000, "Dolce and Gabbana", "Blue", "Cat eye"));
            a.Add(new Bijouterie("Ring", 500, "Piligrim", "Silver", 56));
            // Console.WriteLine(a.Count);
             a.Sort();
            Console.WriteLine(a.ToString());
            // a.Remove(2);
            /*try
            {
                Console.WriteLine(a[1000]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                
                Console.WriteLine(a[1]);
               // Console.WriteLine(a[price: 500]);
                Console.WriteLine(a[name: "Glasses"]);
                Console.WriteLine();
                Console.WriteLine(a.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
            //   SinglyLinkedListContainer b = new SinglyLinkedListContainer();
            /*IContainer<Product> b = new SinglyLinkedListContainer<Product>();
            b.Add(new CarnivalCostume("Santa Clause suit", 4000, "Velour", "Ukraine", "Christmas "));
            b.Add(new Dress("Dress", 2000, "Cotton", "Turkey", "Mini"));
            b.Add(new Glasses("Glasses", 200000, "Dolce and Gabbana", "Blue", "Cat eye"));
            b.Add(new Bijouterie("Ring", 500, "Piligrim", "Silver", 56));
            //  Console.WriteLine(b.Count);
            try
            {
                Console.WriteLine(b[0]);
                Console.WriteLine(b[2].ToString());
              //  Console.WriteLine(b[price: 200000]);
                Console.WriteLine(b[name: "Dress"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // b.Sort();
            //Console.WriteLine(b.ToString());
            // b.Remove(3);
            DoubleLinkedListContainer<Product> c = new DoubleLinkedListContainer<Product>();
            c.Add(new CarnivalCostume("Santa Clause suit", 4000, "Velour", "Ukraine", "Christmas "));
            c.Add(new Dress("Dress", 2000, "Cotton", "Turkey", "Mini"));
            c.Add(new Glasses("Glasses", 200000, "Dolce and Gabbana", "Blue", "Cat eye"));
            c.Add(new Bijouterie("Ring", 500, "Piligrim", "Silver", 56));
            //Console.WriteLine(c.Count);
            //c.Sort();
            //Console.WriteLine(c.ToString());
            //c.Clear();
            try
            {
                Console.WriteLine(c[0]);
                Console.WriteLine(c[2].ToString());
              //  Console.WriteLine(b[price: 2000]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
            
            Console.ReadKey();
        }
    }
    

}
