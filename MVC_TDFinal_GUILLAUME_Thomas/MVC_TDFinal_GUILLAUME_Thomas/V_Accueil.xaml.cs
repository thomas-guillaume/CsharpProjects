using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVC_TDFinal_GUILLAUME_Thomas
{
    /// <summary>
    /// Logique d'interaction pour V_Accueil.xaml
    /// </summary>
    public partial class V_Accueil : Window
    {
        private MV_Recherche mv_recherche;


        //Constructeur
        public V_Accueil(MV_Recherche MV_recherche)
        {
            InitializeComponent();
            this.mv_recherche = MV_recherche;
        }

        
        //Boutons vers les pages d'ajout et de recherche
        private void Recherche_Click(object sender, RoutedEventArgs e)
        {
            V_Recherche recherche = new V_Recherche(mv_recherche);
            recherche.Show();
        }
        private void Ajout_Click(object sender, RoutedEventArgs e)
        {
            V_Ajout ajout = new V_Ajout();
            ajout.Show();
        }
    }
}
