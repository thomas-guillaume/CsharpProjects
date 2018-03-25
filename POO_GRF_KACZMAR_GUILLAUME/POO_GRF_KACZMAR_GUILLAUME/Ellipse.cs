using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    class Ellipse : Figure, ITranslation, IRotation
    {
        private string x;
        private string y;
        private string rx;
        private string ry;


        public Ellipse(string type, string idElement, string x, string y, string rx, string ry, string[] couleur, int ordre, string transformation) : base(type, idElement, couleur, ordre,transformation)
        {
            this.x = x;
            this.y = y;
            this.rx = rx;
            this.ry = ry;
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
                return "    <ellipse cx=\"" + this.x + "\" cy=\"" + this.y + "\" rx=\"" + this.rx + "\" ry=\"" + this.ry + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" />";
            else
                return "    <ellipse cx=\"" + this.x + "\" cy=\"" + this.y + "\" rx=\"" + this.rx + "\" ry=\"" + this.ry + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" transform=\"" + this.transformation + "\" />";
        }
    }
}
