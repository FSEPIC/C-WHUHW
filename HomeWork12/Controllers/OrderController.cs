using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using _2020_5_11_one.Models;
using MySql.Data.MySqlClient;

namespace _2020_5_11_one.Controllers
{
    public class OrderController : ApiController
    {
        /*
        public OrderController(XmlSerializer xs)
        {
            using (FileStream fileStream = new FileStream("C:\\Users\\F_S\\Desktop\\软件构造基础\\2020-5-11-one\\data.xml", FileMode.Open))
            {
                List<Order> orders = (List<Order>)xs.Deserialize(fileStream);
                Console.WriteLine(orders.Count);
                orderlist = orders.ToArray();
            }
        }
        
        static XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
        */
        static List<OrderItem> orderItems = new List<OrderItem>
        {
            new OrderItem(){ orderitemid = 1,orderitemnum=2,orderitemprice=5,orderitemname="鸡蛋" }
        };
        static List<Order> orderlist = new List<Order> {
            new Order(){ orderid = 1 ,ordertime = "2020-5-11",orderuser = "admin",orderitem = orderItems},
            new Order(){ orderid = 2 ,ordertime = "2020-5-11,11-51",orderuser = "ok",orderitem = orderItems},
            new Order(){ orderid = 3 ,ordertime = "2020-5-11,12-41",orderuser = "ko",orderitem = orderItems},
        };
        [HttpGet]
        public List<Order> Orders()
        {
            List<Order> orders = new List<Order>();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = GetConnection();
            mySqlCommand.CommandText = @"SELECT * FROM orderitem,orders where order_id = orid;";
            var mydata = mySqlCommand.ExecuteReader();
            while (mydata.Read())
            {
                var itid = mydata.GetInt32(0);
                var itnum = mydata.GetInt32(1);
                var itprice = mydata.GetInt32(2);
                var itname = mydata.GetString(3);
                var orid = mydata.GetInt32(4);
                var oruser = mydata.GetString(5);
                var ortime = mydata.GetString(7);
                List<OrderItem> orderItems = new List<OrderItem> { new OrderItem() { orderitemid = itid, orderitemnum = itnum, orderitemprice = itprice, orderitemname = itname } };
                Order order = new Order() { orderid = orid, orderitem = orderItems, ordertime = ortime, orderuser = oruser };
                orders.Add(order);
            }
            return orders;
        }
        [HttpGet]
        public List<Order> Getfindorder(string name)//查找订单
        {
            MySqlCommand mySqlCommand = new MySqlCommand();
            using (mySqlCommand.Connection = GetConnection())
            {
                List<Order> orders = new List<Order>();
                string sql = @"SELECT * FROM orderitem,orders where order_id = orid and oruser = '" + name+"'";
                mySqlCommand.CommandText = sql;
                using (mySqlCommand)
                {
                    var mydata = mySqlCommand.ExecuteReader();
                    while (mydata.Read())
                    {
                        var itid = mydata.GetInt32(0);
                        var itnum = mydata.GetInt32(1);
                        var itprice = mydata.GetInt32(2);
                        var itname = mydata.GetString(3);
                        var orid = mydata.GetInt32(4);
                        var oruser = mydata.GetString(5);
                        var ortime = mydata.GetString(7);
                        List<OrderItem> orderItems = new List<OrderItem> { new OrderItem() { orderitemid = itid, orderitemnum = itnum, orderitemprice = itprice, orderitemname = itname } };
                        Order order = new Order() { orderid = orid, orderitem = orderItems, ordertime = ortime, orderuser = oruser };
                        orders.Add(order);
                    }
                    return orders;
                }
            }
        }
        [HttpPost]
        public void Postaddorder(string user, int id, string time, int itid, int num, string name, int price)//增加order
        {
            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand
                ("INSERT INTO orders VALUES(@oruser,@orid,@ortime)", connection))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@oruser", user);
                    cmd.Parameters.AddWithValue("@orid", id);
                    cmd.Parameters.AddWithValue("@ortime", time);
                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand
                ("INSERT INTO orderitem VALUES(@itemid,@itemnum,@itemprice,@itemname,@order_id)", connection))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@itemid", itid);
                    cmd.Parameters.AddWithValue("@itemnum", num);
                    cmd.Parameters.AddWithValue("@itemname", name);
                    cmd.Parameters.AddWithValue("@itemprice", price);
                    cmd.Parameters.AddWithValue("@order_id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        [HttpDelete]
        public void Deleteorder(int id)//删除选择ID
        {
            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand
                ("delete from orderitem where order_id = " + id, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand
                ("delete from orders where orid = " + id, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Porder(int id, int num, int price)//修改
        {
            using (MySqlConnection conn = GetConnection())
            {
                String sql = "SELECT * FROM orderitem";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                    MySqlCommandBuilder cmdBuilder =
                      new MySqlCommandBuilder(dataAdapter);
                    using (DataSet ds = new DataSet())
                    {
                        dataAdapter.Fill(ds);
                        DataRow[] rows = ds.Tables[0].Select("order_id = " + id);
                        for (int i = 0; i < rows.Length; i++)
                        {
                            rows[i].BeginEdit();
                            rows[i][1] = num;
                            rows[i][2] = price;
                            rows[i].EndEdit();
                        }
                        dataAdapter.Update(ds);
                    }
                }
            }
        }
        private static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(
                "datasource=localhost;username=root;" +
                "password=7426985mc;database=orderdata;charset=utf8");
            connection.Open();
            return connection;
        }
    }   
}
