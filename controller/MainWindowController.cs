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

        public void start(MainWindow mainWindow)
        {
            mainWindow.InitializeComponent();

            // TODO: Daten auslesen und Objekte anlegen



            Settings.Instance.init();

            PersonListe.Instance.Liste = new PersonListe();
            KursListe.Instance.Liste = new KursListe();
            StudiengangListe.Instance.Liste = new StudiengangListe();

            PersonListe.Instance.Liste.Add(new Student(1, "Max", "Mustermann", new Adresse("Musterstraße", "1a", 12345, "Musterstadt"), new DateTime(1990, 10, 12).Date, 20));
            KursListe.Instance.Liste.Add(new Kurs(1, "Testkurs", "Testkursbeschreibung"));

            mainWindow.lv_personen.ItemsSource = PersonListe.Instance.Liste;
            mainWindow.lv_kurse.ItemsSource = KursListe.Instance.Liste;
            mainWindow.lv_studiengaenge.ItemsSource = StudiengangListe.Instance.Liste;
            mainWindow.cb_rolle.ItemsSource = new ObservableCollection<string>() { Person.Rollen.Dozent.ToString(), Person.Rollen.Student.ToString() };
        }

        public void exit()
        {
            System.Windows.Application.Current.MainWindow.Hide();

            // TODO: Daten speichern
            ReadWriteController.Instance.write();


            Environment.Exit(0);
        }
    }
}
