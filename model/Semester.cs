using System;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
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
        public KursDozentListe KursDozentListe { get; set; }

        public Semester() { }

        public Semester(int nummer, DateTime startdatum, DateTime endeDatum)
        {
            Nummer = nummer;
            Startdatum = startdatum;
            Endedatum = endeDatum;
        }

        public Semester(string nummer, string startdatum, string endeDatum)
        {
            if (int.TryParse(nummer, out _))
            {
                Nummer = int.Parse(nummer);
            }

            if (DateTime.TryParse(startdatum, out _))
            {
                Startdatum = DateTime.Parse(startdatum);
            }

            if (DateTime.TryParse(endeDatum, out _))
            {
                Endedatum = DateTime.Parse(endeDatum);
            }
        }
    }
}