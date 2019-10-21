namespace Studiengangsverwaltung
{
    public class Abschluss
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public Abschluss(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}