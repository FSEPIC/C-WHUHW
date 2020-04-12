﻿using System;
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
    public partial class Form4 : Form
    {
        OrderItem OrderItem = new OrderItem();
        public OrderItem itemorder { get => OrderItem; }
        public int del { set; get; }
        public Form4(OrderItem orderitem)
        {
            InitializeComponent();
            del = 1;
            OrderItem = orderitem;
            num.Text = orderitem.orderitemnum.ToString();
            price.Text = orderitem.orderitemprice.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderItem.orderitemprice = int.Parse(price.Text);
            OrderItem.orderitemnum = int.Parse(num.Text);
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            del = 0;
            this.Close();
            
        }
    }
}
