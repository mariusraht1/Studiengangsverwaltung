using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    public class PersonListe : ObservableCollection<Person>
    {
        private static PersonListe instance;

        public static PersonListe Instance
        {
            get { return instance ?? (instance = new PersonListe()); }
        }

        public static void SetInstance(PersonListe personListe)
        {
            instance = personListe;
        }
    }
}
