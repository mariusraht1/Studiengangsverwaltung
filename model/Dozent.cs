using Studiengangsverwaltung.model;
using System;

namespace Studiengangsverwaltung
{
    public class Dozent : Person
    {
        public Abschluss Abschluss { get; set; }

        public Dozent(int id, Rollen rolle, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, Abschluss abschluss)
        : base(id, rolle, vorname, nachname, adresse, geburtsdatum)
        {
            Abschluss = abschluss;
        }
    }
}
