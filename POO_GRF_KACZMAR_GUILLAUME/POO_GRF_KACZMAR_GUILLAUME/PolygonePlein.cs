using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    class PolygonePlein : Figure, IRotation
    {
        private string points;


        public PolygonePlein(string type, string idElement, string points, string[] couleur, int ordre, string transformation) : base(type, idElement, couleur, ordre,transformation)
        {
            this.points = points;
        }


        public void Rotation(string alpha, string cx, string cy)
        {
            this.transformation += "rotate(" + alpha + " " + cx + "," + cy + ")";
        }


        public override string ToString()
        {
            if (transformation == "")
                return "    <polygon points=\"" + this.points + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" />";
            else
                return "    <polygon points=\"" + this.points + "\" style=\"fill:rgb(" + this.couleur[0] + "," + this.couleur[1] + "," + this.couleur[2] + ")\" transform=\"" + this.transformation + "\" />";
        }
    }
}
