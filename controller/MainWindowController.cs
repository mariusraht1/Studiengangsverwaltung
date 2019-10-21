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

            mainWindow.lv_kurse.ItemsSource = Kurs.Liste;
            mainWindow.cb_rolle.ItemsSource = new ObservableCollection<string>() { Person.Rolle.Dozent.ToString(), Person.Rolle.Student.ToString() };

            // TODO: Daten auslesen
        }

        public void exit()
        {
            // TODO: Daten speichern

            Environment.Exit(0);
        }
    }
}
