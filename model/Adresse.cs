using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    public class Adresse : IComparable
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

            if (int.TryParse(postleitzahl, out int resultPostleitzahl))
            {
                Postleitzahl = resultPostleitzahl;
            }
            
            Ort = ort;

            switch (AdressListe.Instance.Contains(this))
            {
                case false:
                    AdressListe.Instance.Add(this);
                    break;
            }
        }

        public Adresse(string strasse, string hausnummer, int postleitzahl, string ort)
        {
            Strasse = strasse;
            Hausnummer = hausnummer;
            Postleitzahl = postleitzahl;
            Ort = ort;

            AdressListe.Instance.Add(this);
        }

        public bool IsValid()
        {
            ValidationContext validationContext = new ValidationContext(this);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(this, validationContext, validationResults);
        }

        public override bool Equals(object obj)
        {
            Adresse adresse = (Adresse)obj;

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

            return Strasse.Equals(adresse.Strasse)
                    && Hausnummer.Equals(adresse.Hausnummer)
                    && Postleitzahl.Equals(adresse.Postleitzahl)
                    && Ort.Equals(adresse.Ort);
        }

        public override string ToString()
        {
            return Strasse + " " + Hausnummer + ", " + Postleitzahl + " " + Ort;
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

            Adresse adresse = (Adresse)obj;

            int strasseEqualRate = Strasse.CompareTo(adresse.Strasse);

            switch (strasseEqualRate)
            {
                case 0:
                    int hausnummerEqualRate = Hausnummer.CompareTo(adresse.Hausnummer);

                    switch (hausnummerEqualRate)
                    {
                        case 0:
                            int plzEqualRate = Postleitzahl.CompareTo(adresse.Postleitzahl);

                            switch (plzEqualRate)
                            {
                                case 0:
                                    return Ort.CompareTo(adresse.Ort);
                                default:
                                    return plzEqualRate;
                            }
                        default:
                            return hausnummerEqualRate;
                    }
                default:
                    return strasseEqualRate;
            }
        }

        public object Clone()
        {
            return new Adresse(Strasse,Hausnummer,Postleitzahl,Ort);
        }
    }
}