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
    public partial class Form2 : Form
    {
        public OrderService Service { set; get; }
        public Form2(OrderService orders)
        {
            Service = orders;
            InitializeComponent();
        }
        List<OrderItem> item = new List<OrderItem>();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Service.addorder(int.Parse(id.Text), int.Parse(num.Text), name.Text, user.Text, int.Parse(price.Text));
            }
            catch
            {
                MessageBox.Show("非规范操作","提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if((int)MessageBox.Show("添加成功,是否要继续添加?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) !=1 )
            {
                this.Close();
            }
            item.Add(new OrderItem(int.Parse(id.Text), int.Parse(num.Text), int.Parse(price.Text), name.Text));
            dataGridView1.DataSource = item;
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
