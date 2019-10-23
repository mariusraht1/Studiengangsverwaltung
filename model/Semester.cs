using Studiengangsverwaltung.model;
using System;

namespace Studiengangsverwaltung
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

            SemesterListe.Instance.Add(this);
        }
    }
}