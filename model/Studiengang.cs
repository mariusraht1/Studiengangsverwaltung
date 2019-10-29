using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    public class Studiengang
    {
        public string Name { get; set; }
        public Abschluss Abschluss { get; set; }
        public SemesterListe SemesterListe { get; set; }
        public StudentListe StudentListe { get; set; }

        public Studiengang() { }

        public Studiengang(string name, Abschluss abschluss, SemesterListe semesterListe, StudentListe studentListe)
        {
            Name = name;
            Abschluss = abschluss;
            SemesterListe = semesterListe;
            StudentListe = studentListe;
        }
    }
}