using Studiengangsverwaltung.model;
using System;

namespace Studiengangsverwaltung
{
    public class Dozent : Person
    {
        public Abschluss Abschluss { get; set; }

        public Dozent() { }

        public Dozent(string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, Abschluss abschluss)
        : base(Rolle.Dozent, vorname, nachname, adresse, geburtsdatum)
        {
            Abschluss = abschluss;
        }
    }
}
