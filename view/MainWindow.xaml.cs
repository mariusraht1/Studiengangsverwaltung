using Studiengangsverwaltung.controller;
using System.Windows;

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
    }
}
