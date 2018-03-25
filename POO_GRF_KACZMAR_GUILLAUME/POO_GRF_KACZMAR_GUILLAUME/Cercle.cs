using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    class Cercle : Figure, ITranslation
    {
        private string cx;
        private string cy;
        private string r;


        public Cercle(string type, string idElement, string cx, string cy, string r, string[] couleur, int ordre,string transformation) : base(type, idElement, couleur, ordre, transformation)
        {
            this.cx = cx;
            this.cy = cy;
            this.r = r;
        }


        public void Translation(string dx, string dy)
        {
            this.transformation += "translate(" + dx + "," + dy + ")";
        }


        public override string ToString()
        {
            if (transformation=="")
                return "    <circle cx=\"" + this.cx + "\" cy=\"" + this.cy + "\" r=\"" + this.r + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" />";
            else
                return "    <circle cx=\"" + this.cx + "\" cy=\"" + this.cy + "\" r=\"" + this.r + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" transform=\"" + this.transformation + "\" />";
        }
    }
}
