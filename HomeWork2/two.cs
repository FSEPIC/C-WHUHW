using System;

namespace _2020_2_24_two
{
    class Program
    {
        static void Max(int[] a,int n)
        {
            int max=0;
            for(int i = 0; i < n; i++)
            {
                if (max < a[i])
                {
                    max = a[i];
                }
            }
            Console.WriteLine("数组最大值为:"+max);
        }
        static void Min(int[] a,int n)
        {
            int min = 99999;
            for (int i = 0; i < n; i++)
            {
                if (min > a[i])
                {
                    min = a[i];
                }
            }
            Console.WriteLine("数组最小值为:" + min);
        }
        static void AllAdd(int[] a,int n)
        {
            int all = 0;
            for (int i = 0; i < n; i++) 
            {
                all += a[i];
            }
            Console.WriteLine($"所有数的和为{all},平均数为{all/(n)}");
        }
        static void Main(string[] args)
        {
            int[] a = new int[100];
            int n,i=0;
            string s = "";
            Console.WriteLine("请输入数字，停止请输入end");
            while (true)
            {
                s=Console.ReadLine();
                if (Int32.TryParse(s,out n))
                {
                    a[i] = n;
                    i++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("调试"+i);
            Max(a, i);
            Min(a, i);
            AllAdd(a, i);

        }
    }
}
