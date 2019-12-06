using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Universitätsverwaltung.model
{
    public class KursDozentListe : ObservableCollection<KursDozent>, ICloneable
    {
        private static KursDozentListe instance;

        public static KursDozentListe Instance
        {
            get { return instance ?? (instance = new KursDozentListe()); }
        }

        public static void SetInstance(KursDozentListe kursDozentListe)
        {
            instance = kursDozentListe;
        }

        public KursDozentListe() { }

        public KursDozentListe(List<KursDozent> list) : base(list)
        {
            instance = this;
        }

        public PersonListe GetDozentListe()
        {
            PersonListe dozentListe = new PersonListe();

            foreach (KursDozent kursDozent in this)
            {
                dozentListe.Add(kursDozent.Dozent);
            }

            return dozentListe;
        }

        public KursListe GetKursListe()
        {
            KursListe kursListe = new KursListe();

            foreach(KursDozent kursDozent in this)
            {
                kursListe.Add(kursDozent.Kurs);
            }

            return kursListe;
        }

        internal bool Contains(Kurs kurs)
        {
            throw new NotImplementedException();
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

        public object Clone()
        {
            KursDozentListe kursDozentListe = new KursDozentListe();

            foreach (KursDozent kursDozent in this)
            {
                kursDozentListe.Add((KursDozent)kursDozent.Clone());
            }

            return kursDozentListe;
        }
    }
}
