using Studiengangsverwaltung.model;
using Studiengangsverwaltung.view;
using System;

namespace Studiengangsverwaltung.controller
{
    class MainWindowController
    {
        private static MainWindowController instance;

        public static MainWindowController Instance
        {
            get { return instance ?? (instance = new MainWindowController()); }
        }

        public void Start(MainWindow mainWindow)
        {
            mainWindow.InitializeComponent();
            Settings.Instance.Init();

            ReadWriteController.Instance.Read();




            //Abschluss abschluss1 = new Abschluss("M. Sc. Winf.");
            //Abschluss abschluss2 = new Abschluss("B. Sc. Winf.");
            //Adresse adresse1 = new Adresse("Musterstraße", "1a", 22222, "Grundort");
            //Adresse adresse2 = new Adresse("Malerweg", "25", 21351, "Musterstadt");
            //Adresse adresse3 = new Adresse("Amselstraße", "12", 21351, "Musterstadt");
            //Dozent dozent = new Dozent("Max", "Musterdozent", adresse1, new DateTime(1960, 10, 11), abschluss1);
            //Student student1 = new Student("Peter", "Lustig", adresse2, new DateTime(1991, 1, 13), 11111, 0);
            //Student student2 = new Student("Herbert", "Flo", adresse3, new DateTime(1997, 5, 7), 11112, 5);
            //Kurs kurs = new Kurs("Software- und Qualitätsmanagement", "---", dozent, new StudentListe() { student1, student2 });
            //Semester semester = new Semester(1, new DateTime(2019, 10, 21), new DateTime(2020, 04, 30), new KursListe() { kurs });
            //new Studiengang("B. Sc. Winf.", abschluss2, new SemesterListe() { semester });

            mainWindow.lv_personen.ItemsSource = PersonListe.Instance;
            mainWindow.lv_kurse.ItemsSource = KursListe.Instance;
            mainWindow.lv_studiengaenge.ItemsSource = StudiengangListe.Instance;
            mainWindow.cb_rolle.ItemsSource = Enum.GetValues(typeof(Rolle));
            mainWindow.cb_rolle.SelectedItem = Rolle.Student;
        }

        public void Exit()
        {
            System.Windows.Application.Current.MainWindow.Hide();

            ReadWriteController.Instance.Write();

            Environment.Exit(0);
        }
    }
}
