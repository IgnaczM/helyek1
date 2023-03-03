using System;
using System.Collections.Generic;
using System.IO;
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

namespace helyek1
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
        List<adatok> allomasok = new List<adatok>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("hely.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                allomasok.Add(new adatok(sorok[i]));
            }
        }

        class adatok
        {
            public string nev;
            public int tavolsag;

            public adatok(string sor)
            {
                string[] vag = sor.Split("\t");
                nev = vag[0];
                tavolsag = Convert.ToInt32(vag[1]);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int szam1 = Convert.ToInt32(textbox.Text);
                int szam2 = Convert.ToInt32(textbox1.Text);

                int tav = Math.Abs(allomasok[szam1 - 1].tavolsag-allomasok[szam2-1].tavolsag);
                textblock2.Text = tav.ToString();

                double atlagsebbeseg = allomasok[allomasok.Count - 1].tavolsag / Convert.ToDouble(allomasok);
                textblock3.Text = tav / atlagsebbeseg;
                
            }
            catch (Exception )
            {

                
            }
           

        }
    }
}
