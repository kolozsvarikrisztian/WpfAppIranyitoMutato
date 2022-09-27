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

namespace IranyitoMutato
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double Szamol(int kiserlet, int sikeres, int yardok, int tdPassz, int eladott)
        {
            double a, b, c, d;
            a = MinMax(((double)sikeres / kiserlet - 0.3) * 5);
            b = MinMax(((double)yardok / kiserlet - 3) * 0.25);
            c = MinMax(((double)tdPassz / kiserlet) * 20);
            d = MinMax(2.375 - ((double)eladott / kiserlet) * 25);

            return 100 * (a + b + c + d) / 6;
        }

        private double MinMax(double x)
        {
            if (x < 0) return 0;
            if (x > 2.375) return 2.375;
            return x;
        }


        private void tbKísérlet_TextChanged(object sender, TextChangedEventArgs e)
        {
            int kísérlet;
            if (int.TryParse(tbKísérlet.Text, out kísérlet) && kísérlet > 0)
            {
                tbEladott.IsEnabled = true;
                tbSikeres.IsEnabled = true;
                tbTDk.IsEnabled = true;
                tbYardok.IsEnabled = true;
            }
        }

        private void btnSzamol_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double mutató = Math.Round(
                Szamol(int.Parse(tbKísérlet.Text), int.Parse(tbSikeres.Text), int.Parse(tbYardok.Text), int.Parse(tbTDk.Text), int.Parse(tbEladott.Text)), 2);
                lMutató.Foreground = Brushes.Black;
                lMutató.Content = "Irányított mutató: " + mutató;
            }
            catch (Exception)
            {
                lMutató.Foreground = Brushes.Red;
                lMutató.Content = "Hibás adat!";
            }

            
        }
    }
}
