using System.Windows;
using System.Windows.Controls;
using Universitätsverwaltung.controller;

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

        private void Tb_name_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            tb_name.Focus();
        }

        #region ListViewSorter

        private ListViewSorter lvKursSorter = new ListViewSorter();

        private void GridViewColumnHeaderLvKursClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            lvKursSorter.SortHeader(headerClicked, lv_kurs);
        }

        #endregion
    }
}
