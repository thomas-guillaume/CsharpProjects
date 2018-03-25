using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Program
    {
        static void AjoutElement(List<double> ls, double val)
        {
            ls.Add(val);
        }

        static void InsertionElement(List<double> ls, double val, int index)
        {
            ls.Insert(index, val);
        }

        static void Suppression(List<double> ls, int index)
        {
            ls.RemoveAt(index);
        }

        static void TriList(List<double> ls)
        {
            ls.Sort();
        }

        static void Inversion(List<double> ls)
        {
            ls.Reverse();
        }

        void AffichageElementElement(List<double> ls)
        {
            for (int i = 0; i < ls.Count; i++)
            {
                Console.Write(ls.ElementAt(i) + " ");
            }
            Console.WriteLine();
        }

        static void AffichageList(List<double> ls)
        {
            foreach (double a in ls)
                Console.Write(a + " ");
            Console.WriteLine();
        }



        static void exo1()
        {
            List<double> lst = new List<double>();
            AjoutElement(lst, 10.3);
            AjoutElement(lst, 20.3);
            AjoutElement(lst, 5.4);
            InsertionElement(lst, 1.5, 3);
            InsertionElement(lst, 100, 4);
            Suppression(lst, 0);
            TriList(lst);
            Inversion(lst);
            AffichageList(lst);
        }
        

        static void Main(string[] args)
        {
            exo1();
            Console.ReadLine();
        }
    }
}
