using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    public enum Rolle
    {
        Dozent,
        Student
    }

    public abstract class Person
    {
        public Rolle Rolle { get; set; }
        [Required]
        [StringLength(42, MinimumLength = 2)]
        [Display(Name = "Vorname")]
        public string Vorname { get; set; }
        [Display(Name = "Nachname")]
        [Required]
        [StringLength(42, MinimumLength = 2)]
        public string Nachname { get; set; }
        [Required]
        public Adresse Adresse { get; set; }
        [Date]
        [Required]
        [Display(Name = "Geburtsdatum")]
        public DateTime Geburtsdatum { get; set; }

        public Person() { }

        public Person(Rolle rolle, string vorname, string nachname, Adresse adresse, DateTime geburtsdatum)
        {
            Rolle = rolle;
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;
            Geburtsdatum = geburtsdatum;
        }

        public bool IsValid()
        {   
            ValidationContext validationContext = new ValidationContext(this);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(this, validationContext, validationResults);
        }
    }
}