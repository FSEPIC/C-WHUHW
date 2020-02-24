using System;

namespace count
{
    class Program
    {
        private static void con(out bool f)
        {
            string i;
            i = Console.ReadLine();
            if(i!= "1" && i!= "0")
            {
                Console.WriteLine("输错了，默认就当退出了");
                f = false;
                return;
            }
            else
            {
                if (i == "1") f = true; else f = false;
            }
            
        }
        static void Main(string[] args)
        {
            int i, j;
            string s = "",c;
            bool flag = true,chu=false;
            while (flag) {
                Console.Write("输入第一个值:");
                s=Console.ReadLine();
                if (!count.Re(s,out i)) continue;
                Console.Write("输入操作符：");
                c = Console.ReadLine();
                if (c == "/") chu = true;
                Console.Write("输入第二个值:");
                s = Console.ReadLine();
                if (!count.Re(s, out j,chu)) continue;
                count.result(i,j,c);
                Console.WriteLine("继续?\\1或者0");
                Program.con(out flag);
            }
        }
    }
    class count
    {
        public static bool Re(string s,out int i,bool chu = false)
        {
            if (!int.TryParse(s,out i))
            {
                Console.WriteLine("键入值不符合规范，应输入整形范围内的数字");
                return false;
            }
            if (i==0 && chu)
            {
                Console.WriteLine("被除数不可为0");
                return false;
            }
            return true;
        }
        public static void result(int i,int j,string s)
        {
            try
            {
                switch (s)
                {
                    case "+":
                        Console.WriteLine($"{i}+{j}={i + j}");
                        
                        return;
                    case "-":
                        Console.WriteLine($"{i}-{j}={i - j}");
                        
                        return;
                    case "*":
                        Console.WriteLine($"{i}*{j}={i * j}");
                        
                        return;
                    case "/":
                        Console.WriteLine($"{i}/{j}={i / j}");
                        
                        return;
                    default:
                        Console.WriteLine("操作符错误");
                        
                        break;
                    
                }
            }
            catch
            {
                Console.WriteLine("出现异常");
                
                return;
            }
        }
    }
}
