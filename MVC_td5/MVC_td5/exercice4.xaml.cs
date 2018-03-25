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

namespace MVC_td5
{
    public partial class exercice4 : Window
    {
        public exercice4()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //exo4
            Random rand = new Random();
            double vertical = rand.Next(0, 200);
            double horizontal = rand.Next(0, 170);
            Canvas.SetTop(carre, vertical);
            Canvas.SetLeft(carre, horizontal);
        }
    }
}
