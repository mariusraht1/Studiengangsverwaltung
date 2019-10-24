using Universitätsverwaltung.model;
using System;

namespace Universitätsverwaltung
{
    public class Semester
    {
        public int Nummer { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Endedatum { get; set; }
        public KursListe KursListe { get; set; }

        public Semester() { }

        public Semester(int nummer, DateTime startdatum, DateTime endeDatum, KursListe kursListe)
        {
            Nummer = nummer;
            Startdatum = startdatum;
            Endedatum = endeDatum;
            KursListe = kursListe;
        }
    }
}