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
    public partial class exercice2 : Window
    {
        public exercice2()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
            {
                textBox1.Text = textBox.Text;
                textBox.Text = "";
            }
            else
                MessageBox.Show("C'est vide !");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox.Text = textBox1.Text;
                textBox1.Text = "";
            }
            else
                MessageBox.Show("C'est vide !");
        }
    }
}
