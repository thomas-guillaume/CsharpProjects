using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    abstract class Figure : IComparable
    {
        protected string type;
        protected string idElement;
        protected string[] couleur;
        protected int ordre;
        protected string transformation;


        public Figure(string type, string idElement, string[] couleur, int ordre, string transformation)
        {
            this.type = type;
            this.idElement = idElement;
            this.couleur = couleur;
            this.ordre = ordre;
            this.transformation = "";
        }


        public string IdElement
        {
            get { return this.idElement; }
        }
        public string Type
        {
            get { return this.type; }
        }


        public int CompareTo(object figure)
        {
            if (figure == null)
                return 1;
            Figure fig = (Figure)figure;
            return ordre.CompareTo(fig.ordre);
        }
    }
}
