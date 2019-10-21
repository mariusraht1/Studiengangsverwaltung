using System;

namespace Studiengangsverwaltung
{
    class Semester
    {
        public int ID { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Endedatum { get; set; }

        public Semester(int id, DateTime startdatum, DateTime endeDatum)
        {
            ID = id;
            Startdatum = startdatum;
            Endedatum = endeDatum;
        }
    }
}