using Studiengangsverwaltung.model;

namespace Studiengangsverwaltung
{
    public class Studiengang
    {
        public string Name { get; set; }
        public Abschluss Abschluss { get; set; }
        public SemesterListe SemesterListe { get; set; }

        public Studiengang() { }

        public Studiengang(string name, Abschluss abschluss, SemesterListe semesterListe)
        {
            Name = name;
            Abschluss = abschluss;
            SemesterListe = semesterListe;

            StudiengangListe.Instance.Add(this);
        }
    }
}