namespace Universitätsverwaltung
{
    public class KursDozent
    {
        public Kurs Kurs { get; set; }
        public Dozent Dozent { get; set; }

        public KursDozent() { }

        public KursDozent(Kurs kurs, Dozent dozent)
        {
            Kurs = kurs;
            Dozent = dozent;
        }
    }
}
