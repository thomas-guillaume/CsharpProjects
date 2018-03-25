using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td3
{
    class TelFixe : Telephone
    {
        private string bureau;


        public TelFixe(string Mq, string Num, string Bureau) : base(Mq, Num)
        {
            this.bureau = Bureau;
        }


        public string Bureau
        {
            get { return this.bureau; }
            set { this.bureau = value; }
        }


        public override string ToString()
        {
            return "Marque : " + this.marque + "; Numero : " + this.numero + "; Bureau : " + this.bureau;
        }
    }
}
