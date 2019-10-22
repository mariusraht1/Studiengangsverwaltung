using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            List<object> xmlData = new List<object>();


        }

        public void write()
        {
            // https://stackoverflow.com/questions/9839034/generating-xml-from-multiple-classes
            // https://stackoverflow.com/questions/34787395/xmlserializer-streamwriter-multiple-types-classes-into-same-xml-file
            // https://stackoverflow.com/questions/15247053/serialize-multiple-objects

            Kurs.Liste.Add(new Kurs(1, "Testkurs", "Testkursbeschreibung"));

            if (Kurs.Liste.Count > 0)
            {
                XmlSerializer writer = new XmlSerializer(typeof(Kurs));

                using (FileStream output = File.OpenWrite(MainWindowController.Instance.Settings.PathToDataFile))
                {
                    writer.Serialize(output, Kurs.Liste);
                }
            }
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
