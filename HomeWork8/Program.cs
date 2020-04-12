using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using order;
namespace _2020_4_6_one
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            OrderService orderService = new OrderService();
            for (int i = 0; i < 100; i++)
            {
                orderService.addorder(i, i + 10, "洗洁精", "admin", 5);
            }
            orderService.listeach(o => o.addorderitem(2, 10, 10, "钢丝球"));
            orderService.addorder(3, 3 + 10, "洗洁精", "最小价格最后添加", 1);
            List<Order> or = orderService.findmoneyorder(0);
            //orderService.listeach(o => Console.WriteLine(o.totalmoney()));
            /*for (int i = 0; or != null && i < or.Count; i++)
            {
                Console.WriteLine(or[i]);
            }*/
            //orderService.listeach(o=> Console.WriteLine(o));
            //orderService.listeach(o => orderService.reviseorder(1,1,100));
            //orderService.listeach(o => Console.WriteLine(o));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(orderService));
        }
    }
}
