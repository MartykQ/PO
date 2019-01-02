using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Cw8;

namespace GUICw8
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Zespol zespol = new Zespol();
        ObservableCollection<CzlonekZespolu> lista;


        public MainWindow()
        {
            InitializeComponent();
            lista = new ObservableCollection<CzlonekZespolu>();
            zespol = (Zespol)Zespol.OdczytajXML("zespol2.xml");
            listBox_czlonkowie.ItemsSource = lista;
            textBox_nazwa.Text = zespol.Nazwa;
            textBox_kierownik.Text = zespol.Kierownik.Nazwisko;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_dodaj_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OsobaWindow okno = new OsobaWindow(cz);
            okno.ShowDialog();
            zespol.DodajCzlonka(cz);
            lista.Add(cz);

        }

        private void button_usun_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_czlonkowie.SelectedIndex;
            lista.RemoveAt(zaznaczony);
            zespol.Czlonkowie.RemoveAt(zaznaczony);
        }
    }
}
