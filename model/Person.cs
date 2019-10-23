using Studiengangsverwaltung.model;
using System;

namespace Studiengangsverwaltung
{
    public enum Rolle
    {
        Student,
        Dozent
    }

    public abstract class Person
    {
        public Rolle Rolle { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Adresse Adresse { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public Person() { }

        public Person(Rolle rolle, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum)
        {
            Rolle = rolle;
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;
            Geburtsdatum = geburtsdatum;

            PersonListe.Instance.Add(this);
        }
    }
}