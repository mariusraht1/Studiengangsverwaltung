using System;
using System.Collections.ObjectModel;

namespace Studiengangsverwaltung
{
    public abstract class Person
    {
        public enum Rollen { Student, Dozent }

        public int ID { get; set; }
        public Rollen Rolle { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Adresse Adresse { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public Person() { }

        public Person(int id, Rollen rolle, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum)
        {
            ID = id;
            Rolle = rolle;
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;
            Geburtsdatum = geburtsdatum;
        }


    }
}