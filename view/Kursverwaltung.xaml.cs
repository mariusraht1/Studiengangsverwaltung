using System.Windows.Controls;

namespace Universitätsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für Kursverwaltung.xaml
    /// </summary>
    public partial class Kursverwaltung : UserControl
    {
        private static Kursverwaltung instance;

        public static Kursverwaltung Instance
        {
            get { return instance ?? (instance = new Kursverwaltung()); }
        }

        public Kursverwaltung()
        {
            InitializeComponent();
        }

        public void Init()
        {

        }
    }
}
