using System.Collections.ObjectModel;

namespace Studiengangsverwaltung.model
{
    public class StudiengangListe : ObservableCollection<Studiengang>
    {
        private static StudiengangListe instance;

        public static StudiengangListe Instance
        {
            get { return instance ?? (instance = new StudiengangListe()); }
        }

        public static void SetInstance(StudiengangListe studiengangListe)
        {
            instance = studiengangListe;
        }
    }
}
