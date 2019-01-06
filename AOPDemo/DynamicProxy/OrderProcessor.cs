using System;
namespace AOPDemo.DynamicProxy
{
    public class OrderProcessor:IOrderProcessor
    {
        public Order CurrentOrder { get; set; }

        public virtual void Submit(Order order)
        {
            CurrentOrder = order;
            Console.WriteLine("Order submitted.");
        }
    }
}
