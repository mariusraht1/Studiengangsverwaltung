using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    public class Semester : ICloneable
    {
        [Integer]
        [Required]
        [StringLength(3, MinimumLength = 1)]
        public int Nummer { get; set; }
        [Date]
        [Required]
        public DateTime Startdatum { get; set; }
        [Date]
        [Required]
        public DateTime Endedatum { get; set; }
        public KursDozentListe KursDozentListe { get; set; } = new KursDozentListe();

        public Semester() { }

        public Semester(int nummer, DateTime startdatum, DateTime endeDatum, KursDozentListe kursDozentListe)
        {
            Nummer = nummer;
            Startdatum = startdatum;
            Endedatum = endeDatum;
            KursDozentListe = kursDozentListe;
        }

        public Semester(int nummer, DateTime startdatum, DateTime endeDatum)
        {
            Nummer = nummer;
            Startdatum = startdatum;
            Endedatum = endeDatum;
        }

        public Semester(string nummer, string startdatum, string endeDatum)
        {
            if (int.TryParse(nummer, out int resultNummer))
            {
                Nummer = resultNummer;
            }

            if (DateTime.TryParse(startdatum, out DateTime resultStartdatum))
            {
                Startdatum = resultStartdatum;
            }

            if (DateTime.TryParse(endeDatum, out DateTime resultEndedatum))
            {
                Endedatum = resultEndedatum;
            }
        }

        public void Remove(KursDozent kursDozent)
        {
            KursDozentListe.Remove(kursDozent);
        }

        public void Remove(Kurs kurs)
        {
            KursDozentListe = new KursDozentListe(KursDozentListe.Where(x => !x.Kurs.Equals(kurs)).ToList());
        }

        public void Remove(Dozent dozent)
        {
            KursDozentListe = new KursDozentListe(KursDozentListe.Where(x => !x.Dozent.Equals(dozent)).ToList());
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

            Semester semester = (Semester)obj;

            return Nummer.Equals(semester.Nummer)
                && Startdatum.Equals(semester.Startdatum)
                && Endedatum.Equals(semester.Endedatum)
                && KursDozentListe.Equals(semester.KursDozentListe);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Semester(Nummer, Startdatum, Endedatum, (KursDozentListe)KursDozentListe.Clone());
        }
    }
}