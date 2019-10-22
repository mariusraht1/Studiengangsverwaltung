using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Studiengangsverwaltung.model
{
    [XmlRoot("KursListe")]
    public class KursListe : ObservableCollection<Kurs>
    {
        public KursListe Liste { get; set; }

        private static KursListe instance;

        public static KursListe Instance
        {
            get { return instance ?? (instance = new KursListe()); }
        }
    }
}
