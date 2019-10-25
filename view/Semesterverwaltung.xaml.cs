using System.Windows;
using System.Windows.Controls;
using Universitätsverwaltung.controller;

namespace Universitätsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für Semesterverwaltung.xaml
    /// </summary>
    public partial class Semesterverwaltung : UserControl
    {
        private static Semesterverwaltung instance;

        public static Semesterverwaltung Instance => instance ?? (instance = new Semesterverwaltung());

        public Semesterverwaltung()
        {
            InitializeComponent();
        }

        public void Init()
        {

        }

        private void Tb_semester_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            tb_semester.Focus();
        }

        private ListViewSorter lvSemesterSorter = new ListViewSorter();

        private void GridViewColumnHeaderLvPersonClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            lvSemesterSorter.SortHeader(headerClicked, lv_semester);
        }
    }
}
