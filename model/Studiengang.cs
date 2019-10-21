using System.Collections.ObjectModel;

namespace Studiengangsverwaltung
{
    class Studiengang
    {
        public Kurs Kurs { get; set; }
        public Semester Semester { get; set; }
        public Dozent Dozent { get; set; }
        public ObservableCollection<Student> Studenten { get; set; }

        public Studiengang(Kurs kurs, Semester semester, Dozent dozent, ObservableCollection<Student> studenten)
        {
            Kurs = kurs;
            Semester = semester;
            Dozent = dozent;
            Studenten = studenten;
        }
    }
}