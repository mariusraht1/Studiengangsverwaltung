using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
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

        private ValidationController validationControllerStudiengang = null;
        private ValidationController validationControllerSemester = null;

        public Studiengangsverwaltung()
        {
            InitializeComponent();

            validationControllerStudiengang = new ValidationController(new bool[3], lbl_error_msg, btn_save);
            validationControllerSemester = new ValidationController(new bool[3], lbl_error_msg, btn_save);

            cb_kurs.ItemsSource = KursListe.Instance.OrderBy(x => x);
            cb_dozent.ItemsSource = PersonListe.Instance.Where(x => x.Rolle.Equals(Rolle.Dozent)).ToList().OrderBy(x => x);
            cb_student.ItemsSource = PersonListe.Instance.Where(x => x.Rolle.Equals(Rolle.Student)).ToList().OrderBy(x => x);

            lv_studiengang.ItemsSource = StudiengangListe.Instance;
        }

        private void tb_studiengang_Loaded(object sender, System.Windows.RoutedEventArgs e)
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

        #region GotFocus
        private void tb_studiengang_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            tb_studiengang.SelectAll();
        }

        private void tb_abschluss_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            tb_abschluss.SelectAll();
        }

        private void tb_ects_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_ects.SelectAll();
        }

        private void tb_semester_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            tb_semester.SelectAll();
        }

        private void dp_startdatum_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            DatePickerTextBox dptb_startdatum = (DatePickerTextBox)dp_startdatum.Template.FindName("PART_TextBox", dp_startdatum);

            if (dptb_startdatum != null)
            {
                dptb_startdatum.SelectAll();
            }
        }

        private void dp_endedatum_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            DatePickerTextBox dptb_endedatum = (DatePickerTextBox)dp_endedatum.Template.FindName("PART_TextBox", dp_endedatum);

            if (dptb_endedatum != null)
            {
                dptb_endedatum.SelectAll();
            }
        }

        #endregion

        #region SelectionChanged

        private void lv_studiengang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lv_semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lv_kurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lv_student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #endregion

        #region TextChanged

        private void tb_studiengang_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ValidateInputStudiengang(e, 0, typeof(Studiengang), tb_studiengang, tb_studiengang.Text, "Name", lbl_studiengang.Content.ToString());
        }

        private void tb_abschluss_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInputStudiengang(e, 1, typeof(Abschluss), tb_abschluss, tb_abschluss.Text, "Name", lbl_abschluss.Content.ToString());
        }

        private void tb_ects_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInputStudiengang(e, 2, typeof(Studiengang), tb_ects, tb_ects.Text, "ECTS", lbl_ects.Content.ToString());
        }

        private void tb_semester_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInputSemester(e, 0, typeof(Semester), tb_semester, tb_semester.Text, "Nummer", lbl_semester.Content.ToString());
        }

        private void dp_startdatum_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInputSemester(e, 1, typeof(Semester), dp_startdatum, dp_startdatum.Text, "Startdatum", lbl_semester.Content.ToString());
        }

        private void dp_endedatum_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInputSemester(e, 2, typeof(Semester), dp_endedatum, dp_endedatum.Text, "Endedatum", lbl_semester.Content.ToString());
        }

        private void ValidateInputStudiengang(KeyEventArgs e, int valID, Type type, Control control, string value, string propertyName, string displayName)
        {
            if (!e.Key.Equals(Key.Enter) && !e.Key.Equals(Key.Escape))
            {
                validationControllerStudiengang.IsValidAttribute(valID, type, control, value, propertyName, displayName);
                EnableSaveButton();
                EnableResetbutton();
            }
        }

        private void ValidateInputSemester(KeyEventArgs e, int valID, Type type, Control control, string value, string propertyName, string displayName)
        {
            if (!e.Key.Equals(Key.Enter) && !e.Key.Equals(Key.Escape))
            {
                validationControllerSemester.IsValidAttribute(valID, type, control, value, propertyName, displayName);
                EnableAddSemesterButton();
                EnableResetbutton();
            }
        }

        private void EnableAddSemesterButton()
        {
            switch (validationControllerSemester.IsValidObject())
            {
                case true:
                    btn_add_semester.IsEnabled = true;
                    break;
                case false:
                    btn_add_semester.IsEnabled = false;
                    break;
            }
        }

        private void EnableSaveButton()
        {
            switch (validationControllerStudiengang.IsValidObject()
                    && HasChanged())
            {
                case true:
                    btn_save.IsEnabled = true;
                    break;
                case false:
                    btn_save.IsEnabled = false;
                    break;
            }
        }

        private bool HasChanged()
        {
            Studiengang selectedStudiengang = (Studiengang)lv_studiengang.SelectedItem;

            if (selectedStudiengang != null)
            {
                Abschluss abschluss = new Abschluss(tb_abschluss.Text);
                Studiengang studiengang = new Studiengang(tb_studiengang.Text, abschluss, tb_ects.Text, null, null);

                return studiengang.Equals(selectedStudiengang);
            }
            else
            {
                return true;
            }
        }

        private void EnableResetbutton()
        {
            switch (lv_studiengang.SelectedItem is Studiengang
                    && HasChanged())
            {
                case true:
                    btn_reset.IsEnabled = true;
                    break;
                case false:
                    btn_reset.IsEnabled = false;
                    break;
            }
        }

        #endregion

        #region OnClick

        private Studiengang newStudiengang = null;

        private void btn_add_semester_Click(object sender, RoutedEventArgs e)
        {
            Semester semester = new Semester(tb_semester.Text, dp_startdatum.Text, dp_endedatum.Text);

            newStudiengang.SemesterListe.Add(semester);
        }

        private void btn_add_kurs_Click(object sender, RoutedEventArgs e)
        {
            Semester selectedSemester = (Semester)lv_semester.SelectedItem;
            Kurs kurs = (Kurs)cb_kurs.SelectedItem;
            Dozent dozent = (Dozent)cb_dozent.SelectedItem;

            selectedSemester.KursDozentListe.Add(new KursDozent(kurs, dozent));
        }

        private void btn_add_student_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_del_semester_ClickedHandler(object sender, RoutedEventArgs e)
        {

        }

        private void btn_del_kurs_ClickedHandler(object sender, RoutedEventArgs e)
        {

        }

        private void btn_del_student_ClickedHandler(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
