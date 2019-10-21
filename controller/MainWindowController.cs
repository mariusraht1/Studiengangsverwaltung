using Studiengangsverwaltung.model;
using Studiengangsverwaltung.view;
using System;
using System.Collections.ObjectModel;

namespace Studiengangsverwaltung.controller
{
    class MainWindowController
    {
        private static MainWindowController instance;

        public static MainWindowController Instance
        {
            get { return instance ?? (instance = new MainWindowController()); }
        }

        public Settings Settings { get; set; }

        public void start(MainWindow mainWindow)
        {
            mainWindow.InitializeComponent();

            // TODO: Daten auslesen und Objekte anlegen


            mainWindow.lv_personen.ItemsSource = Person.Liste;
            mainWindow.lv_kurse.ItemsSource = Kurs.Liste;
            mainWindow.cb_rolle.ItemsSource = new ObservableCollection<string>() { Person.Rollen.Dozent.ToString(), Person.Rollen.Student.ToString() };
        }

        public void exit()
        {
            System.Windows.Application.Current.MainWindow.Hide();

            // TODO: Daten speichern


            Environment.Exit(0);
        }
    }
}
