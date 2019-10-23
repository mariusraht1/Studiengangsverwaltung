using Studiengangsverwaltung.model;

namespace Studiengangsverwaltung
{
    public class Kurs
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public Dozent Dozent { get; set; }
        public StudentListe StudentListe { get; set; }

        public Kurs() { }

        public Kurs(string name, string beschreibung, Dozent dozent, StudentListe studentListe)
        {
            Name = name;
            Beschreibung = beschreibung;
            Dozent = dozent;
            StudentListe = studentListe;

            KursListe.Instance.Add(this);
        }
    }
}
