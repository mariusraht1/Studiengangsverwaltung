using System;

namespace Studiengangsverwaltung
{
    public class Student : Person
    {
        public int ECTS { get; set; }

        public Student(int id, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, int ects)
        : base(id, Rollen.Student, vorname, nachname, adresse, geburtsdatum)
        {
            ECTS = ects;
        }
    }
}
