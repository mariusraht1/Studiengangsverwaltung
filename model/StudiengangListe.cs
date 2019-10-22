using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Studiengangsverwaltung.model
{
    [XmlRoot("StudiengangListe")]
    public class StudiengangListe : ObservableCollection<Studiengang>
    {
        public StudiengangListe Liste { get; set; }

        private static StudiengangListe instance;

        public static StudiengangListe Instance
        {
            get { return instance ?? (instance = new StudiengangListe()); }
        }
    }
}
