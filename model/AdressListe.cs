using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            AdressListe adressListe = (AdressListe)obj;

            if (adressListe.Count != Count)
            {
                return false;
            }

            foreach (Adresse adresse in adressListe)
            {
                if (!Contains(adresse))
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        protected override void InsertItem(int index, Adresse item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, Adresse item)
        {
            base.SetItem(index, item);
        }

        protected override void MoveItem(int oldIndex, int newIndex)
        {
            base.MoveItem(oldIndex, newIndex);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
        }
    }
}
