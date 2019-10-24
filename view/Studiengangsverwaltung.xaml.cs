using System.Linq;
using System.Windows.Controls;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für Studiengangsverwaltung.xaml
    /// </summary>
    public partial class Studiengangsverwaltung : UserControl
    {
        private static Studiengangsverwaltung instance;

        public static Studiengangsverwaltung Instance
        {
            get { return instance ?? (instance = new Studiengangsverwaltung()); }
        }

        public Studiengangsverwaltung()
        {
            InitializeComponent();

            cb_semester.ItemsSource = SemesterListe.Instance;
            cb_kurs.ItemsSource = KursListe.Instance;
            cb_dozent.ItemsSource = PersonListe.Instance.Where(x => x.Rolle.Equals(Rolle.Dozent)).ToList();
            cb_student.ItemsSource = PersonListe.Instance.Where(x => x.Rolle.Equals(Rolle.Student)).ToList();

            lv_studiengang.ItemsSource = StudiengangListe.Instance;
        }

        public void Init()
        {

        }
    }
}
