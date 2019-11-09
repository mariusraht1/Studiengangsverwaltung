using System;
using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class AdressListe : ObservableCollection<Adresse>
    {
        private static AdressListe instance;

        public static AdressListe Instance
        {
            get { return instance ?? (instance = new AdressListe()); }
        }

        public static void SetInstance(AdressListe adressListe)
        {
            instance = adressListe;
        }

        public AdressListe() { }
    }
}
