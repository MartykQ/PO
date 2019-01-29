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
using EgzUlamek;
namespace UlamGUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ulamek u1 = new Ulamek(int.Parse(tekscik1.Text), int.Parse(tekscik2.Text));
            u1.Skroc();
            lab1.Content = u1.Licznik.ToString();
            lab2.Content = u1.Mianownik.ToString();

        }
    }
}
