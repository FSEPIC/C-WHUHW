using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using order;
using System;
using System.Collections.Generic;
using System.Text;

namespace order.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void OrderServiceTest()
        {
            OrderService orderService = new OrderService();
            orderService.ToString();
            Console.WriteLine();
            Assert.Fail();
        }

        [TestMethod()]
        public void LambdasortTest()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = null;
            List<Order> otext = orderService.Lambdasort();
            Assert.AreEqual(orders, otext);
            Assert.Fail();
        }

        [TestMethod()]
        public void everyorderqeTest()
        {
            OrderService orderService = new OrderService();
            Order o = new Order();
            Assert.IsFalse(orderService.everyorderqe(o));
            Assert.Fail();
        }

        [TestMethod()]
        public void addorderTest()
        {
            OrderService orderService = new OrderService();
            orderService.addorder(1, 1, null, null, 1);
            Order o =orderService.findorder(1);
            Assert.AreEqual(o.orderuser, null);
            Assert.Fail();
        }

        [TestMethod()]
        public void detelorderTest()
        {
            OrderService orderService = new OrderService();
            Assert.IsFalse(orderService.detelorder(11));
            Assert.Fail();
        }

        [TestMethod()]
        public void findorderTest()
        {
            OrderService orderService = new OrderService();
            Assert.AreEqual(orderService.findorder(11),null);
            Assert.Fail();
        }

        [TestMethod()]
        public void reviseorderTest()
        {
            OrderService orderService = new OrderService();
            Assert.IsFalse(orderService.reviseorder(11,11,11));
            Assert.Fail();
        }

        [TestMethod()]
        public void listeachTest()
        {
            OrderService orderService = new OrderService();
            orderService.listeach(o => { throw new Exception(); });
            Assert.Fail();
        }

        [TestMethod()]
        public void findmoneyorderTest()
        {
            OrderService orderService = new OrderService();
            Assert.AreEqual(null,orderService.findmoneyorder(-3));
            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {
            OrderService orderService = new OrderService();
            Assert.IsTrue(orderService.Export());
            Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService orderService = new OrderService();
            orderService.Export();
            Assert.AreEqual(orderService.ret(), orderService.Import());
            Assert.Fail();
        }
    }
}