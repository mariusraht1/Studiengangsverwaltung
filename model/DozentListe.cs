using System;
using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class DozentListe : ObservableCollection<Dozent>
    {
        private static DozentListe instance;

        public static DozentListe Instance
        {
            get { return instance ?? (instance = new DozentListe()); }
        }

        public DozentListe() { }
    }
}
