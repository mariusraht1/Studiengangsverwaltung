using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    public class StudentListe : ObservableCollection<Student>, ICloneable
    {
        private static StudentListe instance;

        public static StudentListe Instance
        {
            get { return instance ?? (instance = new StudentListe()); }
        }

        public StudentListe() { }

        public StudentListe(IEnumerable<Student> collection) : base(collection)
        {
        }

        public object Clone()
        {
            return new StudentListe(this);
        }
    }
}
