namespace Studiengangsverwaltung.model
{
    class Settings
    {
        public string PathToProgram { get; set; }
        public string PathToDataFile { get; set; }

        private static Settings instance;

        public static Settings Instance
        {
            get { return instance ?? (instance = new Settings()); }
        }

        public void init()
        {
            PathToDataFile = PathToProgram + "data.xml";
        }
    }
}
