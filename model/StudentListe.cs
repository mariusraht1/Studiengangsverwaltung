using System.Collections.ObjectModel;

namespace Studiengangsverwaltung.model
{
    public class StudentListe : ObservableCollection<Student>
    {
        private static StudentListe instance;

        public static StudentListe Instance
        {
            get { return instance ?? (instance = new StudentListe()); }
        }
    }
}
