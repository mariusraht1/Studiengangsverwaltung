using System.Collections.ObjectModel;

namespace Studiengangsverwaltung
{
    class Kurs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }

        public Kurs(int id, string name, string beschreibung)
        {
            ID = id;
            Name = name;
            Beschreibung = beschreibung;
        }

        public static ObservableCollection<Kurs> Liste { get; set; }


    }
}
