using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace IBO
{
    class Program
    {
        static string recuperation() //permet de récupérer toutes les données depuis l'API
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("username", "groupe63");
            webClient.QueryString.Add("password", "WhcY638");
            webClient.QueryString.Add("database", "groupe63");
            webClient.QueryString.Add("collection", "sandbox1");
            webClient.QueryString.Add("action", "");
            string jsonString = webClient.DownloadString("http://ibo.labs.esilv.fr/~webservice/api/data");
            return jsonString;
        }


        static List<Data> deserialisation(string jsonString) //permet de désérialiser les données reçues
        {
            List<Data> data = JsonConvert.DeserializeObject<List<Data>>(jsonString);
            return data;
        }


        static double[] calculMoyenne(Data data) //calcul la moyenne suivant les 3 axes et les regroupe dans un tableau
        {
            double moyennex = 0;
            double moyenney = 0;
            double moyennez = 0;
            for (int i = 0; i < data.measures.Length; i++)
            {
                moyennex += data.measures[i][1];
                moyenney += data.measures[i][2];
                moyennez += data.measures[i][3];
            }
            moyennex = moyennex / data.measures.Length;
            moyenney = moyenney / data.measures.Length;
            moyennez = moyennez / data.measures.Length;
            double[] moyennes = { moyennex, moyenney, moyennez }; //regroupe les moyennes dans un tableau
            return moyennes;
        }


        static double[] calculEcarttype(Data data, double[] moyennes) //calcul les écart-types suivant les 3 axes et les regroupe dans un tableau
        {
            double ecarttypex = 0;
            double ecarttypey = 0;
            double ecarttypez = 0;
            for (int i = 0; i < data.measures.Length; i++)
            {
                ecarttypex += (data.measures[i][1] - moyennes[0]) * (data.measures[i][1] - moyennes[0]);
                ecarttypey += (data.measures[i][2] - moyennes[1]) * (data.measures[i][2] - moyennes[1]);
                ecarttypez += (data.measures[i][3] - moyennes[2]) * (data.measures[i][3] - moyennes[2]);
            }
            ecarttypex = Math.Sqrt(ecarttypex / data.measures.Length);
            ecarttypey = Math.Sqrt(ecarttypey / data.measures.Length);
            ecarttypez = Math.Sqrt(ecarttypez / data.measures.Length);
            double[] ecarttypes = { ecarttypex, ecarttypey, ecarttypez }; //regroupe les écart-types dans un tableau
            /*Console.WriteLine(ecarttypes[0]);
            Console.WriteLine(ecarttypes[1]);
            Console.WriteLine(ecarttypes[2]);*/
            return ecarttypes;
        }


        static string testAction(double ecarttypeRef1, double ecarttypeRef2, double[] ecarttypes) //test si les mesures correspondent à une action immobile ou en mouvement
        {
            if ((ecarttypes[0] < ecarttypeRef1) && (ecarttypes[1] < ecarttypeRef1) && (ecarttypes[2] < ecarttypeRef1))
            {
                return "stationary";
            }
            else
            {
                if ((ecarttypes[0] > ecarttypeRef2) && (ecarttypes[1] > ecarttypeRef2) && (ecarttypes[2] > ecarttypeRef2))
                {
                    return "run";
                }
                else
                {
                    return "walk";
                }
            }
        }


        static void affichageDonnees(Data data, string actions) //affiche les données reçues
        {
            Console.WriteLine(data.date);
            Console.WriteLine(data.phone);
            Console.WriteLine(data.action);
            /*for (int ligne = 0; ligne < data.measures.Length; ligne++)
            {
                for (int colonne = 0; colonne <= 3; colonne++)
                {
                    Console.Write(data.measures[ligne][colonne] + " ; ");
                }
                Console.WriteLine();
            }*/
            Console.WriteLine();
        }


        static string[][] tableau_qualite(int i, List<Data> data, string resultat) //crée un tableau pour comparer le mvt déduit par rapport au mvt réel
        {
            string[][] tab = new string[data.Count][];
            tab[i][0] = data[i].date;
            tab[i][1] = data[i].phone;
            tab[i][2] = data[i].action;
            tab[i][3] = resultat;
            tab[i][4] = " ";

            return tab;
        }


        static string[][] test(string action, List<Data> data, string[][] tab) //dit si c'est VP VN FP ou FN
        {
            for (int i = 0; i < data.Count; i++)
            {
                if ((tab[i][2] != action) && (tab[i][3] == action))
                {
                    tab[i][4] = "FN";

                }
                if ((tab[i][2] == action) && (tab[i][3] != action))
                {
                    tab[i][4] = "FP";

                }
                if ((tab[i][2] == action) && (tab[i][3] == action))
                {
                    tab[i][4] = "VP";

                }
                if ((tab[i][2] != action) && (tab[i][3] != action))
                {
                    tab[i][4] = "VN";
                }
            }
            return tab;
        }


        static void affichage_tab(string[][] tab, List<Data> data) //affiche le tableau de qualité
        {
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(tab[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Quelles actions voulez-vous afficher ? (tout/stationary/walk/run)"); //demande le type de mesures à afficher
            string action = Console.ReadLine(); //enregistre la réponse

            string donneesSerialisees = recuperation(); //récupère les données
            List<Data> donneesDeserialisees = deserialisation(donneesSerialisees); //les désérialise

            double ecarttypeRef1 = 0.75; //à définir, écart-type limite entre marche et immobile
            double ecarttypeRef2 = 5; //à définir, écart-type limite entre course et marche

            for (int i = 0; i < donneesDeserialisees.Count; i++) //parcours la liste de données
            {
                double[] moyennes = calculMoyenne(donneesDeserialisees[i]); //calcul moyennes
                double[] ecarttypes = calculEcarttype(donneesDeserialisees[i], moyennes); //calcul écart-type

                string resultat = testAction(ecarttypeRef1, ecarttypeRef2, ecarttypes); //teste l'action et renvoie le résultat

                string[][] tab = tableau_qualite(i, donneesDeserialisees, resultat); //tableau comparaison
                tab = test(action, donneesDeserialisees, tab);
                affichage_tab(tab, donneesDeserialisees);

                if (action == "tout")
                {
                    affichageDonnees(donneesDeserialisees[i], action);
                }
                else
                {
                    if (resultat == action) //si action demandée
                        affichageDonnees(donneesDeserialisees[i], action); //l'affiche
                }
            }

            Console.ReadLine();
        }
    }
}
