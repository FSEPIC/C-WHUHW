using System;

namespace _2020_2_24_three
{
    class Program
    {
        static void ArrayDel(bool[] a,int n)
        {
            int t,i=2;
            while (true)
            {
                t = n * i;
                if (t >= 100) return;
                a[t] = false;
                i++;
            }
        }
        static void Main(string[] args)
        {
            bool[] array = new bool[100];
            
            Console.WriteLine("素数有:");
            for (int i = 0; i < 100; i++) array[i] = true;
            for (int i = 2; i < 101; i++) ArrayDel(array, i);
            for(int i = 2; i < 100; i++)
            {
                if (array[i]) Console.WriteLine(i);
            }
        }
    }
}
