using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Studiengangsverwaltung.model
{
    [XmlRoot("PersonListe")]
    public class PersonListe : ObservableCollection<Kurs>
    {
        public PersonListe Liste { get; set; }

        private static PersonListe instance;

        public static PersonListe Instance
        {
            get { return instance ?? (instance = new PersonListe()); }
        }
    }
}
