using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using order;
namespace _2020_4_6_one
{
    public partial class Form1 : Form
    {
        public OrderService orders;
        public Form1(OrderService order)
        {
            InitializeComponent();
            orders = order;
            orderBindingSource.DataSource = order.ret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(orders);
            form2.ShowDialog();
            orders = form2.Service;
            orderBindingSource.DataSource = orders.ret();
            orderBindingSource.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order orderf = orderBindingSource.Current as Order;
            Form3 form3 = new Form3(orderf);
            form3.ShowDialog();
            orderBindingSource.ResetBindings(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int id);
            Order order = orders.findorder(id);
            List<Order> result = new List<Order>();
            if (order != null) result.Add(order);
            orderBindingSource.DataSource = result;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Orderdata orderdata = new Orderdata();
            Order del = orderBindingSource.Current as Order;
            orders.orderlist.Remove(del);
            orderdata.Deleteorder(del.orderid);
            orderBindingSource.ResetBindings(false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orders.orderlist;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orders.Export(fileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                List<Order> orders1 = orders.Import(fileName);
                if (orders1 != null)
                {
                    orderBindingSource.DataSource = orders1;
                }
            }
        }
    }
}
