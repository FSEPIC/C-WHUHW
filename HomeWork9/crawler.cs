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
    
    class SimpleCrawler
    {
        public Hashtable urls = new Hashtable();
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
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                    break;
                }
                if (current == null || count > maxcount - 1) {endcrawler(); break; }
                inp("爬行" + current + "页面!");
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current, path); // 下载
                urls[current] = true;
                count++;
                Parse(html);//解析,并加入新的链接
                inp("爬行结束");
                Console.WriteLine("爬行结束");
            }
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
                if (urls[strRef] == null)
                {
                    if (Regex.IsMatch(strRef, starturl) || strRef.IndexOf("/") == 0 || Regex.IsMatch(strRef, urlss))
                    {
                        if (strRef.IndexOf("/") == 0)
                        {
                            string a = strRef;
                            strRef = starturl + a;
                        }
                        urls[strRef] = false;//不含有html初始地址，就加入进去,不是本域名不加入进去***
                    }
                }
            }
        }
    }
}
