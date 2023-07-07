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
    public partial class Page2 : Page
    {
        private ProjektEntities dbContext;

        public Page2()
        {
            InitializeComponent();
            dbContext = new ProjektEntities();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            var pojazdy = dbContext.Pojazdy.ToList();
            DataGridPojazdy.ItemsSource = pojazdy;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var pojazd = new Pojazdy
            {
                Vin = TextBoxVin.Text,
                Rejestracja = TextBoxRejestracja.Text,
                Marka = TextBoxMarka.Text,
                Model = TextBoxModel.Text,
                Rok_Produkcji = DatePickerRokProdukcji.SelectedDate.GetValueOrDefault(),
                Wersja_Silnika = TextBoxWersjaSilnika.Text,
                Moc = int.Parse(TextBoxMoc.Text),
                Wersja_Wyposazenia = TextBoxWersjaWyposazenia.Text,
                Numer_Transpondera_GPS = TextBoxNumerTransponderaGPS.Text,
                Rodzaj_Nadwozia = TextBoxRodzajNadwozia.Text,
                Stawka = decimal.Parse(TextBoxStawka.Text)
            };

            dbContext.Pojazdy.Add(pojazd);
            dbContext.SaveChanges();

            RefreshDataGrid();
            ClearFields();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPojazdy.SelectedItem is Pojazdy selectedPojazd)
            {
                selectedPojazd.Vin = TextBoxVin.Text;
                selectedPojazd.Rejestracja = TextBoxRejestracja.Text;
                selectedPojazd.Marka = TextBoxMarka.Text;
                selectedPojazd.Model = TextBoxModel.Text;
                selectedPojazd.Rok_Produkcji = DatePickerRokProdukcji.SelectedDate.GetValueOrDefault();
                selectedPojazd.Wersja_Silnika = TextBoxWersjaSilnika.Text;
                selectedPojazd.Moc = int.Parse(TextBoxMoc.Text);
                selectedPojazd.Wersja_Wyposazenia = TextBoxWersjaWyposazenia.Text;
                selectedPojazd.Numer_Transpondera_GPS = TextBoxNumerTransponderaGPS.Text;
                selectedPojazd.Rodzaj_Nadwozia = TextBoxRodzajNadwozia.Text;
                selectedPojazd.Stawka = decimal.Parse(TextBoxStawka.Text);

                dbContext.SaveChanges();

                RefreshDataGrid();
                ClearFields();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPojazdy.SelectedItem is Pojazdy selectedPojazd)
            {
                dbContext.Pojazdy.Remove(selectedPojazd);
                dbContext.SaveChanges();

                RefreshDataGrid();
                ClearFields();
            }
        }

        private void DataGridPojazdy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPojazdy.SelectedItem is Pojazdy selectedPojazd)
            {
                TextBoxVin.Text = selectedPojazd.Vin;
                TextBoxRejestracja.Text = selectedPojazd.Rejestracja;
                TextBoxMarka.Text = selectedPojazd.Marka;
                TextBoxModel.Text = selectedPojazd.Model;
                DatePickerRokProdukcji.SelectedDate = selectedPojazd.Rok_Produkcji;
                TextBoxWersjaSilnika.Text = selectedPojazd.Wersja_Silnika;
                TextBoxMoc.Text = selectedPojazd.Moc.ToString();
                TextBoxWersjaWyposazenia.Text = selectedPojazd.Wersja_Wyposazenia;
                TextBoxNumerTransponderaGPS.Text = selectedPojazd.Numer_Transpondera_GPS;
                TextBoxRodzajNadwozia.Text = selectedPojazd.Rodzaj_Nadwozia;
                TextBoxStawka.Text = selectedPojazd.Stawka.ToString();
            }
        }

        private void ClearFields()
        {
            TextBoxVin.Text = string.Empty;
            TextBoxRejestracja.Text = string.Empty;
            TextBoxMarka.Text = string.Empty;
            TextBoxModel.Text = string.Empty;
            DatePickerRokProdukcji.SelectedDate = null;
            TextBoxWersjaSilnika.Text = string.Empty;
            TextBoxMoc.Text = string.Empty;
            TextBoxWersjaWyposazenia.Text = string.Empty;
            TextBoxNumerTransponderaGPS.Text = string.Empty;
            TextBoxRodzajNadwozia.Text = string.Empty;
            TextBoxStawka.Text = string.Empty;
        }
    }
}

