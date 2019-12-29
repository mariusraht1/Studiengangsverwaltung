using System;

namespace Universitätsverwaltung
{
    public class KursDozent : ICloneable
    {
        public Kurs Kurs { get; set; }
        public Dozent Dozent { get; set; }

        public KursDozent() { }

        public KursDozent(Kurs kurs, Dozent dozent)
        {
            Kurs = kurs;
            Dozent = dozent;
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

            KursDozent kursDozent = (KursDozent)obj;

            return Kurs.Equals(kursDozent.Kurs)
                && Dozent.Equals(kursDozent.Dozent);        }

        public override string ToString()
        {
            return Kurs.Name + "; " + Dozent.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new KursDozent((Kurs)Kurs.Clone(), (Dozent)Dozent.Clone());
        }
    }
}
