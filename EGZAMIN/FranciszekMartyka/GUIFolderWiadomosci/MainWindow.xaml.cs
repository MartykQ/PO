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
using FranciszekMartyka;

namespace GUIFolderWiadomosci
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Wiadomosc w1 = new Wiadomosc("urzad@gmina.pl", "Odpowiedz na pismo z dnia 1.10.2018");
            Wiadomosc w2 = new Wiadomosc("dziekanat@tytul.pl", "Zawiadomienie o terminie praktyk");
            Wiadomosc w3 = new Wiadomosc("promocje@grupex.com", "Promocja na telefony samsung");
            Wiadomosc w4 = new Wiadomosc("promocje@grupex.com", "Promocja na pobyt w spa");

            FolderWiadomosci f1 = new FolderWiadomosci();

            f1.DodajWiadomosc(w1);
            f1.DodajWiadomosc(w2);
            f1.DodajWiadomosc(w3);
            f1.DodajWiadomosc(w4);

            foreach(Wiadomosc w in f1.KolejkaWiadomosci)
            {
                listBoks.Items.Add(w);
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wiadomoscLabel.Content = listBoks.Items[0];
                listBoks.Items.RemoveAt(0);
            }
            catch(ArgumentOutOfRangeException)
            {
                throw new Exception("Nie ma kolejnych wiadomosci!");
            }
            
        }
    }
}
