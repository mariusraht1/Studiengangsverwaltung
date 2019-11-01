using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    public class Studiengang
    {
        [Required]
        [StringLength(42, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public Abschluss Abschluss { get; set; }
        [Required]
        [Range(1, 999)]
        public int ECTS { get; set; }
        public SemesterListe SemesterListe { get; set; }
        public StudentListe StudentListe { get; set; }

        public Studiengang() { }

        public Studiengang(string name, Abschluss abschluss, int ects, SemesterListe semesterListe, StudentListe studentListe)
        {
            Name = name;
            Abschluss = abschluss;
            ECTS = ects;
            SemesterListe = semesterListe;
            StudentListe = studentListe;
        }

        public Studiengang(string name, Abschluss abschluss, string ects, SemesterListe semesterListe, StudentListe studentListe)
        {
            Name = name;
            Abschluss = abschluss;

            if (int.TryParse(ects, out int result))
            {
                ECTS = int.Parse(ects);
            }

            SemesterListe = semesterListe;
            StudentListe = studentListe;
        }
    }
}