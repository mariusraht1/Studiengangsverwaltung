using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.controller;

namespace Universitätsverwaltung
{
    public enum Rolle
    {
        Dozent,
        Student
    }

    public abstract class Person : IComparable
    {
        public Rolle Rolle { get; set; }
        [Required]
        [StringLength(42, MinimumLength = 2)]
        public string Vorname { get; set; }
        [Required]
        [StringLength(42, MinimumLength = 2)]
        public string Nachname { get; set; }
        [Required]
        public Adresse Adresse { get; set; }
        [Date]
        [Required]
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

        public Person(Rolle rolle, string vorname, string nachname, Adresse adresse, string geburtsdatum)
        {
            Rolle = rolle;
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;

            if (DateTime.TryParse(geburtsdatum, out DateTime resultGeburtsdatum))
            {
                Geburtsdatum = resultGeburtsdatum;
            }
        }

        public bool IsValid()
        {   
            ValidationContext validationContext = new ValidationContext(this);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(this, validationContext, validationResults);
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

            Person person = (Person)obj;

            return Rolle.Equals(person.Rolle)
                    && Vorname.Equals(person.Vorname)
                    && Nachname.Equals(person.Nachname)
                    && Adresse.Equals(person.Adresse)
                    && Geburtsdatum.Equals(person.Geburtsdatum);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return -1;
            }

            Person person = (Person)obj;

            int rolleEqualRate = Rolle.CompareTo(person.Rolle);

            switch(rolleEqualRate)
            {
                case 0:
                    int vornameEqualRate = Vorname.CompareTo(person.Vorname);

                    switch (vornameEqualRate)
                    {
                        case 0:
                            int nachnameEqualRate = Nachname.CompareTo(person.Nachname);

                            switch (nachnameEqualRate)
                            {
                                case 0:
                                    int geburtsdatumEqualRate = Geburtsdatum.CompareTo(person.Geburtsdatum);

                                    switch (geburtsdatumEqualRate)
                                    {
                                        case 0:
                                            return Adresse.CompareTo(person.Adresse);
                                        default:
                                            return geburtsdatumEqualRate;
                                    }
                                default:
                                    return nachnameEqualRate;
                            }
                        default:
                            return vornameEqualRate;
                    }
                default:
                    return rolleEqualRate;
            }
        }
    }
}