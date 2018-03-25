using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Livre : Document
    {
        protected string auteur;
        protected int nb_page;


        public Livre(string AUTEUR, int NB_PAGE, int NUMERO, string TITLE) : base(NUMERO, TITLE)
        {
            this.auteur = AUTEUR;
            this.nb_page = NB_PAGE;
        }


        public string Auteur
        {
            get{ return this.auteur; }
            set{ this.auteur = value; }
        }


        public override string ToString()
        {
            return "Auteur : " + this.auteur + "; Nombre de page : " + this.nb_page + "; Numero d'enregistrement : " + this.num_enregistrement + "; Titre : " + this.titre;
        }
    }
}
