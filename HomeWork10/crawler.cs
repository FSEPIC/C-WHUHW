using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace crawler
{
    class URL
    {
        public bool use;
        public string urlm;
        public URL(string u, bool b)
        {
            use = b;
            urlm = u;
        }
        public void setuse(bool set)
        {
            use = set;
        }
        public void seturlm(string set)
        {
            urlm = set;
        }
    }
    class SimpleCrawler
    {
        public List<URL> urls = new List<URL>();
        public int count = 0;
        public string path;
        private int maxcount = 10;
        private string starturl = "";
        private string urlss = "";
        /*static void Main(string[] args) {
          SimpleCrawler myCrawler = new SimpleCrawler();
          string startUrl = "http://www.cnblogs.com/dstang2000/";
          if (args.Length >= 1) startUrl = args[0];
          myCrawler.urls.Add(startUrl, false);//加入初始页面
          new Thread(myCrawler.Crawl).Start();
        }*/
        public delegate void updata(string obj);
        public event updata up;
        public delegate void end();
        public event end endcrawler;
        public delegate void input(string inf);
        public event input inp;
        public SimpleCrawler(string paths, int n,string url)
        {
            URL su = new URL(url, false);
            urls.Add(su);
            path = paths;
            maxcount = n;
            int a = 0;
            a = url.IndexOf("com");
            a += 3;
            if (a == 3)
            {
                a = 0;
                a= url.IndexOf("cn");
                a += 2;
                if (a == 2)
                {
                    a = 0;
                    a = url.IndexOf("net");
                    a += 3;
                }
            }
            for (int i = 0; i < a; i++)
            {
                starturl += url[i];
            }
        }
        public void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                List<Task> tasks = new List<Task>();
                string current = null;
                for (int i =0;i<urls.Count;i++) { 
                    if (urls[i].use) continue;
                    current = urls[i].urlm;
                    urls[i].setuse(true);
                    Task task = new Task(() =>
                    {
                        crawls(current);
                    });
                    task.Start();
                    tasks.Add(task);
                    break;
                }
                Task.WaitAll(tasks.ToArray());
                if (current == null || count > maxcount - 1) { endcrawler(); break; }
            }
        }
        public void crawls(string current)
        {
            inp("爬行" + current + "页面!");
            Console.WriteLine("爬行" + current + "页面!");
            string html = DownLoad(current, path); // 下载
            count++;
            Parse(html);//解析,并加入新的链接
            inp("爬行结束");
            Console.WriteLine("爬行结束");
        }
        public string DownLoad(string url, string path)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                up(url);
                fileName = path + "\\" + fileName;
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                inp(ex.Message);
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        private bool findsam(string s)
        {
            int k = 0;
            Parallel.For(0,urls.Count,thing =>
            {
                for (int i=0;i>urls.Count;i++) {
                    if (s == urls[i].urlm)
                    {
                        k=1;//存在相同网站
                    }
                }
            });
            if (k == 1) return true;
            return false;
        }
        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            if (Regex.IsMatch(starturl, "http"))
            {
                string a = starturl;
                urlss = "https";
                for (int i = 4; i < starturl.Length; i++)
                {
                    urlss += starturl[i];
                }
            }
            if (Regex.IsMatch(starturl, "https")) {
                string a = starturl;
                urlss = "https";
                for (int i = 5; i < starturl.Length; i++)
                {
                    urlss += starturl[i];
                }
            }
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (!findsam(strRef))
                {
                    if (Regex.IsMatch(strRef, starturl) || strRef.IndexOf("/") == 0 || Regex.IsMatch(strRef, urlss))
                    {
                        if (strRef.IndexOf("/") == 0)
                        {
                            string a = strRef;
                            strRef = starturl + a;
                        }
                        URL u = new URL(strRef, false);
                        urls.Add(u);
                    }
                }
            }
        }
    }
}
