using Universitätsverwaltung.model;
using System;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.controller;

namespace Universitätsverwaltung
{
    public class Semester
    {
        [Integer]
        [Required]
        [StringLength(3, MinimumLength = 1)]
        public int Nummer { get; set; }
        [StringLength(80, MinimumLength = 0)]
        public string Beschreibung { get; set; }
        [Date]
        [Required]
        public DateTime Startdatum { get; set; }
        [Date]
        [Required]
        public DateTime Endedatum { get; set; }

        public Semester() { }

        public Semester(int nummer, string beschreibung, DateTime startdatum, DateTime endeDatum)
        {
            Nummer = nummer;
            Beschreibung = beschreibung;
            Startdatum = startdatum;
            Endedatum = endeDatum;
        }

        public Semester(string nummer, string beschreibung, DateTime startdatum, DateTime endeDatum)
        {
            Nummer = int.Parse(nummer);
            Beschreibung = beschreibung;
            Startdatum = startdatum;
            Endedatum = endeDatum;
        }
    }
}