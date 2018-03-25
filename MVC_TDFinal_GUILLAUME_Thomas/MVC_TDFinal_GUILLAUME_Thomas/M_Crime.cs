using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TDFinal_GUILLAUME_Thomas
{
    public class M_Crime
    {
        private string date;
        private string borough;
        private string coord_X;
        private string coord_Y;
        private string description;
        private string desc_specificity;
        private string jurisdiction;


        //Constructeur
        public M_Crime(string DATE, string BOROUGH, string X, string Y, string DESCRIPTION, string DESC_SPECIFICITY, string JURISDICTION)
        {
            this.date = DATE;
            this.borough = BOROUGH;
            this.coord_X = X;
            this.coord_Y = Y;
            this.description = DESCRIPTION;
            this.desc_specificity = DESC_SPECIFICITY;
            this.jurisdiction = JURISDICTION;
        }


        //Accesseurs
        public string Date
        {
            get { return this.date; }
        }
        public string Quartier
        {
            get { return this.borough; }
        }
        public string X
        {
            get { return this.coord_X; }
        }
        public string Y
        {
            get { return this.coord_Y; }
        }
        public string Description
        {
            get { return this.description; }
        }
        public string Description_spe
        {
            get { return this.desc_specificity; }
        }
        public string Jurisdiction
        {
            get { return this.jurisdiction; }
        }


        //Redéfinition du ToString
        public override string ToString()
        {
            return this.date + " ; " + this.borough + " ; " + this.coord_X + " ; " + this.coord_Y + " ; " + this.description + " ; " + this.desc_specificity + " ; " + this.jurisdiction;
        }
    }
}
