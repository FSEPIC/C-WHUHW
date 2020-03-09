using System;
using System.Threading;

namespace _2020_3_9_two
{
    
    public delegate void AlarmTick(Object a,Alarm t);
    public delegate void Alarmgo(Object a,Alarm t);
    
    public class Alarm
    {
        public int S { set; get; }
        public int M { set; get; }
        public int H { set; get; }

        public event AlarmTick Tick;
        public event Alarmgo alar;
        public void Alarmtick()
        {
            while (true)
            {
                Thread.Sleep(100);
                S++;
                if (S == 61)
                {
                    M++;
                    S = 0;
                }
                if (M == 61)
                {
                    H++;
                    M = 0;
                }
                if (H == 25)
                {
                    H = 1;
                }
                Tick(null,this);
                alar(null,this);
            }
        }
        public Alarm(string s,string m,string h)
        {
            S = int.Parse(s);
            M = int.Parse(m);
            H = int.Parse(h);
        }

        
    }
    class Program
    {
        void tick_print(object a,Alarm t)
        {
            Action<int> action = s => Console.WriteLine(s);
            action(t.S);
            action(t.M);
            action(t.H);
        }
        void alarm_setting(object a, Alarm t)
        {
            if (t.S == 14 && t.M == 19 && t.H == 11) Console.WriteLine("时间到了");
        }
        static void Main(string[] args)
        {
            Alarm a = new Alarm(DateTime.Now.Second.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Hour.ToString());
            Program p = new Program();
            a.Tick += p.tick_print;
            a.alar += p.alarm_setting;
            a.Alarmtick();
            Console.WriteLine("Hello World!");
        }
    }
}
