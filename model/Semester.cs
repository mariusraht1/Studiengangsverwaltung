using System;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    [Serializable]
    public class Semester
    {
        [Integer]
        [Required]
        [StringLength(3, MinimumLength = 1)]
        public int Nummer { get; set; }
        [Date]
        [Required]
        public DateTime Startdatum { get; set; }
        [Date]
        [Required]
        public DateTime Endedatum { get; set; }
        public KursDozentListe KursDozentListe { get; set; } = new KursDozentListe();

        public Semester() { }

        public Semester(int nummer, DateTime startdatum, DateTime endeDatum)
        {
            Nummer = nummer;
            Startdatum = startdatum;
            Endedatum = endeDatum;
        }

        public Semester(string nummer, string startdatum, string endeDatum)
        {
            if (int.TryParse(nummer, out int resultNummer))
            {
                Nummer = resultNummer;
            }

            if (DateTime.TryParse(startdatum, out DateTime resultStartdatum))
            {
                Startdatum = resultStartdatum;
            }

            if (DateTime.TryParse(endeDatum, out DateTime resultEndedatum))
            {
                Endedatum = resultEndedatum;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            Semester semester = (Semester)obj;

            return Nummer.Equals(semester.Nummer);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}