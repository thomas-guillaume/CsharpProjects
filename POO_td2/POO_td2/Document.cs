using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Document
    {
        protected int num_enregistrement;
        protected string titre;


        public Document(int NUM_ENREGISTREMENT, string TITRE)
        {
            this.num_enregistrement = NUM_ENREGISTREMENT;
            this.titre = TITRE;
        }


        public int Num
        {
            get{ return this.num_enregistrement; }
            set{ this.num_enregistrement = value; }
        }
        public string Titre
        {
            get{ return this.titre; }
            set{ this.titre = value; }
        }


        public override string ToString()
        {
            return "Numero d'enregistrement : " + this.num_enregistrement + "; Titre : " + this.titre;
        }
    }
}
