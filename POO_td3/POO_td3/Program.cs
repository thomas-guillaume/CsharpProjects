using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POO_td3
{
    class Program
    {
        static List<Telephone> LectureFichier(string NomFile)
        {
            List<Telephone> lst = new List<Telephone>();

            // Ouverture du fichier, 
            StreamReader monStreamReader = new StreamReader(@"C:\Users\thoma\Documents\Cours\ESILV\S06\Programmation orientée objet\" + NomFile);

            // Lire la première ligne
            string ligne = monStreamReader.ReadLine();

            // Tant que la ligne lue n'est pas null
            while (ligne != null)
            {
                // Découper selon le séparateur ',', résultat: un tableau.
                string[] temp = ligne.Split(',');

                try
                {
                    // Si telephone fixe
                    if (temp[0] == "Fixe")
                    {
                        TelFixe F = new TelFixe(temp[1], temp[2], temp[3]);
                        lst.Add(F);
                    }
                    else // sinon, telephone portable.
                    {
                        TelPortable P = new TelPortable(temp[1], temp[2], temp[3]);
                        lst.Add(P);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur Lecture");
                }
                finally
                {
                    Console.WriteLine("Bonne Lecture");
                }

                // lire ligne suivante.
                ligne = monStreamReader.ReadLine();
            }

            // Fermeture du StreamReader (attention indispensable) 
            monStreamReader.Close();

            return lst;
        }

        static void AffichageList(List<Telephone> T)
        {
            if(T != null)
            {
                for (int i = 0; i < T.Count; i++)
                {
                    Console.WriteLine((i + 1) + ")" + T.ElementAt(i).ToString());
                }
            }
        }

        static int TriNumero(List<Telephone> L)
        {
            if (L != null)
            {
                L.Sort(delegate (Telephone x, Telephone y)
                {
                    if (x == null && y == null)
                        return 0;
                    else if (x == null)
                        return -1;
                    else if (y == null)
                        return 1;
                    else
                        return x.Numero.CompareTo(y.Numero);
                });
            }
            return 0;
        }

        static void SuppNumInf10(List<Telephone> L)
        {
            if (L != null)
            {
                for (int i = 0; i < L.Count; i++)
                {
                    if (L.ElementAt(i).Numero.Length != 10)
                        L.RemoveAt(i);
                }
            }
        }

        static void Main(string[] args)
        {
            List<Telephone> lstTelephone = new List<Telephone>();
            Telephone tel = new Telephone("IPhone", "0732458870");
            TelPortable telport = new TelPortable("Samsung", "0658607463", "Pierre");
            TelFixe telfixe = new TelFixe("Honor", "0132425262", "ESILV");
            lstTelephone.Add(tel);
            lstTelephone.Add(telport);
            lstTelephone.Add(telfixe);
            lstTelephone = LectureFichier("liste1.txt");
            TriNumero(lstTelephone);
            AffichageList(lstTelephone);
            List<Telephone> lstTelephone2 = new List<Telephone>();
            lstTelephone2 = LectureFichier("liste2.txt");
            AffichageList(lstTelephone2);
            List<Telephone> lstResultat = new List<Telephone>();
            lstResultat = lstTelephone.Union(lstTelephone2).ToList();
            AffichageList(lstResultat);
            SuppNumInf10(lstResultat);
            AffichageList(lstResultat);
            Console.ReadKey();
        }
    }
}
