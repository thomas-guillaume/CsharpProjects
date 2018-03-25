using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td1
{
    class Personne
    {
        //Attributs
        private string nom;
        private string prenom;
        private bool sexe;
        private int anneeNaiss;
        private string statut;


        //Constructeurs
        public Personne(string nom, string prenom, bool sexe, int anneeNaiss, string statut)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.anneeNaiss = anneeNaiss;
            this.statut = statut;
        }

        public Personne(string nom, string prenom, bool sexe, int anneeNaiss)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.anneeNaiss = anneeNaiss;
            this.statut = "inconnu";
        }


        //Propriétés
        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public String Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }
        public int AnneeNaiss
        {
            get { return this.anneeNaiss; }
            set { this.anneeNaiss = value; }
        }
        public int Age
        {
            get { return 2017 - AnneeNaiss; }
        }

        public string Statut
        {
            get { return this.statut; }
            set { this.statut = value; }
        }


        //Méthodes
        public int RetournerAgeEn(int anneeRef)
        {
            return (anneeRef - anneeNaiss);
        }

        public bool PlusVieuxQue(int ageRef)
        {
            if (2017 - anneeNaiss > ageRef)
            {
                return true;
            }
            else
                return false;
        }

        public bool PlusVieuxQue(Personne pRef)
        {
            if (pRef.anneeNaiss < this.anneeNaiss)
                return true;
            else
                return false;
        }

        public String message()
        {
            if (this.sexe == true)
                return (this.nom + " " + this.prenom + " est né en " + this.anneeNaiss + ", il est " + this.statut + ".");
            else
                return (this.nom + " " + this.prenom + " est née en " + this.anneeNaiss + ", elle est " + this.statut + ".");
        }
    }
}
