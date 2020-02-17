using System;

namespace TESTT
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int i=0, j=0,k=0;
            string s = "";
            Console.Write("输入第一个数：");
            s=Console.ReadLine();
            i=Int32.Parse(s);
            while (k<1 || k>4) {
                Console.Write("选择操作符:1.加,2.减,3.乘,4.除");
                s = Console.ReadLine();
                if (s == "") continue;
                k = Int32.Parse(s);
            }
            Console.Write("输入第二个数：");
            s = Console.ReadLine();
            j = Int32.Parse(s);
            switch (k)
            {
                case 1:
                    Console.WriteLine($"{i}+{j}={i+j}");
                    break;
                case 2:
                    Console.WriteLine($"{i}-{j}={i-j}");
                    break;
                case 3:
                    Console.WriteLine($"{i}*{j}={i * j}");
                    break;
                case 4:
                    Console.WriteLine($"{i}/{j}={i / j}");
                    break;
            }
        }
    }
}
