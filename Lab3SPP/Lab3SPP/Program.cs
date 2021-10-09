using System;
using System.Threading;

namespace Lab3SPP
{
    class Program
    {
        public static int x = 0;
        public static CustomMutex m = new CustomMutex();
        static void Main(string[] args)
        {
            for(int i = 0; i<7; i++)
            {
                Thread thr = new Thread(count) { Name = $"thread {i}" };
                thr.Start();
            }
            Console.ReadLine();
        }
        public static void count()
        {
            m.Lock();
            x = 1;
            for(int i = 0; i<5; i++)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {x}");
                Thread.Sleep(100);
                x++;
            }
            m.Unlock();
        }
    }
}
