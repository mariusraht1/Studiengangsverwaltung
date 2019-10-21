using Studiengangsverwaltung.model;
using System;

namespace Studiengangsverwaltung
{
    class Dozent : Person
    {
        public Abschluss Abschluss { get; set; }

        public Dozent(int id, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, Abschluss abschluss)
        : base(id, vorname, nachname, adresse, geburtsdatum)
        {
            Abschluss = abschluss;
        }
    }
}
