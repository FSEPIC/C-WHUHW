using System;

namespace _2020_3_2_two
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
        public Triangle(int a, int b, int c)
        {
            this.at = a;
            this.bt = b;
            this.ct = c;
        }
        public double Area()
        {
            int p = (at + bt + ct) / 2;

            return Math.Sqrt(p * (p - at) * (p - bt) * (p - ct));
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
        public Rectangle(int a, int b)
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
    interface IShapeout
    {
        IShape ability(int n); 
    }
    class Shapeout : IShapeout
    {
        public static Random random()
        {
            Random R = new Random(Guid.NewGuid().GetHashCode());
            return R;
        }

        public IShape ability(int n)
        {
            Random R = random();
            switch (n)
            {
                case 1:
                    IShape t = new Triangle(R.Next(1,100), R.Next(1, 100), R.Next(1, 100));
                    return t;
                    break;
                case 2:
                    IShape r = new Rectangle(R.Next(1, 100), R.Next(1, 100));
                    return r;
                    break;
                case 3:
                    IShape s = new Square(R.Next(1, 100));
                    return s;
                    break;
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shapeout s = new Shapeout();
            int total = 0;
            IShape a;
            for(int i = 0; i < 10; i++)
            {
                a = s.ability(Shapeout.random().Next(1, 3));
                if (a.Legal())
                {
                    total += (int)a.Area();
                }
                else
                {
                    i--;
                }
            }
            Console.WriteLine(total);
        }
    }
}
