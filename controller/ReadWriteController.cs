using System.IO;
using System.Xml.Serialization;

namespace Studiengangsverwaltung.controller
{
    class ReadWriteController
    {
        static ReadWriteController instance;

        public static ReadWriteController Instance
        {
            get { return instance ?? (instance = new ReadWriteController()); }
        }

        public void read()
        {

        }

        public void write()
        {

        }

        //*****************************************************************************************//
        //*************************** Methoden zum Einlesen von Dateien ***************************//
        //*****************************************************************************************//

        public void read_out_settings_xml()
        {
            if (!File.Exists(MainWindowController.Instance.Settings.PathToDataFile))
            {
                // Standardwerte setzen
            }
            else
            {
                XmlSerializer reader = new XmlSerializer(typeof(Kurs));
                using (FileStream input = File.OpenRead(MainWindowController.Instance.Settings.PathToDataFile))
                {
                    Kurs rx = reader.Deserialize(input) as Kurs;
                }
            }
        }

        //*****************************************************************************************//
        //************************** Methoden zum Schreiben von Dateien ***************************//
        //*****************************************************************************************//

        public void write_settings_to_xml()
        {
            XmlSerializer writer = new XmlSerializer(typeof(Kurs));

            using (FileStream output = File.OpenWrite(MainWindowController.Instance.Settings.PathToDataFile))
            {
                writer.Serialize(output, MainWindowController.Instance.Settings.ToString());
            }
        }
    }
}
