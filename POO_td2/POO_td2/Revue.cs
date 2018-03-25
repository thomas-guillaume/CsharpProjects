using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Revue : Document
    {
        private int mois;
        private int annee;


        public Revue(int MOIS, int ANNEE, int NUMERO, string TITLE) : base(NUMERO, TITLE)
        {
            this.mois = MOIS;
            this.annee = ANNEE;
        }


        public int Mois
        {
            get{ return this.mois; }
            set{ this.mois = value; }
        }
        public int Annee
        {
            get{ return this.annee; }
            set{ this.annee = value; }
        }


        public override string ToString()
        {
            return "Mois : " + this.mois + "; Annee : " + this.annee + "; Numero d'enregistrement : " + this.num_enregistrement + "; Titre : " + this.titre;
        }
    }
}
