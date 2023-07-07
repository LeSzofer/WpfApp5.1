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
    public partial class Page3 : Page
    {
        private ProjektEntities db;

        public Page3()
        {
            InitializeComponent();
            db = new ProjektEntities();
            LoadData();
        }

        private void LoadData()
        {
            DataGridPracownicy.ItemsSource = db.Pracownicy.ToList();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy newPracownik = new Pracownicy
            {
                Nazwisko = TextBoxNazwisko.Text,
                Imie = TextBoxImie.Text,
                Ulica = TextBoxUlica.Text,
                Nr_mieszkania = int.Parse(TextBoxNrMieszkania.Text),
                Miejscowość = TextBoxMiejscowosc.Text,
                Kod_Pocztowy = TextBoxKodPocztowy.Text,
                Rok_Rozpoczecia_Pracy = DatePickerRokRozpoczecia.SelectedDate.GetValueOrDefault(),
                Stanowisko = TextBoxStanowisko.Text,
                Pensja = decimal.Parse(TextBoxPensja.Text)
            };

            db.Pracownicy.Add(newPracownik);
            db.SaveChanges();

            LoadData();
            ClearFields();
        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPracownicy.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pracownika do edycji.");
                return;
            }

            Pracownicy selectedPracownik = (Pracownicy)DataGridPracownicy.SelectedItem;

            selectedPracownik.Nazwisko = TextBoxNazwisko.Text;
            selectedPracownik.Imie = TextBoxImie.Text;
            selectedPracownik.Ulica = TextBoxUlica.Text;
            selectedPracownik.Nr_mieszkania = int.Parse(TextBoxNrMieszkania.Text);
            selectedPracownik.Miejscowość = TextBoxMiejscowosc.Text;
            selectedPracownik.Kod_Pocztowy = TextBoxKodPocztowy.Text;
            selectedPracownik.Rok_Rozpoczecia_Pracy = DatePickerRokRozpoczecia.SelectedDate.GetValueOrDefault();
            selectedPracownik.Stanowisko = TextBoxStanowisko.Text;
            selectedPracownik.Pensja = decimal.Parse(TextBoxPensja.Text);

            db.SaveChanges();

            LoadData();
            ClearFields();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPracownicy.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pracownika do usunięcia.");
                return;
            }

            Pracownicy selectedPracownik = (Pracownicy)DataGridPracownicy.SelectedItem;

            db.Pracownicy.Remove(selectedPracownik);
            db.SaveChanges();

            LoadData();
            ClearFields();
        }
        private void DataGridPracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPracownicy.SelectedItem != null)
            {
                Pracownicy selectedPracownik = (Pracownicy)DataGridPracownicy.SelectedItem;

                TextBoxNazwisko.Text = selectedPracownik.Nazwisko;
                TextBoxImie.Text = selectedPracownik.Imie;
                TextBoxUlica.Text = selectedPracownik.Ulica;
                TextBoxNrMieszkania.Text = selectedPracownik.Nr_mieszkania.ToString();
                TextBoxMiejscowosc.Text = selectedPracownik.Miejscowość;
                TextBoxKodPocztowy.Text = selectedPracownik.Kod_Pocztowy;
                DatePickerRokRozpoczecia.SelectedDate = selectedPracownik.Rok_Rozpoczecia_Pracy;
                TextBoxStanowisko.Text = selectedPracownik.Stanowisko;
                TextBoxPensja.Text = selectedPracownik.Pensja.ToString();
            }
        }

        private void ClearFields()
        {
            TextBoxNazwisko.Text = "";
            TextBoxImie.Text = "";
            TextBoxUlica.Text = "";
            TextBoxNrMieszkania.Text = "";
            TextBoxMiejscowosc.Text = "";
            TextBoxKodPocztowy.Text = "";
            DatePickerRokRozpoczecia.SelectedDate = null;
            TextBoxStanowisko.Text = "";
            TextBoxPensja.Text = "";
        }
    }
}
