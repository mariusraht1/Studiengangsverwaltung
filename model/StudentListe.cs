using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    public class StudentListe : ObservableCollection<Student>
    {
        private static StudentListe instance;

        public static StudentListe Instance
        {
            get { return instance ?? (instance = new StudentListe()); }
        }

        public StudentListe() { }
    }
}
