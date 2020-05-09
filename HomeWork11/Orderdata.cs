using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using order;
namespace _2020_4_6_one
{
    public class Orderdata
    {
        private static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(
                "server=localhost;user id=root;password=7426985mc;database=orderdata");
            connection.Open();
            return connection;
        }
        public void datatoclass(OrderService orderService)
        {
            
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = GetConnection();
            mySqlCommand.CommandText = @"SELECT * FROM orderitem,orders where order_id = orid;";
            var mydata = mySqlCommand.ExecuteReader();
            while (mydata.Read()){
                var itid = mydata.GetInt32(0);
                var itnum = mydata.GetInt32(1);
                var itprice = mydata.GetInt32(2);
                var itname = mydata.GetString(3);
                var orid = mydata.GetInt32(4);
                var oruser = mydata.GetString(5);
                var ortime = mydata.GetString(7);
                orderService.addorder(orid,itnum,itname,oruser,itprice,ortime,itid);
            }
        }
        public void LINQInDataSet(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                String sql = "SELECT * FROM orders";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                    using (DataSet ds = new DataSet())
                    {
                        dataAdapter.Fill(ds);
                        DataRow[] rows = ds.Tables[0].Select("orid="+id);
                        for (int i = 0; i < rows.Length; i++)
                        {
                            Console.WriteLine($"{rows[i][0]},{rows[i][1]},{rows[i][2]}");
                        }
                    }
                }
            }
        }
        public void EditInDataSet(int id,int num,int price)
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
                        DataRow[] rows = ds.Tables[0].Select("order_id = "+ id);
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
        public void Deleteorder(int id)
        {
            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand
                ("delete from orderitem where order_id = "+ id , connection))
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
        /*
        public void AddRowInDataSet(string user,string time)
        {
            using (MySqlConnection conn = GetConnection())
            {
                String sql = "SELECT * FROM orders";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                    MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(dataAdapter);
                    using (DataSet ds = new DataSet())
                    {
                        dataAdapter.Fill(ds);
                        DataRow newRow = ds.Tables[0].NewRow();
                        newRow[0] = user;
                        newRow[2] = time;
                        ds.Tables[0].Rows.Add(newRow);
                        dataAdapter.Update(ds);
                    }
                }
            }
        }*/
        public void Insertorder(string user,int id,string time,int itid,int num,string name,int price)
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
                    cmd.Parameters.AddWithValue("@itemname",name);
                    cmd.Parameters.AddWithValue("@itemprice", price);
                    cmd.Parameters.AddWithValue("@order_id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Outall()
        {
            using (MySqlConnection connection = GetConnection())
            {
                string stm = @"SELECT * From orders";
                using (MySqlCommand cmd = new MySqlCommand(stm, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + "\t" +
                             reader.GetString(1) + "\t" + reader.GetString(2));
                        }
                    }
                }
            }
        }
    }
}
