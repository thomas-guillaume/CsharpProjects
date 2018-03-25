using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.IO; //lecture/écriture de fichiers
using System.Xml.Serialization; //(dé)sérialiser en xml

namespace MVC_td4
{
    class Program
    {
        //Partie 1
        static void exo1()
        {
            string nom_doc = "bdtheque.xml";
            XPathDocument doc = new XPathDocument(nom_doc);
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr = nav.Compile("/bdtheque/BD"); //requête !
            XPathNodeIterator nodes = nav.Select(expr); //execution de la requête XPath
            while (nodes.MoveNext()) //pour chaque réponse XPath
            {
                nodes.Current.MoveToFirstChild();
                string titre = nodes.Current.Value;
                nodes.Current.MoveToNext();
                string auteur = nodes.Current.Value;
                bool ok = nodes.Current.MoveToNext();
                string nb_page = "";
                if (ok)
                {
                    nb_page = " (" + nodes.Current.Value + " pages)";
                }
                nodes.Current.MoveToParent();
                nodes.Current.MoveToFirstAttribute();
                string nb_isbn = nodes.Current.Value;
                nodes.Current.MoveToRoot();
                Console.WriteLine(titre + nb_page + ", écrit par " + auteur + ", numéro ISBN : " + nb_isbn + ".", nodes.Current.Value);
            }
            Console.ReadLine();
        }


        public static void exo2()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.CreateXmlDeclaration("1.0", "UTF-8", "no"); //création de l'entête XML (no = pas de DTD associée)

            XmlElement racine = docXml.CreateElement("BD");
            docXml.AppendChild(racine);

            XmlElement autreBalise = docXml.CreateElement("b");
            autreBalise.InnerText = "coucou";
            racine.AppendChild(autreBalise);

            docXml.Save("bd1.xml"); //enregistrement du document XML => bin\debug
        }

        //Partie 2
        static void Exo4()
        {
            BD bd11 = new BD("978-2203001169", "On a marché sur la Lune", 62);
            Console.WriteLine(bd11);  // affichage pour débug

            // Code pour sérialiser l'objet bd11 en XML dans un fichier "bd11.xml"
            XmlSerializer xs = new XmlSerializer(typeof(BD));  // l'outil de sérialisation
            StreamWriter wr = new StreamWriter("bd11.xml");  // accès en écriture à un fichier (texte)
            xs.Serialize(wr, bd11); // action de sérialiser en XML l'objet bd11 
                                    // et d'écrire le résultat dans le fichier manipulé par wr
            wr.Close();

            // vérifier le contenu du fichier "bd11.xml" dans le dossier bin\Debug de Visual Studio.
            Console.ReadLine();
        }

        public static void Exo5()
        {
            BD bd11 = null;
            //déserialisation
            XmlSerializer xs = new XmlSerializer(typeof(BD));
            StreamReader rd = new StreamReader("bd11.xml");
            bd11 = xs.Deserialize(rd) as BD;
            rd.Close();

            //Bilan :
            Console.WriteLine(bd11);
            Console.ReadLine();
        }

        public static void Exo6()
        {
            Artiste auteur = new Artiste("Remi", "Georges", "Hergé");
            Console.WriteLine(auteur);  // affichage pour débug

            BandeDessinee bd12 = new BandeDessinee("978-2203001169", "On a marché sur la Lune", auteur, 62);
            Console.WriteLine(bd12);  // affichage pour débug

            // Sérialisation...
            XmlSerializer xs = new XmlSerializer(typeof(BandeDessinee));
            StreamWriter wr = new StreamWriter("bd12.xml");
            xs.Serialize(wr, bd12);
            wr.Close();

            // vérifier le contenu du fichier "bd12.xml" dans le dossier bin\Debug de Visual Studio.
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Exo6();
        }
    }
}
