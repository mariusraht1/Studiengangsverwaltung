using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für Semesterverwaltung.xaml
    /// </summary>
    public partial class Semesterverwaltung : UserControl
    {
        private static Semesterverwaltung instance;

        public static Semesterverwaltung Instance => instance ?? (instance = new Semesterverwaltung());

        private ValidationController validationController = null;
        private bool[] validAttributes = new bool[4];

        public Semesterverwaltung()
        {
            InitializeComponent();

            validationController = new ValidationController(validAttributes, lbl_error_msg, btn_save_semester);
        }

        private void Tb_semester_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            tb_semester.Focus();
        }

        #region ListViewSorter

        private ListViewSorter lvSemesterSorter = new ListViewSorter();

        private void GridViewColumnHeaderLvSemesterClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            lvSemesterSorter.SortHeader(headerClicked, lv_semester);
        }

        #endregion

        #region SelectionChanged

        private void Lv_semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #endregion

        #region TextBox

        private void Tb_semester_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validationController.ValidateAttribute(0, typeof(Semester), tb_semester, tb_semester.Text, "Nummer", lbl_semester.Content.ToString());
        }

        private void Dp_startdatum_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validationController.ValidateAttribute(1, typeof(Semester), dp_startdatum, dp_startdatum.Text, "Startdatum", lbl_semester.Content.ToString());
        }

        private void Dp_endedatum_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validationController.ValidateAttribute(2, typeof(Semester), dp_endedatum, dp_endedatum.Text, "Endedatum", lbl_semester.Content.ToString());
        }

        private void Tb_beschreibung_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validationController.ValidateAttribute(3, typeof(Semester), tb_beschreibung, tb_beschreibung.Text, "Beschreibung", lbl_beschreibung.Content.ToString());
        }

        #endregion

        #region Button

        private void Btn_reset_semester_Click(object sender, RoutedEventArgs e)
        {
            Lv_semester_SelectionChanged(null, null);
        }

        private void Btn_new_semester_Click(object sender, RoutedEventArgs e)
        {
            lv_semester.SelectedIndex = -1;
            btn_new_semester.IsEnabled = false;
            btn_del_semester.IsEnabled = false;

            tb_semester.Text = "";
            dp_startdatum.Text = "";
            dp_endedatum.Text = "";
            tb_beschreibung.Text = "";

            tb_semester.Focus();
        }

        private void Btn_del_semester_Click(object sender, RoutedEventArgs e)
        {
            Semester selectedsemester = lv_semester.SelectedItem as Semester;
            SemesterListe.Instance.Remove(selectedsemester);

            Btn_new_semester_Click(null, null);
        }

        private void Btn_save_semester_Click(object sender, RoutedEventArgs e)
        {
            Semester selectedsemester = lv_semester.SelectedItem as Semester;

            string semesterID = tb_semester.Text;
            DateTime startdatum = dp_startdatum.SelectedDate.Value;
            DateTime endedatum = dp_endedatum.SelectedDate.Value;
            string beschreibung = tb_beschreibung.Text;

            Semester newSemester = new Semester(semesterID, beschreibung, startdatum, endedatum);

            if (selectedsemester == null)
            {
                switch (!IsDuplicate(newSemester))
                {
                    case true:
                        SemesterListe.Instance.Add(newSemester);
                        lv_semester.SelectedIndex = SemesterListe.Instance.Count - 1;
                        break;
                }
            }
            else
            {
                Semester existingsemester = SemesterListe.Instance.Where(x => x.Equals(selectedsemester)).Single();
                int indexExistingsemester = SemesterListe.Instance.IndexOf(existingsemester);

                SemesterListe.Instance[indexExistingsemester] = newSemester;
            }
        }

        private bool IsDuplicate(Semester newSemester)
        {
            List<Semester> semesterResult1 = SemesterListe.Instance.Where(x => x.Equals(newSemester)).ToList();

            if (semesterResult1.Count > 0)
            {
                MessageBox.Show("Semester existiert bereits:" +
                    "\nNummer: " + semesterResult1[0].Nummer +
                    "\nStartdatum: " + semesterResult1[0].Startdatum.ToShortDateString() +
                    "\nEndedatum: " + semesterResult1[0].Endedatum, "Semester vorhanden", MessageBoxButton.OK);

                btn_new_semester.IsEnabled = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
