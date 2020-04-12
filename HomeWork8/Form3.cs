using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using order;
namespace _2020_4_6_one
{
    public partial class Form3 : Form
    {
        public Order Order;
        public Form3(Order order)
        {
            InitializeComponent();
            this.Order = order;
            userlabel.Text = order.orderuser;
            orderidlabel.Text = order.orderid.ToString();
            ordertime.Text = order.ordertime;
            orderItemBindingSource.DataSource = order.OrderItems;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            OrderItem item = orderItemBindingSource.Current as OrderItem;
            Form4 form4 = new Form4(item);
            form4.ShowDialog();
            if (form4.del == 0)
            {
                Order.orderitem.Remove(item);
                
            }
            orderItemBindingSource.DataSource = Order.orderitem;
            orderItemBindingSource.ResetBindings(false);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
