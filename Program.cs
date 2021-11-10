using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixA
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, a = 7;

            Console.Write("Nhap so n: ");
            n = int.Parse(Console.ReadLine());
            if (n <= 0 || n > 10)
            {
                Console.WriteLine("Nhap so tu 1 den n < 10");
                Console.ReadKey();
                return;
            }
            int[,] arr = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = random.Next(1, 100);
                }
            }
            var aXuatHien = random.Next(3, 5);
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();
            Dictionary<int , int> map = new Dictionary<int, int>();
           
            for (int i = 0; i < aXuatHien; i++)
            {
                var col = random.Next(0, n);
                var row = random.Next(0, n);

                var find =  map.FirstOrDefault(x => x.Value == row && x.Key == col).Key;
                if (find != 0)
                {
                    aXuatHien++;
                    continue;
                }
                arr[col, row] = a;
                rows.Add(row);
                cols.Add(col);
            }
            Console.WriteLine("Xuat ra man hinh ma tran ngau nhien");
            Print(arr, n);
            Console.WriteLine("Xuat ra man hinh ma tran B tu A");
            PrintBfromA(arr, n, a);
            Console.WriteLine("Xuat ra man hinh ma tran giam dan");
            PrintOrder(arr, n);
            Console.ReadKey();
        }
        static void PrintBfromA(int [,] arr, int n, int a)
        {
            var b = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] == a)
                        b[i, j] = 1;
                    else b[i, j] = 0;
                }
            }
            Print(b, n);
        }
        static void Print(int[,] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintOrder(int[,] arr, int n)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp.Add(arr[i, j]);
                }
            }
            temp = temp.OrderByDescending(x => x).ToList();
            int index = 0;
            int k = 0;
            int[,] a = new int[n, n];
            foreach (var item in temp)
            {
                if (k < n)
                {
                    a[index, k] = item;
                    k++;
                }
                else
                {
                    index++;
                    k = 0;
                    a[index, k++] = item;
                }
            }

            Print(a, n);
        }
    }
}
