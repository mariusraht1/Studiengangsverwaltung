namespace Universitätsverwaltung.model
{
    class Settings
    {
        public string PathToProgram { get; set; }
        public string PathToDataFile { get; set; }
        public bool ChangesApplied { get; set; }
        public string DateFormat { get; set; }

        private static Settings instance;

        public static Settings Instance
        {
            get { return instance ?? (instance = new Settings()); }
        }

        public void Init()
        {
            PathToDataFile = PathToProgram + "data.xml";
            ChangesApplied = false;
            DateFormat = "dd.MM.yyyy";
        }
    }
}
