using System;

namespace Studiengangsverwaltung
{
    class Student
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Adresse Adresse { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public Student(int id, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum)
        {
            ID = id;
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;
            Geburtsdatum = geburtsdatum;
        }
    }
}
