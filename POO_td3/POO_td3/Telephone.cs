using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td3
{
    class Telephone : IComparable
    {
        protected string marque;
        protected string numero;


        public Telephone(string Mq, string Num)
        {
            this.marque = Mq;
            this.numero = Num;
        }


        public string Marque
        {
            get { return this.marque; }
            set { this.marque = value; }
        }
        public string Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }


        public override string ToString()
        {
            return "Marque : " + this.marque + "; Numero : " + this.numero;
        }

        public int CompareTo(object obj)
        {
            Telephone other = obj as Telephone;
            return this.numero.CompareTo(other);
        }
    }
}
