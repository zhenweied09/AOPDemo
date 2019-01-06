using System;
namespace AOPDemo.Decorator
{
    public class OrderProcessor : IOrderProcessor
    {
        public void Submit(Order order)
        {
            Console.WriteLine("Order submitted.");
        }
    }
}
