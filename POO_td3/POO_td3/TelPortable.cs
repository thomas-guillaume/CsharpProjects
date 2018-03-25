using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td3
{
    class TelPortable : Telephone
    {
        private string nom;


        public TelPortable(string Mq, string Num, string Nom) : base(Mq, Num)
        {
            this.nom = Nom;
        }


        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }


        public override string ToString()
        {
            return "Marque : " + this.marque + "; Numero : " + this.numero + "; Proprietaire : " + this.nom;
        }
    }
}
