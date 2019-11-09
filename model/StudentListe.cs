using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class StudentListe : ObservableCollection<Student>
    {
        private static StudentListe instance;

        public static StudentListe Instance
        {
            get { return instance ?? (instance = new StudentListe()); }
        }

        public StudentListe() { }

        public StudentListe(IEnumerable<Student> collection) : base(collection)
        {
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

            StudentListe studentListe = (StudentListe)obj;

            if (studentListe.Count != Count)
            {
                return false;
            }

            foreach (Student student in studentListe)
            {
                if(!Contains(student))
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

        protected override void InsertItem(int index, Student item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, Student item)
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
