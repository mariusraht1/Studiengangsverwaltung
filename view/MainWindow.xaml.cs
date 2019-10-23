using Studiengangsverwaltung.controller;
using Studiengangsverwaltung.model;
using System;
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
            InitializeComponent();
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

            //lv_personen.ItemsSource = PersonListe.Instance;
            //lv_kurse.ItemsSource = KursListe.Instance;
            lv_studiengaenge.ItemsSource = StudiengangListe.Instance;
            //cb_rolle.ItemsSource = Enum.GetValues(typeof(Rolle));
            //cb_rolle.SelectedItem = Rolle.Student;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Hide();

            ReadWriteController.Instance.Write();

            Environment.Exit(0);
        }
    }
}
