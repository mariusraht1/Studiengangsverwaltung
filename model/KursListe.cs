using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Universitätsverwaltung.model
{
    public class KursListe : ObservableCollection<Kurs>
    {
        private static KursListe instance;

        public static KursListe Instance
        {
            get { return instance ?? (instance = new KursListe()); }
        }

        public static void SetInstance(KursListe kursListe)
        {
            instance = kursListe;
        }

        public KursListe() { }

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

            KursListe kursListe = (KursListe)obj;

            if (kursListe.Count != Count)
            {
                return false;
            }

            foreach (Kurs kurs in kursListe)
            {
                if (!Contains(kurs))
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

        protected override void InsertItem(int index, Kurs item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, Kurs item)
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
