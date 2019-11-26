﻿namespace Universitätsverwaltung.model
{
    internal class Settings
    {
        public static string Version = "26.11.2019";

        public string PathToProgram { get; set; }
        public string PathToDataFile { get; set; }
        public bool ChangesApplied { get; set; }
        public string DateFormat { get; set; }

        private static Settings instance;

        public static Settings Instance => instance ?? (instance = new Settings());

        public void Init()
        {
            PathToDataFile = PathToProgram + "data.xml";
            ChangesApplied = false;
            DateFormat = "dd.MM.yyyy";
        }
    }
}
