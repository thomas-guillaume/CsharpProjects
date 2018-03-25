using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    class Rectangle : Figure, ITranslation, IRotation
    {
        private string x;
        private string y;
        private string l;
        private string h;


        public Rectangle(string type, string idElement, string x, string y, string l, string h, string[] couleur, int ordre, string transformation) : base(type, idElement, couleur, ordre,transformation)
        {
            this.x = x;
            this.y = y;
            this.l = l;
            this.h = h;
        }


        public void Translation(string dx, string dy)
        {
            this.transformation += "translate(" + dx + "," + dy + ")";
        }
        public void Rotation(string alpha, string cx, string cy)
        {
            this.transformation += "rotate(" + alpha + " " + cx + "," + cy + ")";
        }


        public override string ToString()
        {
            if (transformation == "")
                return "    <rect x=\"" + this.x + "\" y=\"" + this.y + "\" width=\"" + this.l + "\" height=\"" + this.h + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" />";
            else
                return "    <rect x=\"" + this.x + "\" y=\"" + this.y + "\" width=\"" + this.l + "\" height=\"" + this.h + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" transform=\"" + this.transformation + "\" />";
        }
    }
}
