using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    public class SemesterListe : ObservableCollection<Semester>, ICloneable
    {
        private static SemesterListe instance;

        public static SemesterListe Instance
        {
            get { return instance ?? (instance = new SemesterListe()); }
        }

        public static void SetInstance(SemesterListe semesterListe)
        {
            instance = semesterListe;
        }

        public SemesterListe() { }

        public SemesterListe(IEnumerable<Semester> collection) : base(collection)
        {
        }

        public bool IsDuplicate(Semester semester)
        {
            return Contains(semester);
        }

        public object Clone()
        {
            return new SemesterListe(this);
        }
    }
}
