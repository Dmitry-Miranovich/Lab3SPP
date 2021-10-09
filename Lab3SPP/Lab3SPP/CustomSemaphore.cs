using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab3SPP
{
    public class CustomSemaphore
    {
        private int value = 1;
        private Queue<Thread> pool = new Queue<Thread>();
        public void WaitOne()
        {
            if (value != 1)
            {
                try
                {
                    Monitor.Enter(pool);
                    pool.Enqueue(Thread.CurrentThread);
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException)
                {
                    Monitor.Exit(pool);
                }
            }
            Interlocked.CompareExchange(ref value, 0, 1);
        }
        public void Release()
        {
            if(pool.Count == 0)
            {
                value = 1;
            }
            else
            {
                pool.Dequeue().Interrupt();
            }
        }
    }
}
