namespace Universitätsverwaltung.model
{
    public class Abschluss
    {
        public string Name { get; set; }

        public Abschluss() { }

        public Abschluss(string name)
        {
            Name = name;

            AbschlussListe.Instance.Add(this);
        }
    }
}
