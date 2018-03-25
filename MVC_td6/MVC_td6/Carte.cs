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
    class Carte : Button
    {
        private bool retournee;
        private string valeur;
        private string motif;
        private Carte cardPrec;

        public Carte(string VALEUR, Carte CardPrec)
        {
            this.valeur = VALEUR;
            this.retournee = false;
            this.motif = "?";
            this.Click += card_Click;
            this.cardPrec = CardPrec;
        }

        public string Motif
        {
            get { return this.motif; }
        }

        public bool Face()
        {
            return this.retournee;
        }

        public void RetourneCarte()
        {
            if (this.retournee == false)
            {
                this.retournee = true;
                this.motif = this.valeur;

            }
            else
            {
                retournee = false;
                this.motif = "?";
            }
        }

        private void card_Click(object sender, RoutedEventArgs e)
        {
            if (this.cardPrec == null)
            {
                RetourneCarte();
                Content = this.motif;
                this.cardPrec = this;
            }
            else
            {
                RetourneCarte();
                Content = this.motif;
                if(this.motif==this.cardPrec.motif)
                {
                    MessageBox.Show("Paire trouvée !");
                    this.IsEnabled = false;
                    this.cardPrec.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Dommage !");
                    RetourneCarte();
                    cardPrec.RetourneCarte();
                }
                this.cardPrec = null;
            }
        }
    }
}
