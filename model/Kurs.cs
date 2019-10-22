namespace Studiengangsverwaltung
{
    public class Kurs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }

        public Kurs() { }

        public Kurs(int id, string name, string beschreibung)
        {
            ID = id;
            Name = name;
            Beschreibung = beschreibung;
        }
        

    }
}
