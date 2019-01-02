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
using Cw8;
using System.Collections.ObjectModel;

namespace GUICw8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zespol zespol = new Zespol();
        ObservableCollection<CzlonekZespolu> lista;
        public MainWindow()
        {
            InitializeComponent();
            //lista = new ObservableCollection <CzlonekZespolu>();
            zespol = (Zespol)Zespol.OdczytajXML("zespol2.xml");
            lista = new ObservableCollection<CzlonekZespolu>(zespol.Czlonkowie);
            listBox_czlonkowie.ItemsSource = lista;
            textBox_nazwa.Text = zespol.Nazwa;
            textBox_kierownik.Text = zespol.Kierownik.ToString();

        }

        private void button_zmien_Click(object sender, RoutedEventArgs e)
        {
            OsobaWindow okno = new OsobaWindow(zespol.Kierownik);
            okno.ShowDialog();
            textBox_kierownik.Text = zespol.Kierownik.ToString();
        }

        private void button_dodaj_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OsobaWindow okno = new OsobaWindow(cz);
            okno.ShowDialog();
            zespol.DodajCzlonka(cz);
            lista.Add(cz); //odswiezanie listy
        }

        private void button_usun_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony=ListBox
        }
    }
}
