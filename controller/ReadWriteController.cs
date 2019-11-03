using System;
using System.IO;
using System.Runtime.Serialization;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung.controller
{
    internal class ReadWriteController
    {
        private static ReadWriteController instance;

        public static ReadWriteController Instance => instance ?? (instance = new ReadWriteController());

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
            catch (Exception e)
            {
                Console.Out.WriteLine("ERROR: " + e.Message);
            }
        }

        public void Write()
        {
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(SerializeObjectsWrapper), null,
                    2147483647, false, true, null);
                using (FileStream output = File.Create(Settings.Instance.PathToDataFile))
                {
                    serializer.WriteObject(output, SerializeObjectsWrapper.Instance);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
