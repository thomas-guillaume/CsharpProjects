using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    class Texte : Figure, ITranslation, IRotation
    {
        private string contenu;
        private string x;
        private string y;


        public Texte(string type, string idElement, string x, string y, string contenu, string[] couleur, int ordre, string transformation) : base(type, idElement, couleur, ordre, transformation)
        {
            this.x = x;
            this.y = y;
            this.contenu = contenu;
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
                return "    <text x=\"" + this.x + "\" y=\"" + this.y + "\" fill=\"rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" >" + this.contenu + "</text>";
            else
                return "    <text x=\"" + this.x + "\" y=\"" + this.y + "\" fill=\"rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" transform=\"" + this.transformation + "\" >" + this.contenu + "</text>";
        }
    }
}
