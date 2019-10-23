using Studiengangsverwaltung.model;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace Studiengangsverwaltung.controller
{
    class ReadWriteController
    {
        private static ReadWriteController instance;

        public static ReadWriteController Instance
        {
            get { return instance ?? (instance = new ReadWriteController()); }
        }

        public void Read()
        {
            try
            {
                if (File.Exists(Settings.Instance.PathToDataFile))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(SerializeObjectsWrapper), null,
                        2147483647, false, true, null);
                    using (FileStream input = File.OpenRead(Settings.Instance.PathToDataFile))
                    {
                        ((SerializeObjectsWrapper)serializer.ReadObject(input)).Deserialize();
                    }
                }
                else
                {
                    string filePath = Path.GetFullPath(Settings.Instance.PathToDataFile);
                    Console.Out.WriteLine("Datei " + filePath + " existiert nicht.");
                }
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Daten konnten nicht ausgelesen werden.");
            }
        }

        public void Write()
        {
            try
            {
                Settings.Instance.ChangesApplied = true;

                if (Settings.Instance.ChangesApplied.Equals(true)
                     && StudiengangListe.Instance.Count > 0)
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(SerializeObjectsWrapper), null,
                        2147483647, false, true, null);
                    using (FileStream output = File.Create(Settings.Instance.PathToDataFile))
                    {
                        serializer.WriteObject(output, SerializeObjectsWrapper.Instance);
                    }
                }
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Daten konnten nicht gespeichert werden.");
            }
        }
    }
}
