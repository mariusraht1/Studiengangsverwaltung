namespace Studiengangsverwaltung
{
    public class Adresse
    {
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public int Postleitzahl { get; set; }
        public string Ort { get; set; }

        public Adresse(string strasse, string hausnummer, int postleitzahl, string ort)
        {
            Strasse      = strasse;
            Hausnummer   = hausnummer;
            Postleitzahl = postleitzahl;
            Ort          = ort;
        }

        public override string ToString()
        {
            return Strasse + " " + Hausnummer + ", " + Postleitzahl + " " + Ort;
        }
    }
}