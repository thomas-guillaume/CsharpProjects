using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern_td3
{
    class Program
    {
        //Available throughout the practical work
        static Random rand = new Random();

        //Available for all threads of Exo1
        static int myCounter = 0;

        static Mutex myMutex = new Mutex();

        static void AddOne()
        {
            for (int n = 0; n < 50; n++)
            {
                myMutex.WaitOne();
                Thread.Sleep(rand.Next(10, 100)); //Do something (working simulation)
                int local = myCounter;

                Thread.Sleep(rand.Next(10, 100)); //Do something (working simulation)
                myCounter = local + 1;
                myMutex.ReleaseMutex();

                //To debug / to understand what's going on
                Console.WriteLine("Current Thread : " + Thread.CurrentThread.Name + " local : " + local + " counter : " + myCounter);
            }
        }

        static void Exo1()
        {
            Thread th1 = new Thread(AddOne);
            th1.Name = "#1";
            Thread th2 = new Thread(AddOne);
            th2.Name = "#2";

            th1.Start();
            th2.Start();

            th1.Join();
            th2.Join();

            Console.WriteLine("Counter : " + myCounter);
        }



        //Create a semaphore with 3 slots (where all are immediately available)
        static SemaphoreSlim doorman = new SemaphoreSlim(0,3);

        static void GoToTheBar()
        {
            Console.WriteLine("The person {0} want to go into the bar.", Thread.CurrentThread.Name);
            doorman.Wait();
            Console.WriteLine("The customer {0} has just entered the bar.", Thread.CurrentThread.Name);
            Thread.Sleep(rand.Next(2000, 5000)); //Simulation to have a drink
            Console.WriteLine("The customer {0} has just left the bar.", Thread.CurrentThread.Name);
            doorman.Release();
        }

        static void Exo3()
        {
            int nbThreads = 10;
            for (int n = 0; n < nbThreads; n++)
            {
                Thread th = new Thread(GoToTheBar);
                th.Name = Convert.ToString(n);
                th.Start();
            }

            Console.WriteLine("The Bar is closed.");
            Thread.Sleep(5000); //Simulation of closing time.
            Console.WriteLine("The Bar is open.");
            doorman.Release(3);
        }

        static void Main(string[] args)
        {
            Exo3();
            Console.ReadKey();
        }
    }
}
