using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace MVC_TDFinal_GUILLAUME_Thomas
{
    public class M_Gestion
    {
        public List<M_Crime> requete_recherche(string date, string quartier, string description)
        {
            //Connection à la base de données
            string connectionString = "SERVER=localhost;DATABASE=S6_MVC_Chicago;UID=esilvs6;PASSWORD=esilvs6;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            //Compte combien d'argument sont non null pour pouvoir adapter la requête SQL
            int compteur = 0;
            if (date != null)
            {
                compteur++;
                if (quartier != null)
                {
                    compteur++;
                    if (description != null)
                        compteur++;
                }
                else
                {
                    if (description != null)
                        compteur++;
                }
            }
            else
            {
                if (quartier != null)
                {
                    compteur++;
                    if (description != null)
                        compteur++;
                }
                else
                {
                    if (description != null)
                        compteur++;
                }
            }


            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Crime JOIN Crime_description ON Crime.crime_description_id = Crime_description.id JOIN Jurisdiction ON Crime.jurisdiction_id = Jurisdiction.id";
            //Adaptation de la requête selon les arguments
            if (compteur == 3)
                command.CommandText += " WHERE Crime.date = \"" + date + "\" AND Crime.borough = \"" + quartier.ToUpper() + "\" AND Crime_description.description = \"" + description + "\";";
            else
            {
                if (compteur == 1)
                {
                    if (date != null)
                        command.CommandText += " WHERE Crime.date = \"" + date + "\" AND ";
                    else
                    {
                        if (quartier != null)
                            command.CommandText += " WHERE Crime.borough = \"" + quartier.ToUpper() + "\";";
                        else
                            command.CommandText += "WHERE Crime_description.description = \"" + description + "\";";
                    }
                }
                else
                {
                    if (compteur == 2)
                    {
                        if (date != null)
                        {
                            command.CommandText += " WHERE Crime.date = \"" + date + "\" AND ";
                            if (quartier != null)
                                command.CommandText += "Crime.borough = \"" + quartier.ToUpper() + "\";";
                            else
                                command.CommandText += "Crime_description.description = \"" + description + "\";";
                        }
                        else
                            command.CommandText += " WHERE Crime.borough = \"" + quartier.ToUpper() + "\" AND Crime_description.description = \"" + description + "\";";
                    }
                }
            }

            
            MySqlDataReader reader = command.ExecuteReader();

            string[] tab = new string[reader.FieldCount]; //Chaque résultat de la requête remplit le tableau de string
            List<M_Crime> list_crime = new List<M_Crime>(); //Chaque tableau permet de créer un objet M_Crime que l'on ajoute à la liste

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    tab[i] = reader.GetValue(i).ToString();
                }
                M_Crime m_crime = new M_Crime(tab[1], tab[2], tab[3], tab[4], tab[8], tab[9], tab[11]);
                list_crime.Add(m_crime);
            }


            //Fin de connection
            connection.Close();
            return list_crime; //Renvoie la liste de crimes
        }
    }
}
