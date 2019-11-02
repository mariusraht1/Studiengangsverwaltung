namespace Universitätsverwaltung
{
    public class KursDozent
    {
        public Kurs Kurs { get; set; }
        public Dozent Dozent { get; set; }

        public KursDozent(Kurs kurs, Dozent dozent)
        {
            Kurs = kurs;
            Dozent = dozent;
        }

        public override string ToString()
        {
            return Kurs.Name;
        }
    }
}
