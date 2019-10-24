using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Universitätsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;

        public static MainWindow Instance
        {
            get { return instance ?? (instance = new MainWindow()); }
        }

        public MainWindow()
        {
            Settings.Instance.Init();
            ReadWriteController.Instance.Read();

            InitializeComponent();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Hide();

            ReadWriteController.Instance.Write();

            Environment.Exit(0);
        }
    }
}
