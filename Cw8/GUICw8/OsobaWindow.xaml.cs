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

namespace GUICw8
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWindow.xaml
    /// </summary>
    public partial class OsobaWindow : Window


    {
        public OsobaWindow()
        {
            InitializeComponent();
        }

        public OsobaWindow(Osoba osoba) : this()
        {
            this.osoba = osoba;
            if (osoba.Pesel != "00000000000")
            {
                textBox_PESEL.Text = osoba.Pesel;
                textBox_imie.Text = osoba.Imie;
                textBox_nazwisko.Text = osoba.Nazwisko;
                textBox_dataUr.Text = osoba.dataUr.ToShortDateString();
                if ((osoba.Plec) == Osoba.Plcie.K)
                    comboBox_plec.Text = "kobieta";
                else
                    comboBox_plec.Text = "mężczyzna";

            }
        }
    }
}
