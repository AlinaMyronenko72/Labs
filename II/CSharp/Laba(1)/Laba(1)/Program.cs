using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1_
{
    class Program
    {
        static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            /* string text = "Привет, Екатерина ноль";
             Console.WriteLine(text);
             text = text.Replace("ноль", "0").Replace("один", "1").Replace("два", "2").Replace("три", "3").Replace("четыре", "4").Replace("пять", "5").Replace("шесть", "6").Replace("семь", "7").Replace("восемь", "8").Replace("девять", "9");
             Console.WriteLine(text);
             Console.ReadKey();*/
            int[,] A = new int[5, 1];
            Random gen = new Random();
            for (int i = 0; i < A.GetLength(0)-1 ; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = gen.Next(1, 50);
                    Console.Write( A[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(Environment.NewLine);
            int indexRowWithMaxOfElement = 0;
            int maxElement = int.MinValue;
            for (int i = 0; i < A.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] > maxElement)
                    {
                        maxElement = A[i, j];
                        indexRowWithMaxOfElement = i;
                        
                    }
                   
                }
              
            }
            Console.WriteLine(indexRowWithMaxOfElement);
            Console.WriteLine(Environment.NewLine);
            for (int i = A.GetLength(0) - 1; i > indexRowWithMaxOfElement; i--)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                    A[i, j] = A[i - 1, j];
            }
            for (int j = 0; j < A.GetLength(1); j++)
                A[indexRowWithMaxOfElement+1, j] = 0;
            Console.WriteLine("\nResult\n");
            ShowMatrix(A);
            Console.ReadKey();
        }
    }
}
