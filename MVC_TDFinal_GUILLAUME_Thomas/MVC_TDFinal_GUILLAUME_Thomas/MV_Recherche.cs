using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;

namespace MVC_TDFinal_GUILLAUME_Thomas
{
    public class MV_Recherche /*: INotifyCollectionChanged, IEnumerable*/
    {
        private M_Gestion m_gestion;
        private string date;
        private string quartier;
        private string description;
        private List<M_Crime> list_crime;


        //Constructeur
        public MV_Recherche(M_Gestion M_gestion)
        {
            this.m_gestion = M_gestion;
        }


        //Accesseurs
        public string Date
        {
            set { this.date = value; }
        }
        public string Quartier
        {
            set { this.quartier = value; }
        }
        public string Description
        {
            set { this.description = value; }
        }
        public List<M_Crime> Liste
        {
            get { return this.list_crime; }
        }


        //Fait appel à la requête du M pour remplir la liste de crimes
        //Malheureusement, le binding avec la listview de V_Recherche ne fonctionne pas malgré le temps passé dessus, dû à une erreur de l'implémentation de l'interface System.Collections.IEnumerable
        public void Requete()
        {
            this.list_crime = this.m_gestion.requete_recherche(this.date, this.quartier, this.description);

            /*M_Crime newcrime = new M_Crime("", "", "", "", "", "", "");
            list_crime.Add(newcrime);
            this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newcrime));*/
        }


        /*#region implémentation de l'interface System.Collections.Specialized.INotifyCollectionChanged
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, args);
            }
        }
        #endregion


        #region implémentation de l'interface System.Collections.IEnumerable
        public IEnumerator GetEnumerator()
        {
            return list_crime.GetEnumerator();
        }
        #endregion*/
    }
}
