using Studiengangsverwaltung.controller;
using System.Windows;
using System.Windows.Controls;

namespace Studiengangsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowController.Instance.start(this);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindowController.Instance.exit();
        }

        private void tb_person_search_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb_person_search = sender as TextBox;
            tb_person_search.Text = "";
        }

        private void tb_person_search_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb_search = sender as TextBox;
            tb_search.Text = "Suche...";
        }

        private void tb_kurs_search_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb_search = sender as TextBox;
            tb_search.Text = "";
        }

        private void tb_kurs_search_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb_search = sender as TextBox;
            tb_search.Text = "Suche...";
        }
    }
}
