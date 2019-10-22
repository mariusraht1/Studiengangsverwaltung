using Studiengangsverwaltung.model;
using Studiengangsverwaltung.view;
using System;

namespace Studiengangsverwaltung.controller
{
    class MainWindowController
    {
        private static MainWindowController instance;

        public static MainWindowController Instance
        {
            get { return instance ?? (instance = new MainWindowController()); }
        }

        public Settings Settings { get; set; }

        public void start(MainWindow mainWindow)
        {
            mainWindow.InitializeComponent();

            // TODO: Daten auslesen
        }

        public void exit()
        {
            // TODO: Daten speichern
            ReadWriteController.Instance.write();

            Environment.Exit(0);
        }
    }
}
