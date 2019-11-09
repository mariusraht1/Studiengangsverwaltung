using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class AbschlussListe : ObservableCollection<Abschluss>
    {
        private static AbschlussListe instance;

        public static AbschlussListe Instance
        {
            get { return instance ?? (instance = new AbschlussListe()); }
        }

        public static void SetInstance(AbschlussListe abschlussListe)
        {
            instance = abschlussListe;
        }

        public AbschlussListe() { }

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

            AbschlussListe abschlussListe = (AbschlussListe)obj;

            if (abschlussListe.Count != Count)
            {
                return false;
            }

            foreach (Abschluss abschluss in abschlussListe)
            {
                if (!Contains(abschluss))
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

        protected override void InsertItem(int index, Abschluss item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, Abschluss item)
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
