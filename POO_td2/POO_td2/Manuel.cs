using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Manuel : Livre
    {
        private int niv_scol;


        public Manuel(int NIV_SCOL, string AUTEUR, int NB_PAGE, int NUMERO, string TITLE) : base(AUTEUR, NB_PAGE, NUMERO, TITLE)
        {
            this.niv_scol = NIV_SCOL;
        }


        public int Niveau
        {
            get{ return this.niv_scol; }
            set{ this.niv_scol = value; }
        }


        public override string ToString()
        {
            return "Niveau scolaire : " + this.niv_scol + "; Numero d'enregistrement : " + this.num_enregistrement + "; Titre : " + this.titre + "; Auteur : " + this.auteur + "; Nombre de page : " + this.nb_page;
        }
    }
}
