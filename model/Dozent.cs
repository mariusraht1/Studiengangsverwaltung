using System;

namespace Studiengangsverwaltung
{
    class Dozent
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Adresse Adresse { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public Abschluss Abschluss { get; set; }

        public Dozent(int id, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum)
        {
            ID = id;
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;
            Geburtsdatum = geburtsdatum;
        }
    }
}
