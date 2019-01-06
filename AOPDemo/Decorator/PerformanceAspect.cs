using System;
using System.Diagnostics;

namespace AOPDemo.Decorator
{
    public class PerformanceAspect : IOrderProcessor
    {
        public IOrderProcessor OrderProcessor { get; set; }

        public PerformanceAspect(IOrderProcessor orderProcessor)
        {
            OrderProcessor = orderProcessor;
        }

        public void Submit(Order order)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            OrderProcessor.Submit(order);
            stopwatch.Stop();
            Console.WriteLine($"Method: Submit, Execution Time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
