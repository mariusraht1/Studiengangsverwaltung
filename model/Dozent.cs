using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    public class Dozent : Person, IComparable, ICloneable
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

        public new void Update(Person newPerson)
        {
            foreach (Studiengang studiengang in StudiengangListe.Instance)
            {
                foreach (Semester semester in studiengang.SemesterListe)
                {
                    foreach (KursDozent kursDozent in semester.KursDozentListe)
                    {
                        if (kursDozent.Dozent.Equals(this))
                        {
                            kursDozent.Dozent = (Dozent)newPerson;
                        }
                    }
                }
            }
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
            return Vorname + " " + Nachname;
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public new int CompareTo(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return -1;
            }

            Dozent dozent = (Dozent)obj;
            int personEqualRate = base.CompareTo(obj);

            switch (personEqualRate)
            {
                case 0:
                    return Abschluss.CompareTo(dozent.Abschluss);
                default:
                    return personEqualRate;
            }
        }

        public object Clone()
        {
            Adresse adresse = (Adresse)Adresse.Clone();
            Abschluss abschluss = (Abschluss)Abschluss.Clone();

            return new Dozent(Vorname, Nachname, adresse, Geburtsdatum, abschluss);
        }
    }
}
