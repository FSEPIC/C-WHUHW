using System;

namespace ConsoleApp1
{
    interface IShape
    {
        double Area();
        bool Legal();
    }
    class Triangle : IShape
    {

        public int at { set; get; }
        public int bt { set; get; }
        public int ct { set; get; }
        public Triangle(int a,int b,int c)
        {
            this.at = a;
            this.bt = b;
            this.ct = c;
        }
        public  double Area()
        {
            int p = (at + bt + ct) / 2;

            return Math.Sqrt(p*(p-at)*(p-bt)*(p-ct));
        }

        public bool Legal()
        {
            bool f = false;
            if (at <= 0 || bt <= 0 || ct <= 0) return false;
            f = at + bt > ct ? true : false;
            f = at + ct > bt ? true : false;
            f = ct + bt > at ? true : false;
            return f;
        }
    }
    class Rectangle : IShape
    {
        public int ar { set; get; }
        public int br { set; get; }
        public Rectangle(int a,int b)
        {
            this.ar = a;
            this.br = b;
        }
        
        public double Area()
        {
            return ar * br;
        }
        public bool Legal()
        {
            return ar > 0 && br > 0 ? true : false;
        }
    }
    class Square : IShape
    {
        public int sa { set; get; }
        public Square(int a)
        {
            this.sa = a;
        }
        public double Area()
        {
            return sa * sa;
        }
        public bool Legal()
        {
            return sa > 0 ? true : false;
        }
    }
    class Program
    {
        

        static void Main(string[] args)
        {
            Triangle t = new Triangle(3,4,5);
            if (t.Legal())
            {
                Console.WriteLine("三角形合法\n"+t.at);
            }
            else
            {
                Console.WriteLine("三角形不合法");
            }
            Console.WriteLine($"三角形面积{t.Area()}");
            Rectangle r = new Rectangle(2, 6);
            Console.WriteLine($"长方形面积{r.Area()}");
            Square s = new Square(10);
            Console.WriteLine($"正方形面积{s.Area()}");
        }
    }
}
