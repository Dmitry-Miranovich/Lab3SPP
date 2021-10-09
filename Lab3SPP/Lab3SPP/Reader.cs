using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab3SPP
{
    public class SemaphoreCheck : ICustom
    {
        public void doTask()
        {
            for (int i = 1; i < 6; i++)
            {
                Reader reader = new Reader(i);
            }
            Console.ReadLine();
        }
    }

    class Reader
    {
        static Semaphore sem = new Semaphore(1, 3);
        Thread myThread;
        int count = 2;// счетчик чтения

        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Читатель {i.ToString()}";
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                sem.Release();

                count--;
                Thread.Sleep(1000);
            }
        }
    }
}
