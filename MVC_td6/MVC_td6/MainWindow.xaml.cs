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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVC_td6
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Grid panel = new Grid();
            this.Content = panel;
            for (int l = 0; l < 2; l++) //2 lignes
            {
                RowDefinition ligne = new RowDefinition();
                panel.RowDefinitions.Add(ligne);
            }
            for (int c = 0; c < 5; c++) //5 colonnes
            {
                ColumnDefinition colonne = new ColumnDefinition();
                panel.ColumnDefinitions.Add(colonne);
            }
            
            string[] valeurs = { "A", "A", "B", "B", "C", "C", "D", "D", "E", "E" };
            int i = 0;

            for (int l = 0; l < 2; l++) //création boutons
            {
                for (int c = 0; c < 5; c++)
                {
                    Carte card = new Carte(valeurs[i], null);
                    i++;
                    card.Content = card.Motif;

                    Grid.SetRow(card, l);
                    Grid.SetColumn(card, c);
                    panel.Children.Add(card);
                }
            }
        }
    }
}
