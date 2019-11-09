using System;
using System.ComponentModel.DataAnnotations;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class Abschluss : IComparable, ICloneable
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }

        public Abschluss() { }

        public Abschluss(string name)
        {
            Name = name;

            switch (AbschlussListe.Instance.Contains(this))
            {
                case false:
                    AbschlussListe.Instance.Add(this);
                    break;
            }
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
            if (obj == null || obj.GetType() != GetType())
            {
                return -1;
            }

            Abschluss abschluss = (Abschluss)obj;

            return Name.CompareTo(abschluss.Name);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
