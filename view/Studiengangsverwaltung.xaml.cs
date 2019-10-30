using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Universitätsverwaltung.controller;
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

            cb_kurs.ItemsSource = KursListe.Instance.OrderBy(x => x);
            cb_dozent.ItemsSource = PersonListe.Instance.Where(x => x.Rolle.Equals(Rolle.Dozent)).ToList().OrderBy(x => x);
            cb_student.ItemsSource = PersonListe.Instance.Where(x => x.Rolle.Equals(Rolle.Student)).ToList().OrderBy(x => x);

            lv_studiengang.ItemsSource = StudiengangListe.Instance;
        }

        public void Init()
        {

        }

        private void Tb_studiengang_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            tb_studiengang.Focus();
        }

        #region ListViewSorter

        private ListViewSorter lvStudiengangSorter = new ListViewSorter();
        private ListViewSorter lvSemesterSorter = new ListViewSorter();
        private ListViewSorter lvKursSorter = new ListViewSorter();
        private ListViewSorter lvStudentSorter = new ListViewSorter();

        private void GridViewColumnHeaderLvStudiengangClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            lvStudiengangSorter.SortHeader(headerClicked, lv_studiengang);
        }

        private void GridViewColumnHeaderLvSemesterClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            lvSemesterSorter.SortHeader(headerClicked, lv_semester);
        }

        private void GridViewColumnHeaderLvKursClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            lvKursSorter.SortHeader(headerClicked, lv_kurs);
        }

        private void GridViewColumnHeaderLvStudentClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            lvStudentSorter.SortHeader(headerClicked, lv_student);
        }

        #endregion

        #region OnClick

        private void Btn_del_semester_ClickedHandler(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_del_kurs_ClickedHandler(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_del_student_ClickedHandler(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
