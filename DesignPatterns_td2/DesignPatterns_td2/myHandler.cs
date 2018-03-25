using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns_td2
{
    class myHandler
    {
        static void Function()
        {
            int[] tab = null;
            int nbThreads = 4;

            Thread[] threads = new Thread[nbThreads];

            int n;
            for (n = 0; n < nbThreads; n++)
            {
                myHandler handler = new myHandler();
                handler.begins = null; //inclus
                handler.End = null; //exclus
                handler.array = tab;

                threads[n] = new Thread(handler.ThreadProc);
                threads[n].Start();
            }
            for (n = 0; n < nbThreads; n++)
            {
                threads[n].Join();
            }
        }
    }
}
