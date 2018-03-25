using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_td4
{
    class Artiste
    {
        private string nom;
        private string prenom;
        private string surnom;

        public Artiste(string nom, string prenom, string surnom)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.surnom = surnom;
        }

        // constructeur où le surnom n'est pas renseigné (il est donc initialisé à null)
        public Artiste(string nom, string prenom)
            : this(nom, prenom, null)
        {
        }



        override public string ToString()
        {
            string resultat = nom + " " + prenom;

            if (surnom != null)
            {
                resultat = surnom + " (" + resultat + ")";
            }

            return resultat;
        }
    }
}
