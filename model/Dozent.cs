using Universitätsverwaltung.model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Universitätsverwaltung
{
    public class Dozent : Person
    {
        [Required]
        public Abschluss Abschluss { get; set; }

        public Dozent() { }

        public Dozent(string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, Abschluss abschluss)
        : base(Rolle.Dozent, vorname, nachname, adresse, geburtsdatum)
        {
            Abschluss = abschluss;
        }

        public new bool IsValid()
        {
            switch (base.IsValid())
            {
                case true:
                    ValidationContext validationContext = new ValidationContext(this);
                    List<ValidationResult> validationResults = new List<ValidationResult>();

                    return Validator.TryValidateObject(this, validationContext, validationResults);
                case false:
                    return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            Dozent dozent = (Dozent)obj;

            if (dozent == null)
            {
                return false;
            }

            return base.Equals(obj)
                    && Abschluss.Equals(dozent.Abschluss);
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
