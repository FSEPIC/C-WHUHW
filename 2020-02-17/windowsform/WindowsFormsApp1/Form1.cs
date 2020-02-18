using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int a,b,s=1;
        private string c;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                s = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                s = 2;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked)
            {
                s = 3;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton4.Checked)
            {
                s = 4;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {
                label2.Text = "请输入数字";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "")
            {
                this.label2.Text = "没有输入数字请重试";
                return;
            }
            checked
            {
                try {
                    yunsuan(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                }
                catch(OverflowException)
                {
                    label2.Text = "数字溢出，请重试";
                }
                
            }
        }
        private void yunsuan(int i, int j)
        {
            
                switch (s)
                {
                    case 1:

                        this.label2.Text = $"{i}+{j}={i + j}";
                        return;
                    case 2:
                        this.label2.Text = $"{i}-{j}={i - j}";
                        return;
                    case 3:
                        if (i > 0 && j > 0 && i * j < 0)
                        {
                            label2.Text = "数字溢出，请重试";
                            return;
                        }
                        this.label2.Text = $"{i}*{j}={i * j}";
                        return;
                    case 4:
                        if (j == 0)
                        {
                            label2.Text = "被除数不可为0";
                            return;
                        }
                        this.label2.Text = $"{i}/{j}={i / j}";
                        return;
                }
            
        }
    }
}
