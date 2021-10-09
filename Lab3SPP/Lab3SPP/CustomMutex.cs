using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab3SPP
{
    public class CustomMutex
    {
        public CustomSemaphore sem = new CustomSemaphore();
        public void Lock()
        {
            sem.WaitOne();

        }
        public void Unlock()
        {
            sem.Release();
        }
    }
}
