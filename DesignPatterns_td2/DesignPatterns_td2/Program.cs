using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DesignPatterns_td2
{
    class Program
    {
        static void Exo1()
        {
            Thread myThread = new Thread(new ThreadStart(Foo));
            //Or more simply : myThread = new Thread(Sample.Foo);
            myThread.Start();
        }
        static void Foo()
        {
            Console.WriteLine("Foo procedure.");
        }



        static void Exo2()
        {
            Thread myThread = new Thread(Foo2);
            myThread.Start(); // Run Foo on the new thread

            //Simultaneously run Bar in the main thread
            Bar();
        }
        static void Foo2()
        {
            for (int i = 0; i < 1000; i++)
                Console.Write("#");
        }
        static void Bar()
        {
            for (int i = 0; i < 1000; i++)
                Console.Write(".");
        }



        static void Exo3()
        {
            Thread myThread = new Thread(Foo3);
            myThread.Start();
            Bar3();
        }
        static void Foo3()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("#");
                Thread.Yield(); //Ok to skip my turn (if needed)
            }
        }
        static void Bar3()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(".");
                Thread.Yield(); //Ok to skip my turn (if needed)
            }
        }



        static void Exo4()
        {
            Console.WriteLine("Beginning at {0:hh:mm:ss}", DateTime.Now);
            Thread.Sleep(2000); //2s
            Console.WriteLine("End at {0:hh:mm:ss}", DateTime.Now);
        }



        static Random rand = new Random();
        static void Exo5()
        {
            Thread thread1 = new Thread(Foo5);
            thread1.Name = "Thread 1";
            thread1.Start();

            Thread thread2 = new Thread(Foo5);
            thread2.Name = "Thread 2";
            thread2.Start();

            if (thread1.IsAlive)
            {
                bool b1 = thread1.Join(500); //wait until tread1 are stopped
            }
            if (thread2.IsAlive)
            {
                bool b2 = thread2.Join(1000); //wait until tread2 are stopped
            }

            Console.WriteLine("All treads are completed.");
        }
        static void Foo5()
        {
            Console.WriteLine("Beginning of " + Thread.CurrentThread.Name);
            Thread.Sleep(rand.Next(2000,5000)); //between 2 and 5 s
            Console.WriteLine("End of " + Thread.CurrentThread.Name);
        }



        public static void Exo6()
        {
            MyThreadHandler handler = new MyThreadHandler();
            handler.Parameter = 15;

            Thread myThread = new Thread(handler.ThreadProc);
            myThread.Start();

            myThread.Join();
            Console.WriteLine("The power of 15 is " + handler.Result);
        }



        /*public static void Exo7()
        {
            int[] table = GenerateArray(6, 0, 10);
            int somme = 0;
            for (int i = 0; i < table.Length; i++)
            {
                somme += table[i];
            }
            Console.WriteLine(somme);
        }
        // A method that generates a random array of integers in the interval [valueMin,valueMax]
        static int[] GenerateArray(int size, int valueMin, int valueMax)
        {
            int[] result = null;
            if ((size > 0) && (valueMin < valueMax))
            {
                result = new int[size];
                Random rand = new Random(); // random generator
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = rand.Next(valueMin, valueMax + 1); // new integer in the interval [valueMin,valueMax]
                }
            }

            return result;
        }*/


        static void Main(string[] args)
        {
            Exo6();
            Console.ReadKey(); //In debug mode (F5)
        }
    }
}
