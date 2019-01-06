using System;
using AOPDemo.DynamicProxy;
using AOPDemo.Decorator;
using Castle.DynamicProxy;

namespace AOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var order1 = new Order { Id = 1, Name = "Coffee", Count = 4, Price = 80, Desc = "take away" };
            var order2 = new Order { Id = 2, Name = "Unknown", Count = 1, Price = -10, Desc = "" };

            IOrderProcessor orderProcessor =
             new Decorator.LoggingAspect(new Decorator.PerformanceAspect(new Decorator.OrderProcessor()));
            orderProcessor.Submit(order2);

            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            var proxyGenerator = new ProxyGenerator();
            IOrderProcessor orderProcessor2 =
                proxyGenerator.CreateClassProxy<DynamicProxy.OrderProcessor>(
                    new DynamicProxy.PerformanceAspect(),
                    new DynamicProxy.LoggingAspect());
            orderProcessor2.Submit(order2);

            Console.ReadLine();
        }
    }
}









