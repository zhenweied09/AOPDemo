using System;
using System.Diagnostics;
using System.Threading;
using Castle.DynamicProxy;

namespace AOPDemo.DynamicProxy
{
    public class PerformanceAspect:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();
            Console.WriteLine($"Method: {invocation.Method.Name} Execution Time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
