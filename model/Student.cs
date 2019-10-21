using System;

namespace Studiengangsverwaltung
{
    class Student : Person
    {
        public int ECTS { get; set; }

        public Student(int id, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, int ects)
        : base(id, vorname, nachname, adresse, geburtsdatum)
        {
            ECTS = ects;
        }
    }
}
