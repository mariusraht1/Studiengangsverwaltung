namespace Studiengangsverwaltung
{
    class Adresse
    {
        private string strasse;
        private string nummer;
        private int postleitzahl;
        private string ort;

        public Adresse(string strasse, string nummer, int postleitzahl, string ort)
        {
            this.strasse      = strasse;
            this.nummer       = nummer;
            this.postleitzahl = postleitzahl;
            this.ort          = ort;
        }
    }
}