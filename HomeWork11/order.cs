using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace order
{
    
    public class OrderItem
    {
        public int orderitemid { set; get; }
        public int orderitemnum { set; get; }
        public int orderitemprice { set; get; }
        public string orderitemname { set; get; }
        public OrderItem() { }
        public OrderItem(int id,int num, int price,string name)
        {
            orderitemnum = num;
            orderitemname = name;
            orderitemprice = price;
            orderitemid = id;
        }
        public int totalmoney { get => orderitemnum * orderitemprice;}
        public override string ToString()
        {
            return "订单物品号:"+orderitemid+"订单物品数量:"+orderitemnum+"订单物品价格:"+orderitemprice+"订单物品名:"+orderitemname;
        }
        public override bool Equals(object obj)
        {
            OrderItem oi = obj as OrderItem;

         return oi!=null && oi.orderitemid == orderitemid && oi.orderitemname == orderitemname && oi.orderitemnum == orderitemnum && oi.orderitemprice==orderitemprice;
        }
        public override int GetHashCode()
        {
            return orderitemid*orderitemnum+orderitemprice;
        }
    }
    public class Order:IComparable
    {
        public string orderuser { set; get; }
        public int orderid { set; get; }
        public string ordertime { set; get; }
        public List<OrderItem> OrderItems { get => orderitem; }
        public List<OrderItem> orderitem = new List<OrderItem>();
        public int totalmoney()//求订单总金额
        {
            int money = 0;
            for(int i = 0; i < orderitem.Count; i++)
            {
                money += orderitem[i].totalmoney;
            }
            return money;
        }
        public Order() { }
        public Order(int id, int num, int price, string name,string user,string time,int itid)
        {
            ordertime = time;
            orderitem.Add(new OrderItem(itid, num, price, name));
            orderuser = user;
            orderid = id;
        }
        private bool Everyitemeq(OrderItem oi)//审核订单物品是否相同
        {
            
            for (int i = 0; i < orderitem.Count; i++)
            {
                if (orderitem[i] == oi)
                {
                    
                    return false;
                }
            }
            return true;
        }
        public void addorderitem(int id,int num,int price,string name)//添加订单
        {
            OrderItem oi = new OrderItem(id, num, price, name);
            if (Everyitemeq(oi))
            {
                orderitem.Add(oi);
                return;
            }
            Console.WriteLine("订单物品相同，添加失败");
        }
        private void Forlist(Action<OrderItem> action)//便利所有订单物品
        {
            for(int i = 0; i < orderitem.Count; i++)
            {
                action(orderitem[i]);
            }
        }
        public string orderiteminf()//所有物品信息
        {
            String s = "";

            for (int i =0;i<orderitem.Count; i++)
            {
                s += "\n";
                s += orderitem[i].ToString();
                
            }
            return s;

        }
        public override string ToString()
        {
            
            return "订单号:" + orderid + "订单时间:" + ordertime + "订单创建者:" + orderuser+this.orderiteminf();
        }
        public OrderItem Findorderitem(int id)//查找订单
        {
            List<OrderItem> orders = this.orderitem;
            if (orders.Count - 1 >= 0)
            {
                var find = from od in orderitem
                           where id == od.orderitemid
                           select od;
                try
                {
                    return find.First();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("异常:System.InvalidOperationException");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("异常:列表内无元素");
                return null;
            }
        }
        public override bool Equals(object obj)
        {
            Order o = obj as Order;
            return o!=null && o.orderid == orderid && o.ordertime == ordertime && o.orderuser == orderuser;
        }
        public override int GetHashCode()
        {
            return totalmoney()*orderid+orderitem.Count;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Order))
            {
                throw new System.ArgumentException();
            }
            Order order = (Order)obj;
            if (this.totalmoney() > order.totalmoney())
            {
                return 1;
            }
            else
            {
                if (this.totalmoney() < order.totalmoney())
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    public class OrderService
    {
        public List<Order> orderlist = new List<Order>();
        int ordernum = 1;
        public OrderService() { }
        public List<Order> Lambdasort()
        {
            if (orderlist.Count - 1 >= 0)
            {
                try
                {
                    var ar = orderlist.OrderBy(o=>o.orderid);
                    List<Order> orarray = ar.ToList();
                    orarray.Sort();
                    return orarray;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("异常:System.InvalidOperationException");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("异常:列表内无元素");
                return null;
            }
        }
        public bool everyorderqe(Order o)//审核订单物品相同
        {
            for (int i = 0; i < orderlist.Count; i++)
            {
                if (orderlist[i] == o)
                {
                    return false;
                }
            }
            return true;
        }
        public void addorder(int id, int num, string name, string user, int price,string time,int itid)//添加订单
        {
            Order o = new Order(id, num, price, name, user,time,itid);
            if (everyorderqe(o))
            {
                orderlist.Add(o);
                return;
            }
            Console.WriteLine("订单物品相同，添加失败");
        }
        public bool detelorder(int id)//删除订单
        {
            if (orderlist.Count-1 >= 0) {
                var detel = from od in orderlist
                            where id == od.orderid
                            select od;
                try
                {
                    orderlist.Remove(detel.First());
                    return true;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("异常:System.InvalidOperationException");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("异常:列表内无元素");
                return false;
            }
        }
        public Order findorder(int id)//查找订单
        {
            if (orderlist.Count - 1 >= 0)
            {
                var find = from od in orderlist
                           where id == od.orderid
                           select od;
                try
                {
                    return find.First();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("异常:System.InvalidOperationException");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("异常:列表内无元素");
                return null;
            }
        }
        public bool reviseorder(int id,int orderitemid,int orderitemnump)//修改订单
        {

            Order o = findorder(id);
            if (o == null) return false;
            o.Findorderitem(orderitemid).orderitemnum = orderitemnump;
            Console.WriteLine("修改成功");
            return true;
        }
        public void listeach(Action<Order> action)//遍历订单
        {
            for(int i = 0; i < orderlist.Count; i++)
            {
                action(orderlist[i]);
            }
        }
        public List<Order> findmoneyorder(int m)//查找大于等于m金额的订单(排序输出)
        {
            if (orderlist.Count - 1 >= 0)
            {
                var ar = orderlist.Where(o=>o.totalmoney()>m);
                try
                {
                    List<Order> orarray = ar.ToList();
                    orarray.Sort();
                    return orarray;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("异常:System.InvalidOperationException");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("异常:列表内无元素");
                return null;
            }
        }
        public bool Export(string file)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(file, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, orderlist);
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Order> Import(string file)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream fileStream = new FileStream(file,FileMode.Open))
                {
                    return (List<Order>)xmlSerializer.Deserialize(fileStream);
                }
            }
            catch
            {
                Console.WriteLine("反序列失败");
                return null;
            }
        }
        public List<Order> ret()
        {
            return orderlist;
        }
        /*
        public void printorder(int id)//打印该订单内的所有物品
        {
            if (orderlist.Count - 1 >= 0)
            {
                var p = from od in orderlist
                            where id == od.orderid
                            select od;
                try
                {
                    Order order = p.First();
                    Console.WriteLine($"订单号:{order.orderid},订单创建时间:{order.ordertime}");
                    order.forlist(s => { Console.WriteLine($"订单物品号:{s.orderitemid},订单物品:{s.orderitemname},订单物品数量:{s.orderitemnum},订单物品价格:{s.orderitemprice}"); });
                    return;
                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("异常:System.InvalidOperationException");
                    return;
                }
            }
            else
            {
                Console.WriteLine("异常:列表内无元素");
                return;
            }
        }*/
    }
    class Program
    {
        /*static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            for (int i = 0; i < 100; i++)
            {
                orderService.addorder(i,i+10,"洗洁精","admin",5);
            }
            orderService.listeach(o => o.addorderitem(2, 10, 10, "钢丝球"));
            orderService.addorder(3, 3 + 10, "洗洁精", "最小价格最后添加",1);
            List<Order> or = orderService.findmoneyorder(0);
            //orderService.listeach(o => Console.WriteLine(o.totalmoney()));
            for (int i = 0; or != null && i < or.Count; i++)
            {
                Console.WriteLine(or[i]);
            }
            if (orderService.Export())
            {
                Console.WriteLine("序列化完成");
            }
            else
            {
                Console.WriteLine("序列化失败");
            }
            List<Order> orders = orderService.Import();
            Console.WriteLine(orders[0]);
            throw new Exception();
            //orderService.listeach(o=> Console.WriteLine(o));
            //orderService.listeach(o => orderService.reviseorder(1,1,100));
            //orderService.listeach(o => Console.WriteLine(o));
        }*/
    }
}
