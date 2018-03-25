using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POO_GRF_KACZMAR_GUILLAUME
{
    class Dessin
    {
        public List<Figure> LectureFichier(string nomFichier)
        {
            List<Figure> liste = new List<Figure>();
            string ligne;
            string type;
            try
            {
                StreamReader reader = new StreamReader(nomFichier);
                while ((ligne = reader.ReadLine()) != null) // Lecture ligne par ligne du document
                {
                    string[] parametre = ligne.Split(';');
                    type = parametre[0];
                    switch (type) // Création d'un nouvel élément pour chaque ligne du document csv, selon son type, et l'ajouter à la liste
                    {
                        case "Cercle":
                            string idElement = parametre[1];
                            string cx = parametre[2];
                            string cy = parametre[3];
                            string r = parametre[4];
                            string[] couleur = new string[3];
                            couleur[0] = parametre[5];
                            couleur[1] = parametre[6];
                            couleur[2] = parametre[7];
                            int ordre = Convert.ToInt32(parametre[8]);
                            string transfo = "";
                            Cercle element = new Cercle(type, idElement, cx, cy, r, couleur, ordre, transfo);
                            liste.Add(element);
                            break;

                        case "Ellipse":
                            string idElement1 = parametre[1];
                            string x1 = parametre[2];
                            string y1 = parametre[3];
                            string rx1 = parametre[4];
                            string ry1 = parametre[5];
                            string[] couleur1 = new string[3];
                            couleur1[0] = parametre[6];
                            couleur1[1] = parametre[7];
                            couleur1[2] = parametre[8];
                            int ordre1 = Convert.ToInt32(parametre[9]);
                            string transfo1 = "";
                            Ellipse element1 = new Ellipse(type, idElement1, x1, y1, rx1, ry1, couleur1, ordre1, transfo1);
                            liste.Add(element1);
                            break;

                        case "Rectangle":
                            string idElement2 = parametre[1];
                            string x2 = parametre[2];
                            string y2 = parametre[3];
                            string l2 = parametre[4];
                            string h2 = parametre[5];
                            string[] couleur2 = new string[3];
                            couleur2[0] = parametre[6];
                            couleur2[1] = parametre[7];
                            couleur2[2] = parametre[8];
                            int ordre2 = Convert.ToInt32(parametre[9]);
                            string transfo2 = "";
                            Rectangle element2 = new Rectangle(type, idElement2, x2, y2, l2, h2, couleur2, ordre2, transfo2);
                            liste.Add(element2);
                            break;

                        case "Polygone":
                            string idElement3 = parametre[1];
                            string points3 = parametre[2];
                            string[] couleur3 = new string[3];
                            couleur3[0] = parametre[3];
                            couleur3[1] = parametre[4];
                            couleur3[2] = parametre[5];
                            int ordre3 = Convert.ToInt32(parametre[6]);
                            string transfo3 = "";
                            PolygonePlein element3 = new PolygonePlein(type, idElement3, points3, couleur3, ordre3, transfo3);
                            liste.Add(element3);
                            break;

                        case "Chemin":
                            string idElement4 = parametre[1];
                            string path4 = parametre[2];
                            string[] couleur4 = new string[3];
                            couleur4[0] = parametre[3];
                            couleur4[1] = parametre[4];
                            couleur4[2] = parametre[5];
                            int ordre4 = Convert.ToInt32(parametre[6]);
                            string transfo4 = "";
                            Chemin element4 = new Chemin(type, idElement4, path4, couleur4, ordre4, transfo4);
                            liste.Add(element4);
                            break;

                        case "Texte":
                            string idElement5 = parametre[1];
                            string x5 = parametre[2];
                            string y5 = parametre[3];
                            string contenu5 = parametre[4];
                            string[] couleur5 = new string[3];
                            couleur5[0] = parametre[5];
                            couleur5[1] = parametre[6];
                            couleur5[2] = parametre[7];
                            int ordre5 = Convert.ToInt32(parametre[8]);
                            string transfo5 = "";
                            Texte element5 = new Texte(type, idElement5, x5, y5, contenu5, couleur5, ordre5, transfo5);
                            liste.Add(element5);
                            break;

                        case "Translation":
                            string idElement6 = parametre[1];
                            string dx6 = parametre[2];
                            string dy6 = parametre[3];
                            foreach (Figure figure in liste)
                            {
                                if (idElement6 == figure.IdElement) // cast une figure en un type particulier pour pouvoir appliquer les transformations
                                {
                                    if (figure.Type == "Cercle")
                                    {
                                        Cercle cercle = (Cercle)figure;
                                        cercle.Translation(dx6, dy6);
                                    }
                                    if (figure.Type == "Ellipse")
                                    {
                                        Ellipse ellipse = (Ellipse)figure;
                                        ellipse.Translation(dx6, dy6);
                                    }
                                    if (figure.Type == "Rectangle")
                                    {
                                        Rectangle rectangle = (Rectangle)figure;
                                        rectangle.Translation(dx6, dy6);
                                    }
                                    if (figure.Type == "Texte")
                                    {
                                        Texte texte = (Texte)figure;
                                        texte.Translation(dx6, dy6);
                                    }
                                }
                            }
                            break;

                        case "Rotation":
                            string idElement7 = parametre[1];
                            string alpha7 = parametre[2];
                            string cx7 = parametre[3];
                            string cy7 = parametre[4];
                            foreach (Figure figure in liste)
                            {
                                if (idElement7 == figure.IdElement)
                                {
                                    if (figure.Type == "Ellipse")
                                    {
                                        Ellipse ellipse = (Ellipse)figure;
                                        ellipse.Rotation(alpha7, cx7, cy7);
                                    }
                                    if (figure.Type == "Rectangle")
                                    {
                                        Rectangle rectangle = (Rectangle)figure;
                                        rectangle.Rotation(alpha7, cx7, cy7);
                                    }
                                    if (figure.Type == "Polygone")
                                    {
                                        PolygonePlein polygone = (PolygonePlein)figure;
                                        polygone.Rotation(alpha7, cx7, cy7);
                                    }
                                    if (figure.Type == "Chemin")
                                    {
                                        Chemin chemin = (Chemin)figure;
                                        chemin.Rotation(alpha7, cx7, cy7);
                                    }
                                    if (figure.Type == "Texte")
                                    {
                                        Texte texte = (Texte)figure;
                                        texte.Rotation(alpha7, cx7, cy7);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch // Gestion de l'erreur en cas de fichier non-existant ou une mauvaise adresse
            {
                Console.WriteLine("Erreur chemin d'accès du fichier");
            }
            return liste;
        }


        public void EcritureFichier(string nomFichier, List<Figure> liste)
        {
            try
            {
                StreamWriter writer = new StreamWriter(nomFichier);
                writer.WriteLine("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");
                liste.Sort();
                foreach (Figure element in liste)
                {
                    writer.WriteLine(element);
                }
                writer.WriteLine("</svg>");
                writer.Close();
                Console.WriteLine("Conversion réussie !");
            }
            catch // Gestion de l'erreur en cas d'adresse non valide
            {
                Console.WriteLine("Erreur chemin écriture fichier");
            }
        }
    }
}
