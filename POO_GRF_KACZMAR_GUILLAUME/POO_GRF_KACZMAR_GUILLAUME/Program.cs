using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    class Program
    {
        static void Main(string[] args)
        {
            Dessin dessin = new Dessin();
            List<Figure> liste = new List<Figure>();
            liste = dessin.LectureFichier("MM.csv");
            dessin.EcritureFichier("MM.svg", liste);
            Console.ReadKey();
        }
    }
}
