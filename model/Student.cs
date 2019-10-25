using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Universitätsverwaltung
{
    public class Student : Person
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

        public Student(string vorname, string nachname, Adresse adresse, DateTime geburtsdatum, string matrikelnummer, string ects)
        : base(Rolle.Student, vorname, nachname, adresse, geburtsdatum)
        {
            Matrikelnummer = int.Parse(matrikelnummer);
            ECTS = int.Parse(ects);
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
            Student student = (Student)obj;

            if (student == null)
            {
                return false;
            }

            return base.Equals(obj) 
                    && Matrikelnummer.Equals(student.Matrikelnummer)
                    && ECTS.Equals(student.ECTS);
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
