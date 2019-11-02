using System;
using System.ComponentModel.DataAnnotations;

namespace Universitätsverwaltung.model
{
    public class Abschluss : IComparable
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }

        public Abschluss() { }

        public Abschluss(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            Abschluss abschluss = (Abschluss)obj;

            if (abschluss == null)
            {
                return false;
            }

            return Name.Equals(abschluss.Name);
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return Name.CompareTo(obj);
        }
    }
}
