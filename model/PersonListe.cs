using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Universitätsverwaltung.model
{
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
    }
}
