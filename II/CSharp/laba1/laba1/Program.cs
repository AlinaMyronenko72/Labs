using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{

    class Program
    {
        static void PrintArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write("{0,2}", array[i][ j]);
                }
                Console.WriteLine();
            }
        }
        static int[] StringToIntArray(string s)
        {
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[words.Length];
            for (int j = 0; j < array.Length; j++)
                array[j] = Int32.Parse(words[j]);
            return array;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Кол-во строк");
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[n][];
            Console.WriteLine("Элементы");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                string s = Console.ReadLine();
                jaggedArray[i] = StringToIntArray(s);

            }
            Console.WriteLine(Environment.NewLine);
            int[] sum = new int[n];
            for (int i = 0; i < jaggedArray.Length; i++)
            {

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    sum[i] += jaggedArray[i][j];

                }
                Console.WriteLine(sum[i]);
            }
            Console.WriteLine(Environment.NewLine);
            int min;
            
            int[] index = new int[n];
            min = sum[0];
            for (int i = 1; i < sum.Length; i++)
                if (min > sum[i])
                    min = sum[i];
            Console.WriteLine(min);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("\nn:");
            Console.WriteLine(n);
            n = 0; // обнулить счетчик в массиве INDEXES
            int indexRowWithMaxOfElement = 0;
            for (int i = 0; i < sum.Length; i++)
                if (min == sum[i])
                {
                    n++; // увеличить число элементов в INDEXES
                    index[n -1] = i;
                    // запомнить позицию
                    Console.WriteLine(i);
                    indexRowWithMaxOfElement = i;
                }


            // 3. Вывод массива INDEXES в listBox1
            /* for (int i = 0; i < n; i++)
                 Console.WriteLine(index[i]);
             int[][] jaggedArray1 = new int[n][];
             for (int i = 0; i < jaggedArray1.Length; i++)
             {
                 string s = Console.ReadLine();
                 jaggedArray1[i] = StringToIntArray(s);

             }

             Console.WriteLine(Environment.NewLine);

            */


            for (int i = jaggedArray.GetLength(0); i > indexRowWithMaxOfElement; i--)
            {
                // for (int j = 0; j < jaggedArray.Length+1; j++)
                //   jaggedArray[i][ j] = jaggedArray[i +1][j];

                for (int j = 0; j < jaggedArray[i].Length; j++)
                    jaggedArray[indexRowWithMaxOfElement + 1][j] = 0;
            }
            Console.WriteLine("\nResult\n");
            PrintArray(jaggedArray);
            Console.ReadKey();

        }
    }
}
