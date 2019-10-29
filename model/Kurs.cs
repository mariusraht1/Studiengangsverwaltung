using System.ComponentModel.DataAnnotations;

namespace Universitätsverwaltung
{
    public class Kurs
    {
        [Required]
        [StringLength(42, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(80)]
        public string Beschreibung { get; set; }
        [Required]
        [Range(0, 999)]
        public int ECTS { get; set; }

        public Kurs() { }

        public Kurs(string name, string beschreibung, int ects)
        {
            Name = name;
            Beschreibung = beschreibung;
            ECTS = ects;
        }

        public Kurs(string name, string beschreibung, string ects)
        {
            Name = name;
            Beschreibung = beschreibung;

            if (int.TryParse(ects, out int result))
            {
                ECTS = int.Parse(ects);
            }
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

            Kurs kurs = (Kurs)obj;

            return Name.Equals(kurs.Name)
                && Beschreibung.Equals(kurs.Beschreibung)
                && ECTS.Equals(kurs.ECTS);
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
