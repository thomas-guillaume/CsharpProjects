using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_td2
{
    class Etagere
    {
        private int nb_max;
        private List<Document> list_doc;
        private int numEta;


        public Etagere(int NB_MAX, List<Document> LIST_DOC, int NUMETA)
        {
            this.nb_max = NB_MAX;
            this.list_doc = LIST_DOC;
            this.NumEta = NUMETA;
        }


        public List<Document> List_doc
        {
            get{ return this.list_doc; }
            set{ this.list_doc = value; }
        }
        public int Nb_max
        {
            get{ return this.nb_max; }
            set{ this.nb_max = value; }
        }
        public int NumEta
        {
            get{ return this.numEta; }
            set{ this.numEta = value; }
        }


        public void add_doc(Document doc)
        {
            if (nb_max > this.list_doc.Count())
            {
                this.list_doc.Add(doc);
            }
            else
            {
                Console.WriteLine("Etagere remplie.");
            }
        }


        public void AfficherDocumentsEtagere()
        {
            Console.WriteLine(this.list_doc.ToString());
        }


        public Document RechercheDocuments(int num)
        {
            Document doc = new Document(0, " ");
            bool ind = false;
            int i = 0;
            while (i < this.list_doc.Count() && ind == false)
            {
                if (this.list_doc.ElementAt(i).Num == num)
                {
                    ind = true;
                    doc = this.list_doc.ElementAt(i);
                }
                i++;
            }
            if (ind == false)
            {
                Console.WriteLine("Document inexistant.");
                return null;
            }
            else
            {
                return doc;
            }
        }


        public void SuppDocument(string tit)
        {
            bool ind = false;
            int i = 0;
            while (i < this.list_doc.Count() && ind == false)
            {
                if (this.list_doc.ElementAt(i).Titre.Equals(tit))
                {
                    ind = true;
                    this.list_doc.RemoveAt(i);
                }
                i++;
            }
            if (ind == false)
            {
                Console.WriteLine("Document introuvable.");
            }
            else
            {
                Console.WriteLine("Suppression effectuée.");
            }
        }


        public void Tri_etag()
        {
            this.list_doc.Sort(delegate (Document x, Document y)
            {
                if (x.Titre == null && y.Titre == null)
                {
                    return 0;
                }
                else if (x.Titre == null)
                {
                    return -1;
                }
                else if (y.Titre == null)
                {
                    return 1;
                }
                else
                {
                    return x.Titre.CompareTo(y.Titre);
                }
            });

        }


        public override string ToString()
        {
            return "Nombre max de documents : " + nb_max + "; Liste des documents : " + list_doc;
        }
    }
}
