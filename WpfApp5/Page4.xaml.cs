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
    public partial class Page4 : Page
    {
        private ProjektEntities db;

        public Page4()
        {
            InitializeComponent();
            db = new ProjektEntities();
            LoadData();
        }

        private void LoadData()
        {
            DataGridWypozyczenia.ItemsSource = db.Wypozyczenia.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Wypozyczenia newWypozyczenie = new Wypozyczenia
            {
                IDKlienta = int.Parse(TextBoxIDKlienta.Text),
                ID_Samochodu = int.Parse(TextBoxIDSamochodu.Text),
                KodPracownika = int.Parse(TextBoxKodPracownika.Text),
                Data_Wypozyczenia = DatePickerDataWypozyczenia.SelectedDate.GetValueOrDefault(),
                Data_Zwrotu = DatePickerDataZwrotu.SelectedDate.GetValueOrDefault()
            };

            db.Wypozyczenia.Add(newWypozyczenie);
            db.SaveChanges();

            LoadData();
            ClearFields();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridWypozyczenia.SelectedItem == null)
            {
                MessageBox.Show("Wybierz wypożyczenie do edycji.");
                return;
            }

            Wypozyczenia selectedWypozyczenie = (Wypozyczenia)DataGridWypozyczenia.SelectedItem;

            selectedWypozyczenie.IDKlienta = int.Parse(TextBoxIDKlienta.Text);
            selectedWypozyczenie.ID_Samochodu = int.Parse(TextBoxIDSamochodu.Text);
            selectedWypozyczenie.KodPracownika = int.Parse(TextBoxKodPracownika.Text);
            selectedWypozyczenie.Data_Wypozyczenia = DatePickerDataWypozyczenia.SelectedDate.GetValueOrDefault();
            selectedWypozyczenie.Data_Zwrotu = DatePickerDataZwrotu.SelectedDate.GetValueOrDefault();

            db.SaveChanges();

            LoadData();
            ClearFields();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridWypozyczenia.SelectedItem == null)
            {
                MessageBox.Show("Wybierz wypożyczenie do usunięcia.");
                return;
            }

            Wypozyczenia selectedWypozyczenie = (Wypozyczenia)DataGridWypozyczenia.SelectedItem;

            db.Wypozyczenia.Remove(selectedWypozyczenie);
            db.SaveChanges();

            LoadData();
            ClearFields();
        }

        private void DataGridWypozyczenia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridWypozyczenia.SelectedItem != null)
            {
                Wypozyczenia selectedWypozyczenie = (Wypozyczenia)DataGridWypozyczenia.SelectedItem;

                TextBoxIDKlienta.Text = selectedWypozyczenie.IDKlienta.ToString();
                TextBoxIDSamochodu.Text = selectedWypozyczenie.ID_Samochodu.ToString();
                TextBoxKodPracownika.Text = selectedWypozyczenie.KodPracownika.ToString();
                DatePickerDataWypozyczenia.SelectedDate = selectedWypozyczenie.Data_Wypozyczenia;
                DatePickerDataZwrotu.SelectedDate = selectedWypozyczenie.Data_Zwrotu;
            }
        }

        private void ClearFields()
        {
            TextBoxIDKlienta.Text = "";
            TextBoxIDSamochodu.Text = "";
            TextBoxKodPracownika.Text = "";
            DatePickerDataWypozyczenia.SelectedDate = null;
            DatePickerDataZwrotu.SelectedDate = null;
        }
    }
}