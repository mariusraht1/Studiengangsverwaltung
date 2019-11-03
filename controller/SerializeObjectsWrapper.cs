using Universitätsverwaltung.model;
using System.Runtime.Serialization;

namespace Universitätsverwaltung.controller
{
    [DataContract]
    [KnownType(typeof(Dozent))]
    [KnownType(typeof(Student))]
    [KnownType(typeof(Rolle))]
    [KnownType(typeof(Semester))]
    [KnownType(typeof(KursDozent))]
    public class SerializeObjectsWrapper
    {
        [DataMember(Order = 0)]
        protected AbschlussListe AbschlussListe { get; set; }
        [DataMember(Order = 1)]
        protected AdressListe AdressListe { get; set; }
        [DataMember(Order = 2)]
        protected PersonListe PersonListe { get; set; }
        [DataMember(Order = 3)]
        protected KursListe KursListe { get; set; }
        [DataMember(Order = 4)]
        protected StudiengangListe StudiengangListe { get; set; }

        private static SerializeObjectsWrapper instance;

        public static SerializeObjectsWrapper Instance
        {
            get { return instance ?? (instance = new SerializeObjectsWrapper()); }
        }

        private SerializeObjectsWrapper()
        {
            AbschlussListe = AbschlussListe.Instance;
            AdressListe = AdressListe.Instance;
            PersonListe = PersonListe.Instance;
            KursListe = KursListe.Instance;
            StudiengangListe = StudiengangListe.Instance;
        }

        public static void SetInstance(SerializeObjectsWrapper serializeObjectsWrapper)
        {
            instance = serializeObjectsWrapper;
        }

        public void Deserialize()
        {
            AbschlussListe.SetInstance(AbschlussListe);
            AdressListe.SetInstance(AdressListe);
            PersonListe.SetInstance(PersonListe);
            KursListe.SetInstance(KursListe);
            StudiengangListe.SetInstance(StudiengangListe);
        }
    }
}
