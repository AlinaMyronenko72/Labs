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

            Container<Product> a = new Container<Product>();

            a.DelegateSum += MoneyChangeEvent;

            a.Add(new Dress("Dress", 2000, "Cotton", "Turkey", "Mini"));
            a.Add(new Glasses("Glasses", 200000, "Dolce and Gabbana", "Blue", "Cat eye"));
            a.Add(new CarnivalCostume("Santa Clause suit", 4000, "Velour", "Ukraine", "Christmas "));
            a.Add(new Bijouterie("Ring", 500, "Piligrim", "Silver", 56));
            Console.WriteLine("Вывод данных в контейнере");
            foreach (Product product in a)
                Console.WriteLine(product);
            Console.WriteLine("\n");

            //Serialization.SerializationContainer(a, "D:/Учеба/laba13/file2.bin");
            // Console.WriteLine("Сериализаия завершена");
            //Serialization.DeserializationContainer(a, "D:/Учеба/laba13/file2.bin");
            //foreach (Product product in a)
            //    Console.WriteLine(product.ToString());
            // Container<Product>.SerializationContainer(a, "D:/Учеба/laba13/file2.bin");
          //  a.SerializationContainer(a, "D:/Учеба/laba13/file2.bin");
            WriteToFile.Write(a, "D:/Учеба/laba13/file3.txt");
            Console.WriteLine("Содержимое уже в файле");
            Console.WriteLine("\n");

            Console.WriteLine("Сортировка продуктов");
            a.Sort();
            foreach (Product product in a)
                Console.WriteLine(product);
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            //Console.WriteLine("Удаление продукта по индексу");
            //a.Remove(2);
            //foreach (Product product in a)
            //    Console.WriteLine(product);
            //Console.WriteLine("\n");

            Console.WriteLine("Обработка исключения");
            try
            {
                Console.WriteLine(a[1000]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n");

            try
            {
                Console.WriteLine("Вывод продукта по индексу");
                Console.WriteLine(a[0]);
                Console.WriteLine("\n");

                Console.WriteLine("Вывод продукта по имени");
                Console.WriteLine(a[name: "Glasses"]);
                Console.WriteLine("\n");

              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Вывод данных в обратном порядке");
            foreach (Product product in a.InverseEnumerator())
                Console.WriteLine(product);
            Console.WriteLine("\n");

            Console.WriteLine("Вывод отсортированных продуктов без изменения контейнера");
            foreach (Product product in a.SortEnumerator())
                Console.WriteLine(product);
            Console.WriteLine("\n");

            Console.WriteLine("Вывод продуктов по подстроке");
            foreach (Product product in a.StringEnumerator("ss"))
                Console.WriteLine(product);
            Console.WriteLine("\n");


           

            Console.WriteLine("Вывод всех продуктов по заданному условию");
            IEnumerable<Product> Result = null;
            Result = a.FindAll((c) => c.Price > 1000);
            Result = a.FindAll((c) => c.Name.CompareTo("Ring") > 0);



            foreach (Product product in Result)
                Console.WriteLine(product.ToString());
            Console.WriteLine("\n");



            Console.WriteLine("Вывод продуктов по методу сортировки ");
            a.Sort((d, f) => d.Price > f.Price);
           
            a.Sort((d, f) => (d.Name.CompareTo(f.Name) < 0));
           

            foreach (Product product in a)
                Console.WriteLine(product.ToString());
            Console.WriteLine("\n");

            Console.ReadKey();
        }
        static void MoneyChangeEvent(string str, double sum)
        {
            Console.WriteLine($"{str} Sum {sum}");
           
        }
    }


}
