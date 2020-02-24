using System;

namespace _2020_2_24_one
{
    class Program
    {
        static bool isPrime(int n)
        {
            bool x = true;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    x = false;
                    break;
                }
            }
            return x;
        }
        static void sushu(int[] a)
        {
            int k = 1;
            a[0] = 2;
            for (int i = 3; i < 1000; i++)
            {
                if (isPrime(i))
                {
                    if (k == 100) return;
                    a[k] = i;
                    k++;
                }
            }
        }
        static void dic(int n,int[] a)
        {
            int l = 0;
            Console.WriteLine("素数因子有:");
            while (n!=1) {
                if (n % a[l] == 0)
                {
                    n = n / a[l];
                    Console.WriteLine(a[l]);
                }
                else
                {
                    l++;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] a = new int[100];
            a[0]= 2;
            sushu(a);
            int num = 0;
            Console.WriteLine("输入一个大于2的整数");
            string s = "";
            s=Console.ReadLine();
            if (!Int32.TryParse(s, out num)) Console.WriteLine("输入参数有错误");
            dic(num, a);
        }
         
    }
}
