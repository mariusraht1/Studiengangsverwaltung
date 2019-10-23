using System;

namespace Studiengangsverwaltung
{
    public class Student : Person
    {
        public int Matrikelnummer { get; set; }
        public int ECTS { get; set; }

        public Student() { }

        public Student(string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, int matrikelnummer, int ects)
        : base(Rolle.Student, vorname, nachname, adresse, geburtsdatum)
        {
            Matrikelnummer = matrikelnummer;
            ECTS = ects;
        }
    }
}
