using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class SemesterListe : ObservableCollection<Semester>
    {
        private static SemesterListe instance;

        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected override event PropertyChangedEventHandler PropertyChanged;

        public static SemesterListe Instance
        {
            get { return instance ?? (instance = new SemesterListe()); }
        }

        public static void SetInstance(SemesterListe semesterListe)
        {
            instance = semesterListe;
        }

        public SemesterListe() { }

        public SemesterListe(IEnumerable<Semester> collection) : base(collection)
        {
        }

        //public bool IsDuplicate(Semester semester)
        //{
        //    return Contains(semester);
        //}

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

            SemesterListe semesterListe = (SemesterListe)obj;

            if (semesterListe.Count != Count)
            {
                return false;
            }

            foreach (Semester semester in semesterListe)
            {
                if (!Contains(semester))
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

        protected override void InsertItem(int index, Semester item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, Semester item)
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
