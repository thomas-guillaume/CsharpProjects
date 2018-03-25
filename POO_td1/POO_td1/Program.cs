using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td1
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p1 = new Personne("Holly", "Pierre", false, 1945, "celibataire");
            Console.WriteLine(p1.message());
            Console.ReadLine();
        }
    }
}
