using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class KursDozentListe : ObservableCollection<KursDozent>
    {
        private static KursDozentListe instance;

        public static KursDozentListe Instance
        {
            get { return instance ?? (instance = new KursDozentListe()); }
        }

        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected override event PropertyChangedEventHandler PropertyChanged;

        public static void SetInstance(KursDozentListe kursDozentListe)
        {
            instance = kursDozentListe;
        }

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

            KursDozentListe kursDozentListe = (KursDozentListe)obj;

            if (kursDozentListe.Count != Count)
            {
                return false;
            }

            foreach (KursDozent kursDozent in kursDozentListe)
            {
                if (!Contains(kursDozent))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }

        protected override void InsertItem(int index, KursDozent item)
        {
            base.InsertItem(index, item);
        }

        protected override void MoveItem(int oldIndex, int newIndex)
        {
            base.MoveItem(oldIndex, newIndex);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, KursDozent item)
        {
            base.SetItem(index, item);
        }
    }
}
