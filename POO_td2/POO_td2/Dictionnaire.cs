using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Dictionnaire : Livre
    {
        private string langue;


        public Dictionnaire(string LANGUE, string AUTEUR, int NB_PAGE, int NUMERO, string TITLE) : base(AUTEUR, NB_PAGE, NUMERO, TITLE)
        {
            this.langue = LANGUE;
        }


        public string Langue
        {
            get{ return this.langue; }
            set{ this.langue = value; }
        }


        public override string ToString()
        {
            return "Langue : " + langue + "; Numero d'enregistrement : " + num_enregistrement + "; Titre : " + titre + auteur + "; Nombre de page : " + nb_page;
        }
    }
}
