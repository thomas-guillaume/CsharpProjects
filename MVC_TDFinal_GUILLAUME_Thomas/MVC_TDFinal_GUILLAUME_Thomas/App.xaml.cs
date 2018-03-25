using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVC_TDFinal_GUILLAUME_Thomas
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Model
            M_Gestion m_gestion = new M_Gestion();
            
            //ModelView
            MV_Recherche mv_recherche = new MV_Recherche(m_gestion);

            //View
            V_Ajout ajouter = new V_Ajout();
            V_Recherche v_rechercher = new V_Recherche(mv_recherche);
            V_Accueil accueil = new V_Accueil(mv_recherche);

            //Affichage de l'écran d'accueil au démarrage
            accueil.Show();
        }
    }
}
