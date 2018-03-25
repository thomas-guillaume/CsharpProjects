using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_td1
{
    class Program
    {
        public static void Exo1()
        {
            // step 1
            A a1 = new A(1);
            A a2 = new A(2);
            AA aa1 = new AA(3);

            // step 2
            Vector vec = new Vector();

            vec.Add(a1);    // internal array of the vector has to be resized!
            vec.Add(a2);
            vec.Add(aa1);

            for (int i = 0; i < vec.Size(); i++)
            {
                A a = vec.ElementAt(i); // a points to the object at position i (indexing start from 0)
                Console.Write(a.Foo());
                Console.WriteLine(a); // <=> Console.WriteLine( a.ToString() );
            }

            // step 3
            Console.WriteLine();

            vec.Remove(a2);     // internal array of the vector may not be resized! May not it?
            vec.Add(new A(4));
            vec.Add(new AA(5));
            for (int i = 0; i < vec.Size(); i++)
            {
                Console.WriteLine(vec.ElementAt(i));
            }

        }

        public static void Exo1B()
        {
            // step 1
            A a1 = new A(1);
            A a2 = new A(2);
            AA aa1 = new AA(3);

            // step 2
            Vector vec = new Vector();

            vec.Add(a1);    // internal array of the vector has to be resized!
            vec.Add(a2);
            vec.Add(aa1);

            for (int i = 0; i < vec.Size(); i++)
            {
                A a = vec.ElementAt(i); // a points to the object at position i (indexing start from 0)
                Console.WriteLine(a); // <=> Console.WriteLine( a.ToString() );
            }

            // step 3
            Console.WriteLine();

            vec.Remove(a2);     // internal array of the vector may not be resized! May not it?
            vec.Add(new A(4));
            vec.Add(new AA(5));
            for (int i = 0; i < vec.Size(); i++)
            {
                Console.WriteLine(vec.ElementAt(i));
            }

        }


        static void Main(string[] args)
        {
            Exo1();
            Exo1B();
            Console.ReadKey();
        }
    }
}
