using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    public class SemesterListe : ObservableCollection<Semester>
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
    }
}
