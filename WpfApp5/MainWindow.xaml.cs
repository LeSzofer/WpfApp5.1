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
using System.Windows.Markup; // Wymagane dla klonowania stron

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        private Page1 page1;
        private Page2 page2;
        private Page3 page3;
        private Page4 page4;

        public MainWindow()
        {
            InitializeComponent();

            // Zainicjuj strony tylko raz
            page1 = new Page1();
            page2 = new Page2();
            page3 = new Page3();
            page4 = new Page4();

            NavigateToPage1();
        }

        private void NavigateToPage1()
        {
            MainFrame.Navigate(page1);
        }

        private void NavigateToPage2()
        {
            MainFrame.Navigate(page2);
        }

        private void NavigateToPage3()
        {
            MainFrame.Navigate(page3);
        }

        private void NavigateToPage4()
        {
            MainFrame.Navigate(page4);
        }

        private void ButtonPage1_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage1();
        }

        private void ButtonPage2_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage2();
        }

        private void ButtonPage3_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage3();
        }

        private void ButtonPage4_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage4();
        }

        private void OpenCurrentInNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Page newPage = null;
            if (MainFrame.Content == page1) newPage = new Page1();
            else if (MainFrame.Content == page2) newPage = new Page2();
            else if (MainFrame.Content == page3) newPage = new Page3();
            else if (MainFrame.Content == page4) newPage = new Page4();

            if (newPage != null)
            {
                NewWindow newWindow = new NewWindow(newPage);
                newWindow.Show();
            }
            else
            {
                MessageBox.Show("Nie udało się otworzyć strony w nowym oknie.");
            }
        }
    }
}
public class NewWindow : Window
    {
        public NewWindow(Page page)
        {
            // Ustaw content okna na przekazaną stronę
            this.Content = page;
        }
    }

