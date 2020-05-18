using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2020_5_11_one.Models
{
    public class OrderItem
    {
        public OrderItem()
        {

        }
        public OrderItem(int id,int num,int price,string name)
        {
            orderitemid = id;
            orderitemname = name;
            orderitemnum = num;
            orderitemprice = price;

        }
        public int orderitemid { set; get; }
        public int orderitemnum { set; get; }
        public int orderitemprice { set; get; }
        public string orderitemname { set; get; }
    }
    public class Order
    {
        public Order()
        {

        }
        public Order(string user,int id,string time,List<OrderItem> orderItems)
        {
            orderuser = user;
            orderid = id;
            ordertime = time;
            orderitem = orderItems;
        }
        public string orderuser { set; get; }
        public int orderid { set; get; }
        public string ordertime { set; get; }

        public List<OrderItem> orderitem { set; get; }
    }
}