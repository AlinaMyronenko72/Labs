using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1._1
{
    class Program
    {
        static int[] StringToIntArray(string s)
        {
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[words.Length];
            for (int j = 0; j < array.Length; j++)
                array[j] = Int32.Parse(words[j]);
            return array;
        }
        static int[] StringCopy(int[] str)
        {
            int[] copy = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                copy[i] = str[i];
            }
            return copy;
        }
        static int Sum(int[] array)
        {
            int sum = 0;
            for (int j = 0; j < array.Length; j++)
            {
                sum += array[j];
            }
            return sum;
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
            Console.WriteLine("Результат:");

            int minSum = Sum(jaggedArray[0]);
            int Counter = 1;

            for (int i = 1; i < jaggedArray.Length; i++)
            {
                int stringSum = Sum(jaggedArray[i]);

                if (minSum == stringSum)
                {
                    Counter++;
                }

                if (stringSum < minSum)
                {
                    minSum = stringSum;
                    Counter = 1;
                }
            }
            int[][] jaggedArrayResult = new int[jaggedArray.Length + Counter][];

            for (int i = 0, j = 0; i < jaggedArrayResult.Length; i++, j++)
            {
                jaggedArrayResult[i] = StringCopy(jaggedArray[j]);
                if (Sum(jaggedArrayResult[i]) == minSum)
                {
                    

                    jaggedArrayResult[++i] = new int[jaggedArrayResult[i - 1].Length];
                    for (int k = 0; k < jaggedArrayResult[i].Length; k++)
                        jaggedArrayResult[i][k] = 0;
                }
            }

            jaggedArray = jaggedArrayResult;

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }
}
