using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using crawler;

namespace _2020_4_13_one
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.BeginUpdate();
            listBox1.Items.Add("请输入爬取网站");
            richTextBox1.Text = "爬取信息:"; 
            richTextBox1.Multiline = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.SelectionBullet = true;
        }
        private void Crawler_PageDownloaded(string obj)
        {
            
            if (this.listBox1.InvokeRequired)
            {
                Action<String> action = this.AddUrl;
                this.Invoke(action, new object[] { obj });
            }
            else
            {
                listBox1.Items.Add(obj);
            }
        }
        private void richinput(string inf)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                Action<String> action = this.Addinf;
                this.Invoke(action, new object[] { inf });
            }
            else
            {
                richTextBox1.Text += ("\n"+ inf);
            }
        }
        private void Addinf(string inf)
        {
            richTextBox1.Text += ("\n" + inf);
        }
        private void AddUrl(string url)
        {
            listBox1.Items.Add(url);
        }
        private void end()
        {
            MessageBox.Show("爬取结束了");
        }
        private bool lie()
        {
            string html = textBox1.Text;
            string RegexStr = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&:/~\+#]*[\w\-\@?^=%&/~\+#])?";
            if (Regex.IsMatch(textBox1.Text, RegexStr))
            {
                return true;
            }
            else
            {
                MessageBox.Show("网站格式不正确，请重新输入");
                return false;
            }
        }
        private void startcrawler(string path)
        {
            this.listBox1.Items.Clear();
            SimpleCrawler myCrawler = new SimpleCrawler(path,int.Parse(textBox2.Text),textBox1.Text);
            myCrawler.up += Crawler_PageDownloaded;
            myCrawler.endcrawler += end;
            myCrawler.inp += richinput;
            myCrawler.urls.Add(textBox1.Text, false);//加入初始页面
            new Thread(myCrawler.Crawl).Start();
            MessageBox.Show("开始爬取");
        }

        private void MyCrawler_up(object sender, SimpleCrawler args)
        {
            throw new NotImplementedException();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = true;
            richTextBox1.Text = "爬取信息:";
            if (!lie()) return;
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = folderBrowserDialog1.SelectedPath;
                startcrawler(filename);
                return;
            }
            else
            {
                MessageBox.Show("文件流出错");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }
    }
}
