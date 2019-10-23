using System.Collections.ObjectModel;

namespace Studiengangsverwaltung.model
{
    public class KursListe : ObservableCollection<Kurs>
    {
        private static KursListe instance;

        public static KursListe Instance
        {
            get { return instance ?? (instance = new KursListe()); }
        }

        public static void SetInstance(KursListe kursListe)
        {
            instance = kursListe;
        }
    }
}
