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

namespace WpfApp3
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    /// 
    public class Osoba
    {
        public string Jmeno { get; set; }
        public string Prijimeni { get; set; }
        public int Narozeni { get; set; }
        public string Vzdelani { get; set; }
        public override string ToString()
        {
            return string.Format($"Osoba {Jmeno} {Prijimeni}, narozen/a {Narozeni}, {Vzdelani} vzdělání.");
        }
        public Osoba(string j, string p, int n, string v)
        {
            Jmeno = j;
            Prijimeni = p;
            Narozeni = n;
            Vzdelani = v;
        }
    }
    public class Zamestnanec:Osoba
    {
        public string Pozice { get; set; }
        public int Plat { get; set; }

        public override string ToString()
        {
            return string.Format($"Zaměstnanec {Jmeno} {Prijimeni}, narozen/a {Narozeni}, {Vzdelani} vzdělání, pracuje jako {Pozice} s platem {Plat}kč.");
        }
        public Zamestnanec(string j, string p, int n, string v, string po, int pl) : base(j, p, n, v)
        {
            Pozice = po;
            Plat = pl;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }        
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (((jmeno.Text == "")||(prijimeni.Text == "")||(narozeni.Text == "")))
            {
                throw new ArgumentException("Je nutné zadat informace s hvězdičkou.");
            }
            if (pozice.Text == "")
            {
                try
                {
                    Osoba a = new Osoba(jmeno.Text, prijimeni.Text, Convert.ToInt32(narozeni.Text), vzdelani.Text);
                    vyjde.Text = string.Format(a.ToString());
                }
                catch (System.FormatException)
                {
                    throw new ArgumentException("Špatný formát věku nebo platu.");
                }
            }
            else
            {
                try
                {
                    Zamestnanec a = new Zamestnanec(jmeno.Text, prijimeni.Text, Convert.ToInt32(narozeni.Text), vzdelani.Text, pozice.Text, Convert.ToInt32(plat.Text));
                    vyjde.Text = string.Format(a.ToString());
                }
                catch (System.FormatException)
                {
                    throw new ArgumentException("Špatný formát věku nebo platu.");
                }
            }
        }
    }
}