using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    public class KursDozentListe : ObservableCollection<KursDozent>
    {
        private static KursDozentListe instance;

        public static KursDozentListe Instance
        {
            get { return instance ?? (instance = new KursDozentListe()); }
        }

        public static void SetInstance(KursDozentListe kursDozentListe)
        {
            instance = kursDozentListe;
        }
    }
}
