using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.model;

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

        public Dozent(string vorname, string nachname, Adresse adresse, string geburtsdatum, Abschluss abschluss)
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

            Dozent dozent = (Dozent)obj;

            return base.Equals(dozent)
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
