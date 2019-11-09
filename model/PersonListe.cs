using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class PersonListe : ObservableCollection<Person>
    {
        private static PersonListe instance;

        public static PersonListe Instance
        {
            get { return instance ?? (instance = new PersonListe()); }
        }

        public static void SetInstance(PersonListe personListe)
        {
            instance = personListe;
        }

        public PersonListe() { }
        public PersonListe(List<Person> list) : base(list) { }

        public PersonListe GetDozentListe()
        {
            return new PersonListe(instance.Where(x => x.Rolle.Equals(Rolle.Dozent)).ToList());
        }

        public PersonListe GetStudentListe()
        {
            return new PersonListe(instance.Where(x => x.Rolle.Equals(Rolle.Student)).ToList());
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

            PersonListe personListe = (PersonListe)obj;

            if (personListe.Count != Count)
            {
                return false;
            }

            foreach (Person person in personListe)
            {
                if (!Contains(person))
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

        protected override void InsertItem(int index, Person item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, Person item)
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
            PersonListe personListe = new PersonListe();

            foreach (Person person in this)
            {
                if (person is Dozent dozent)
                {
                    personListe.Add((Dozent)dozent.Clone());
                }
                else if (person is Student student)
                {
                    personListe.Add((Student)student.Clone());
                }
            }

            return personListe;
        }
    }
}
