using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Studiengangsverwaltung.model
{
    [XmlRoot("StudentListe")]
    public class StudentListe : ObservableCollection<Student>
    {
        public StudentListe Liste { get; set; }

        private static StudentListe instance;

        public static StudentListe Instance
        {
            get { return instance ?? (instance = new StudentListe()); }
        }
    }
}
