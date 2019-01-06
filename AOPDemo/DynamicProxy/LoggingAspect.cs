using System;
using Castle.DynamicProxy;

namespace AOPDemo.DynamicProxy
{
    public class LoggingAspect:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                preProceed(invocation);
                invocation.Proceed();
                postProceed(invocation);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
            finally
            {
                Console.WriteLine("Release resource ...");
            }
        }

        private void preProceed(IInvocation invocation)
        {
            var order = invocation.Arguments[0] as Order;
            Console.WriteLine("Before submitting, do order validation...");
            if (order.Price < 0)
            {
                Console.WriteLine("Invalid price, validation failed ,please verify the order.");
            }
        }

        private void postProceed(IInvocation invocation)
        {
            var order = invocation.Arguments[0] as Order;
            Console.WriteLine("After submitting, log the order history.");
            Console.WriteLine($"{DateTime.Now.ToLongDateString()} order submitted," +
                $" name: {order.Name} , price: {order.Price}");
        }
    }
}
