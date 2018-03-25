using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    class Chemin : Figure, IRotation
    {
        private string path;


        public Chemin(string type, string idElement, string path, string[] couleur, int ordre, string transformation) : base(type, idElement, couleur, ordre, transformation)
        {
            this.path = path;
        }


        public void Rotation(string alpha, string cx, string cy)
        {
            this.transformation += "rotate(" + alpha + " " + cx + "," + cy + ")";
        }


        public override string ToString()
        {
            if (transformation == "")
                return "    <path d=\"" + this.path + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" />";
            else
                return "    <path d=\"" + this.path + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" transform=\"" + this.transformation + "\" />";
        }
    }
}
