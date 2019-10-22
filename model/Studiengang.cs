using Studiengangsverwaltung.model;

namespace Studiengangsverwaltung
{
    public class Studiengang
    {
        public string Name { get; set; }
        public Kurs Kurs { get; set; }
        public Semester Semester { get; set; }
        public Dozent Dozent { get; set; }
        public StudentListe Studenten { get; set; }

        public Studiengang() { }

        public Studiengang(string name, Kurs kurs, Semester semester, Dozent dozent, StudentListe studenten)
        {
            Name = name;
            Kurs = kurs;
            Semester = semester;
            Dozent = dozent;
            Studenten = studenten;
        }


    }
}