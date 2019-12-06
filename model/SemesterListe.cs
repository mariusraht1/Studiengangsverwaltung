using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Universitätsverwaltung.model
{
    public class SemesterListe : ObservableCollection<Semester>, ICloneable
    {
        private static SemesterListe instance;

        public static SemesterListe Instance
        {
            get { return instance ?? (instance = new SemesterListe()); }
        }

        public static void SetInstance(SemesterListe studiengangListe)
        {
            instance = studiengangListe;
        }

        public SemesterListe() { }

        public SemesterListe(IEnumerable<Semester> collection) : base(collection)
        {
        }

        public void Remove(Kurs kurs)
        {
            foreach(Semester semester in this)
            {
                semester.Remove(kurs);
            }
        }

        public void Remove(Dozent dozent)
        {
            foreach (Semester semester in this)
            {
                semester.Remove(dozent);
            }
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

        public object Clone()
        {
            SemesterListe semesterListe = new SemesterListe();

            foreach (Semester semester in this)
            {
                semesterListe.Add((Semester)semester.Clone());
            }

            return semesterListe;
        }
    }
}
