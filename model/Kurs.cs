using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    public class Kurs : IComparable, ICloneable
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

            Kurs kurs = (Kurs)obj;

            int nameEqualRate = Name.CompareTo(kurs.Name);

            switch (nameEqualRate)
            {
                case 0:
                    int beschreibungEqualRate = Beschreibung.CompareTo(kurs.Beschreibung);

                    switch (beschreibungEqualRate)
                    {
                        case 0:
                            return ECTS.CompareTo(kurs.ECTS);
                        default:
                            return beschreibungEqualRate;
                    }
                default:
                    return nameEqualRate;
            }
        }

        public object Clone()
        {
            return new Kurs(Name, Beschreibung, ECTS);
        }

        public void Update(Kurs newKurs)
        {
            Kurs existingKurs = KursListe.Instance.Where(x => x.Equals(this)).Single();
            int indexExistingKurs = KursListe.Instance.IndexOf(existingKurs);

            KursListe.Instance[indexExistingKurs] = newKurs;

            foreach (Studiengang studiengang in StudiengangListe.Instance)
            {
                foreach (Semester semester in studiengang.SemesterListe)
                {
                    foreach (KursDozent kursDozent in semester.KursDozentListe)
                    {
                        if (kursDozent.Kurs.Equals(this))
                        {
                            kursDozent.Kurs = newKurs;
                        }
                    }
                }
            }
        }
    }
}
