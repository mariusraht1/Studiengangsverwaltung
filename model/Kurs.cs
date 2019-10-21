using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiengangsverwaltung
{
    class Kurs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public int Semester { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Endedatum { get; set; }

        public Kurs(int id, string name, string beschreibung, int semester, DateTime startdatum, DateTime endedatum)
        {
            ID = id;
            Name = name;
            Beschreibung = beschreibung;
            Semester = semester;
            Startdatum = startdatum;
            Endedatum = endedatum;
        }
    }
}
