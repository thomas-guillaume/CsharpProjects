using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Roman : Livre
    {
        private string prix;


        public Roman(string PRIX, string AUTEUR, int NB_PAGE, int NUMERO, string TITLE) : base(AUTEUR, NB_PAGE, NUMERO, TITLE)
        {
            this.prix = PRIX;
        }


        public string Prix
        {
            get{ return this.prix; }
            set{ this.prix = value; }
        }


        public override string ToString()
        {
            return "Prix : " + this.prix + "; Numero d'enregistrement : " + this.num_enregistrement + "; Titre : " + this.titre + "; Auteur : " + this.auteur + "; Nombre de page : " + this.nb_page;
        }
    }
}
