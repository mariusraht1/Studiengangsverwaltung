using Studiengangsverwaltung.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Studiengangsverwaltung.controller
{
    class ReadWriteController
    {
        private static ReadWriteController instance;

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
            // Serialize multiple Lists at once:
            //ObservableCollection<object> objectList = new ObservableCollection<object>();
            //foreach(Kurs kurs in KursListe.Instance.Liste) {
            //    objectList.Add(kurs);
            //}

            //XmlSerializer writer = new XmlSerializer(typeof(ObservableCollection<object>), new Type[] { typeof(Kurs) });

            //using (FileStream output = File.OpenWrite(Settings.Instance.PathToDataFile))
            //{
            //    writer.Serialize(output, objectList);
            //}

            Settings.Instance.ChangesApplied = true;

            if (Settings.Instance.ChangesApplied.Equals(true)
                 && KursListe.Instance.Liste.Count > 0)
            {
                XmlSerializer writer = new XmlSerializer(typeof(KursListe));

                using (FileStream output = File.Create(Settings.Instance.PathToDataFile))
                {
                    writer.Serialize(output, KursListe.Instance.Liste);
                }
            }
        }

        //*****************************************************************************************//
        //*************************** Methoden zum Einlesen von Dateien ***************************//
        //*****************************************************************************************//

        public void read_out_settings_xml()
        {
            if (!File.Exists(Settings.Instance.PathToDataFile))
            {
                // Standardwerte setzen
            }
            else
            {
                XmlSerializer reader = new XmlSerializer(typeof(Kurs));
                using (FileStream input = File.OpenRead(Settings.Instance.PathToDataFile))
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

            using (FileStream output = File.OpenWrite(Settings.Instance.PathToDataFile))
            {
                writer.Serialize(output, Settings.Instance.ToString());
            }
        }
    }
}
