using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Universitätsverwaltung
{
    [Serializable]
    public class Student : Person, IComparable, ICloneable
    {
        [Required]
        [Range(1, 999999)]
        public int Matrikelnummer { get; set; }
        [Range(0, 999)]
        public int ECTS { get; set; }

        public Student() { }

        public Student(string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, int matrikelnummer, int ects)
        : base(Rolle.Student, vorname, nachname, adresse, geburtsdatum)
        {
            Matrikelnummer = matrikelnummer;
            ECTS = ects;
        }

        public Student(string vorname, string nachname, Adresse adresse, string geburtsdatum, string matrikelnummer, string ects)
        : base(Rolle.Student, vorname, nachname, adresse, geburtsdatum)
        {
            if (int.TryParse(matrikelnummer, out int resultMatrikelnummer))
            {
                Matrikelnummer = resultMatrikelnummer;
            }

            if (int.TryParse(ects, out int resultECTS))
            {
                ECTS = resultECTS;
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

            Student student = (Student)obj;

            return base.Equals(student)
                && Matrikelnummer.Equals(student.Matrikelnummer)
                && ECTS.Equals(student.ECTS);
        }

        public override string ToString()
        {
            return Matrikelnummer + "; " + Vorname + " " + Nachname + " (" + Geburtsdatum.ToShortDateString() + ")";
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

            Student student = (Student)obj;
            int matrikelnummerEqualRate = Matrikelnummer.CompareTo(student.Matrikelnummer);

            switch (matrikelnummerEqualRate)
            {
                case 0:
                    int personEqualRate = base.CompareTo(obj);

                    switch (personEqualRate)
                    {
                        case 0:
                            return ECTS.CompareTo(student.ECTS);
                        default:
                            return personEqualRate;
                    }
                default:
                    return matrikelnummerEqualRate;
            }
        }

        public object Clone()
        {
            Adresse adresse = (Adresse)Adresse.Clone();

            return new Student(Vorname, Nachname, adresse, Geburtsdatum, Matrikelnummer, ECTS);
        }
    }
}
