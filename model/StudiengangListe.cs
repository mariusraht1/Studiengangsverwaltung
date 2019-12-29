using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Universitätsverwaltung.model
{
    public class StudiengangListe : ObservableCollection<Studiengang>, ICloneable
    {
        private static StudiengangListe instance;

        public static StudiengangListe Instance
        {
            get { return instance ?? (instance = new StudiengangListe()); }
        }

        public static void SetInstance(StudiengangListe studiengangListe)
        {
            instance = studiengangListe;
        }

        public StudiengangListe() { }

        public StudiengangListe(List<Studiengang> list) : base(list)
        {
        }

        public void Remove(Student student)
        {
            foreach(Studiengang studiengang in this)
            {
                studiengang.StudentListe.Remove(student);
            }
        }

        public void Remove(Kurs kurs)
        {
            foreach(Studiengang studiengang in this)
            {
                studiengang.SemesterListe.Remove(kurs);
            }
        }

        public void Remove(Dozent dozent)
        {
            foreach(Studiengang studiengang in this)
            {
                studiengang.SemesterListe.Remove(dozent);
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

            StudiengangListe studiengangListe = (StudiengangListe)obj;

            if (studiengangListe.Count != Count)
            {
                return false;
            }

            foreach (Studiengang studiengang in studiengangListe)
            {
                if (!Contains(studiengang))
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

        protected override void InsertItem(int index, Studiengang item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, Studiengang item)
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
            StudiengangListe studiengangListe = new StudiengangListe();

            foreach (Studiengang studiengang in this)
            {
                studiengangListe.Add((Studiengang)studiengang.Clone());
            }

            return studiengangListe;
        }
    }
}
