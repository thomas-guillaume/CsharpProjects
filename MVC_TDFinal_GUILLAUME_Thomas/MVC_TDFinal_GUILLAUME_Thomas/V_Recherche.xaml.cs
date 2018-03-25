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
    /// Logique d'interaction pour V_Recherche.xaml
    /// </summary>
    public partial class V_Recherche : Window
    {
        private MV_Recherche mv_recherche;


        //Constructeur
        public V_Recherche(MV_Recherche MV_recherche)
        {
            InitializeComponent();
            this.mv_recherche = MV_recherche;

            this.DataContext = mv_recherche; //Datacontext du binding des 3 textbox

            /*Resultats.ItemsSource = mv_recherche;*/ //Mise en place du binding pour afficher le résultat de la requête
        }


        //Les attributs de mv_recherche prennent comme valeur le contenu des textbox
        private void textdate_TextChanged(object sender, TextChangedEventArgs e)
        {
            mv_recherche.Date = textdate.Text;
        }
        private void textquartier_TextChanged(object sender, TextChangedEventArgs e)
        {
            mv_recherche.Quartier = textquartier.Text;
        }
        private void textdescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            mv_recherche.Description = textdescription.Text;
        }


        //Fait appel à la requête du MV
        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            this.mv_recherche.Requete();
        }
    }
}
