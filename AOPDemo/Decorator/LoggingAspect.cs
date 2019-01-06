using System;
namespace AOPDemo.Decorator
{
    public class LoggingAspect : IOrderProcessor
    {
        public IOrderProcessor OrderProcessor { get; set; }
        public LoggingAspect(IOrderProcessor orderProcessor)
        {
            OrderProcessor = orderProcessor;
        }

        public void Submit(Order order)
        {
            preProceed(order);
            OrderProcessor.Submit(order);
            postProceed(order);
        }

        private void preProceed(Order order)
        {
            Console.WriteLine("Before submitting, do order validation...");
            if (order.Price < 0)
            {
                Console.WriteLine("Invalid price, validation failed ,please verify the order.");
            }
        }

        private void postProceed(Order order)
        {
            Console.WriteLine("After submitting, log the order history.");
            Console.WriteLine($"{DateTime.Now.ToLongDateString()} order submitted," +
                $" name: {order.Name} , price: {order.Price}");
        }
    }
}
