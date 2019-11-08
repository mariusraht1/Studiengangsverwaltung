﻿using System;

namespace Universitätsverwaltung
{
    [Serializable]
    public class KursDozent
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
            return Kurs.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
