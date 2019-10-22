using Studiengangsverwaltung.model;
using System.Collections.ObjectModel;

namespace Studiengangsverwaltung
{
    public class Studiengang
    {
        public Kurs Kurs { get; set; }
        public Semester Semester { get; set; }
        public Dozent Dozent { get; set; }
        public StudentListe Studenten { get; set; }

        public Studiengang() { }

        public Studiengang(Kurs kurs, Semester semester, Dozent dozent, StudentListe studenten)
        {
            Kurs = kurs;
            Semester = semester;
            Dozent = dozent;
            Studenten = studenten;
        }


    }
}