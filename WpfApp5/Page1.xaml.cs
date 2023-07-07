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

namespace WpfApp5
{
    public partial class Page1 : Page
    {
        private ProjektEntities dbContext;

        public Page1()
        {
            InitializeComponent();
            dbContext = new ProjektEntities();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            var klienci = dbContext.Klienci.ToList();
            DataGridKlienci.ItemsSource = klienci;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var klient = new Klienci
            {
                Nazwisko = TextBoxNazwisko.Text,
                Imie = TextBoxImie.Text,
                Pesel = TextBoxPesel.Text,
                Wiek = int.Parse(TextBoxWiek.Text),
                Nr_PrawaJazdy = TextBoxNrPrawaJazdy.Text,
                Ulica = TextBoxUlica.Text,
                Nr_mieszkania = int.Parse(TextBoxNrMieszkania.Text),
                Kod_Pocztowy = TextBoxKodPocztowy.Text,
                Telefon = TextBoxTelefon.Text
            };

            dbContext.Klienci.Add(klient);
            dbContext.SaveChanges();

            RefreshDataGrid();
            ClearFields();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridKlienci.SelectedItem is Klienci selectedKlient)
            {
                selectedKlient.Nazwisko = TextBoxNazwisko.Text;
                selectedKlient.Imie = TextBoxImie.Text;
                selectedKlient.Pesel = TextBoxPesel.Text;
                selectedKlient.Wiek = int.Parse(TextBoxWiek.Text);
                selectedKlient.Nr_PrawaJazdy = TextBoxNrPrawaJazdy.Text;
                selectedKlient.Ulica = TextBoxUlica.Text;
                selectedKlient.Nr_mieszkania = int.Parse(TextBoxNrMieszkania.Text);
                selectedKlient.Kod_Pocztowy = TextBoxKodPocztowy.Text;
                selectedKlient.Telefon = TextBoxTelefon.Text;

                dbContext.SaveChanges();

                RefreshDataGrid();
                ClearFields();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridKlienci.SelectedItem is Klienci selectedKlient)
            {
                dbContext.Klienci.Remove(selectedKlient);
                dbContext.SaveChanges();

                RefreshDataGrid();
                ClearFields();
            }
        }

        private void DataGridKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridKlienci.SelectedItem is Klienci selectedKlient)
            {
                TextBoxNazwisko.Text = selectedKlient.Nazwisko;
                TextBoxImie.Text = selectedKlient.Imie;
                TextBoxPesel.Text = selectedKlient.Pesel;
                TextBoxWiek.Text = selectedKlient.Wiek.ToString();
                TextBoxNrPrawaJazdy.Text = selectedKlient.Nr_PrawaJazdy;
                TextBoxUlica.Text = selectedKlient.Ulica;
                TextBoxNrMieszkania.Text = selectedKlient.Nr_mieszkania.ToString();
                TextBoxKodPocztowy.Text = selectedKlient.Kod_Pocztowy;
                TextBoxTelefon.Text = selectedKlient.Telefon;
            }
        }

        private void ClearFields()
        {
            TextBoxNazwisko.Text = string.Empty;
            TextBoxImie.Text = string.Empty;
            TextBoxPesel.Text = string.Empty;
            TextBoxWiek.Text = string.Empty;
            TextBoxNrPrawaJazdy.Text = string.Empty;
            TextBoxUlica.Text = string.Empty;
            TextBoxNrMieszkania.Text = string.Empty;
            TextBoxKodPocztowy.Text = string.Empty;
            TextBoxTelefon.Text = string.Empty;
        }
    }
}
