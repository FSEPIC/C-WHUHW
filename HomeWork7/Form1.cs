using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2020_3_20_one
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.7;
        double per2 = 0.7;
        Color c = Color.Pink;
        public Form1()
        {
            InitializeComponent();
            label11.BackColor = Color.Pink;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(textBox1.Text) >= 1) { MessageBox.Show("该参数不要大于1"); textBox1.Text = "0.1"; }
                if (double.Parse(textBox1.Text) < 0) { MessageBox.Show("该参数不要小于0"); textBox1.Text = "0.1"; }
            }
            catch
            {
                MessageBox.Show("该参数不可为字符");
            }
            finally
            {
                double.TryParse(textBox1.Text, out per1);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(textBox2.Text) >= 1) { MessageBox.Show("该参数不要大于1"); textBox2.Text = "0.1"; }
                if (double.Parse(textBox2.Text) < 0) { MessageBox.Show("该参数不要小于0"); textBox2.Text = "0.1"; }
            }
            catch
            {
                MessageBox.Show("该参数不可为字符");
            }
            finally
            {
                double.TryParse(textBox2.Text, out per2);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics != null) graphics.Clear(Color.White);
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(hScrollBar1.Value, 250, 475,hScrollBar2.Value, -Math.PI / 2);
        }
        

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0,y0,x1,y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            Pen pen = new Pen(c);
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = hScrollBar1.Value.ToString();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label4.Text = hScrollBar2.Value.ToString();
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == '.' && (textBox1.Text.Contains(".") || textBox1.Text == ""))
            {
                e.Handled = true;
            }
            if (textBox1.Text == "")
            {
                if ((int)e.KeyChar > '9') e.Handled = true;
            }
            else if (((int)e.KeyChar < '0' || (int)e.KeyChar > '9') && (int)e.KeyChar != 8 && (int)e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == '.' && (textBox1.Text.Contains(".") || textBox1.Text == ""))
            {
                e.Handled = true;
            }
            if (textBox1.Text == "")
            {
                if ((int)e.KeyChar > '9') e.Handled = true;
            }
            else if (((int)e.KeyChar < '0' || (int)e.KeyChar > '9') && (int)e.KeyChar != 8 && (int)e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label8.Text = hScrollBar3.Value.ToString();
            th1 = hScrollBar3.Value * Math.PI / 180;
        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            label10.Text = hScrollBar4.Value.ToString();
            th2 = hScrollBar3.Value * Math.PI / 180;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                Color GetColor = ColorForm.Color;
                //GetColor就是用户选择的颜色，接下来就可以使用该颜色了
                label11.BackColor = GetColor;
                c = GetColor;
            }
        }
    }
}
