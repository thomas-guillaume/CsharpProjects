using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Bibliotheque
    {
        private int nb_max;
        private List<Etagere> list_etagere;

        
        public Bibliotheque(int NB)
        {
            this.nb_max = NB;
            this.list_etagere = new List<Etagere>();
        }


        public int NbMax
        {
            get{ return this.nb_max; }
            set{ this.nb_max = value; }
        }
        public List<Etagere> ListEta
        {
            get{ return this.list_etagere; }
            set{ this.list_etagere = value; }
        }

        
        public void AddEtagere(Etagere eta)
        {
            if (nb_max > this.list_etagere.Count())
            {
                this.list_etagere.Add(eta);
            }
            else
            {
                Console.WriteLine("Pas de place.");
            }
        }


        public void suppEtagere(int num)
        {
            bool ind = false;
            int i = 0;
            while (i < this.list_etagere.Count() && ind == false)
            {
                if (this.list_etagere.ElementAt(i).NumEta == num)
                {
                    this.list_etagere.RemoveAt(i);
                    ind = true;
                }
                i++;
            }
        }


        public override string ToString()
        {
            return "Nombre max d'etageres : " + this.nb_max + "; Liste des etageres : " + this.list_etagere;
        }
    }
}
