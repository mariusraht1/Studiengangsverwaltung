using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    public class Adresse
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Strasse { get; set; }
        [Required]
        public string Hausnummer { get; set; }
        [Integer]
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public int Postleitzahl { get; set; }
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Ort { get; set; }

        public Adresse() { }

        public Adresse(string strasse, string hausnummer, string postleitzahl, string ort)
        {
            Strasse = strasse;
            Hausnummer = hausnummer;
            Postleitzahl = int.Parse(postleitzahl);
            Ort = ort;
        }

        public Adresse(string strasse, string hausnummer, int postleitzahl, string ort)
        {
            Strasse = strasse;
            Hausnummer = hausnummer;
            Postleitzahl = postleitzahl;
            Ort = ort;

            AdressListe.Instance.Add(this);
        }

        public override string ToString()
        {
            return Strasse + " " + Hausnummer + ", " + Postleitzahl + " " + Ort;
        }

        public bool IsValid()
        {
            ValidationContext validationContext = new ValidationContext(this);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(this, validationContext, validationResults);
        }
    }
}