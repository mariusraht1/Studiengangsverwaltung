using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;
using ValidationController = Universitätsverwaltung.controller.ValidationController;

namespace Universitätsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für Personverwaltung.xaml
    /// </summary>
    public partial class Personverwaltung : UserControl
    {
        private static Personverwaltung instance;

        public static Personverwaltung Instance => instance ?? (instance = new Personverwaltung());

        private ValidationController validationController = null;
        private enum PersonArtAttribute
        {
            matrikelnummer = 1,
            abschluss = 2,
            ects = 3
        }

        public Personverwaltung()
        {
            InitializeComponent();

            validationController = new ValidationController(new bool[10], lbl_error_msg);
        }

        #region Loaded

        private void lv_person_Loaded(object sender, RoutedEventArgs e)
        {
            lv_person.ItemsSource = PersonListe.Instance;
        }

        private void cb_rolle_Loaded(object sender, RoutedEventArgs e)
        {
            cb_rolle.ItemsSource = Enum.GetValues(typeof(Rolle));
        }

        private void Dp_geburtsdatum_Loaded(object sender, RoutedEventArgs e)
        {
            DatePickerTextBox datePickerTextBox = (DatePickerTextBox)dp_geburtsdatum.Template.FindName("PART_TextBox", dp_geburtsdatum);

            if (datePickerTextBox != null)
            {
                datePickerTextBox.Focus();
            }
        }

        #endregion

        #region ListViewSorter

        private ListViewSorter lvPersonSorter = new ListViewSorter();

        private void GridViewColumnHeaderLvPersonClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            lvPersonSorter.SortHeader(headerClicked, lv_person);
        }

        #endregion

        #region SelectionChanged

        private void Lv_person_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_reset.IsEnabled = false;
            btn_new.IsEnabled = true;
            btn_del.IsEnabled = true;
            btn_save.IsEnabled = false;

            if (lv_person.SelectedItem is Person selectedPerson)
            {
                dp_geburtsdatum.SelectedDate = selectedPerson.Geburtsdatum;
                tb_vorname.Text = selectedPerson.Vorname;
                tb_nachname.Text = selectedPerson.Nachname;
                tb_strasse.Text = selectedPerson.Adresse.Strasse;
                tb_hausnummer.Text = selectedPerson.Adresse.Hausnummer;
                tb_postleitzahl.Text = selectedPerson.Adresse.Postleitzahl.ToString();
                tb_ort.Text = selectedPerson.Adresse.Ort;

                cb_rolle.SelectedItem = selectedPerson.Rolle;

                switch (selectedPerson.Rolle)
                {
                    case Rolle.Dozent:
                        Dozent dozent = (Dozent)selectedPerson;
                        tb_abschluss.Text = dozent.Abschluss.Name;
                        break;
                    case Rolle.Student:
                        Student student = (Student)selectedPerson;
                        tb_matrikelnummer.Text = student.Matrikelnummer.ToString();
                        tb_ects.Text = student.ECTS.ToString();
                        break;
                }

                validationController.ResetValidAttributes(true);
            }
            else
            {
                validationController.ResetValidAttributes(false);
            }
        }

        private void cb_rolle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rolle rolle = (Rolle)cb_rolle.SelectedItem;

            switch (rolle)
            {
                case Rolle.Dozent:
                    tb_matrikelnummer.Text = "";
                    tb_matrikelnummer.IsEnabled = false;
                    tb_ects.Text = "";
                    tb_ects.IsEnabled = false;
                    tb_abschluss.IsEnabled = true;

                    validationController.ValidAttributes[(int)PersonArtAttribute.abschluss] = false;
                    validationController.ValidAttributes[(int)PersonArtAttribute.matrikelnummer] = true;
                    validationController.ValidAttributes[(int)PersonArtAttribute.ects] = true;
                    break;
                case Rolle.Student:
                    tb_matrikelnummer.IsEnabled = true;
                    tb_ects.IsEnabled = true;
                    tb_abschluss.Text = "";
                    tb_abschluss.IsEnabled = false;

                    validationController.ValidAttributes[(int)PersonArtAttribute.abschluss] = true;
                    validationController.ValidAttributes[(int)PersonArtAttribute.matrikelnummer] = false;
                    validationController.ValidAttributes[(int)PersonArtAttribute.ects] = false;
                    break;
            }

            EnableResetbutton();
            EnableSaveButton();
        }

        #endregion

        #region TextChanged

        private void Dp_geburtsdatum_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 0, typeof(Person), dp_geburtsdatum, dp_geburtsdatum.Text, "Geburtsdatum", lbl_geburtsdatum.Content.ToString());
        }

        private void tb_matrikelnummer_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 1, typeof(Student), tb_matrikelnummer, tb_matrikelnummer.Text, "Matrikelnummer", lbl_matrikelnummer.Content.ToString());
        }

        private void tb_abschluss_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 2, typeof(Abschluss), tb_abschluss, tb_abschluss.Text, "Name", lbl_abschluss.Content.ToString());
        }

        private void tb_ects_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 3, typeof(Student), tb_ects, tb_ects.Text, "ECTS", lbl_ects.Content.ToString());
        }

        private void tb_vorname_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 4, typeof(Person), tb_vorname, tb_vorname.Text, "Vorname", lbl_vorname.Content.ToString());
        }

        private void tb_nachname_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 5, typeof(Person), tb_nachname, tb_nachname.Text, "Nachname", lbl_nachname.Content.ToString());
        }

        private void tb_strasse_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 6, typeof(Adresse), tb_strasse, tb_strasse.Text, "Strasse", lbl_strasse_nr.Content.ToString());
        }

        private void tb_hausnummer_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 7, typeof(Adresse), tb_hausnummer, tb_hausnummer.Text, "Hausnummer", lbl_strasse_nr.Content.ToString());
        }

        private void tb_postleitzahl_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 8, typeof(Adresse), tb_postleitzahl, tb_postleitzahl.Text, "Postleitzahl", lbl_plz_ort.Content.ToString());
        }

        private void tb_ort_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateInput(e, 9, typeof(Adresse), tb_ort, tb_ort.Text, "Ort", lbl_plz_ort.Content.ToString());
        }

        private void ValidateInput(KeyEventArgs e, int valID, Type type, Control control, string value, string propertyName, string displayName)
        {
            if (!e.Key.Equals(Key.Enter) && !e.Key.Equals(Key.Escape))
            {
                validationController.IsValidAttribute(valID, type, control, value, propertyName, displayName);
                EnableSaveButton();
                EnableResetbutton();
            }
        }

        private void EnableSaveButton()
        {
            switch (validationController.IsValidObject() && HasChanged())
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
            Person person = null;
            Person selectedPerson = (Person)lv_person.SelectedItem;

            if (selectedPerson != null)
            {
                Adresse adresse = new Adresse(tb_strasse.Text, tb_hausnummer.Text, tb_postleitzahl.Text, tb_ort.Text);
                Abschluss abschluss = new Abschluss(tb_abschluss.Text);

                switch (cb_rolle.SelectedItem)
                {
                    case Rolle.Dozent:
                        Dozent dozent = new Dozent(tb_vorname.Text, tb_nachname.Text, adresse, dp_geburtsdatum.Text, abschluss);
                        person = dozent;
                        break;
                    case Rolle.Student:
                        Student student = new Student(tb_vorname.Text, tb_nachname.Text, adresse, dp_geburtsdatum.Text, tb_matrikelnummer.Text, tb_ects.Text);
                        person = student;
                        break;
                }

                return person.Equals(selectedPerson);
            }
            else
            {
                return true;
            }
        }

        private void EnableResetbutton()
        {
            switch (lv_person.SelectedItem is Person
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

        #region GotFocus

        private void Dp_geburtsdatum_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            DatePickerTextBox dptb_geburtsdatum = (DatePickerTextBox)dp_geburtsdatum.Template.FindName("PART_TextBox", dp_geburtsdatum);

            if (dptb_geburtsdatum != null)
            {
                dptb_geburtsdatum.SelectAll();
            }
        }

        private void tb_matrikelnummer_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_matrikelnummer.SelectAll();
        }

        private void tb_ects_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_ects.SelectAll();
        }

        private void tb_abschluss_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_abschluss.SelectAll();
        }

        private void tb_vorname_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_vorname.SelectAll();
        }

        private void tb_nachname_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_nachname.SelectAll();
        }

        private void tb_strasse_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_strasse.SelectAll();
        }

        private void tb_hausnummer_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_hausnummer.SelectAll();
        }

        private void tb_postleitzahl_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_postleitzahl.SelectAll();
        }

        private void tb_ort_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            tb_ort.SelectAll();
        }

        #endregion

        #region OnClick

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            Lv_person_SelectionChanged(null, null);
            lbl_error_msg.Content = "";
        }

        private void btn_new_Click(object sender, RoutedEventArgs e)
        {
            lv_person.SelectedIndex = -1;
            btn_new.IsEnabled = false;
            btn_del.IsEnabled = false;

            cb_rolle_SelectionChanged(null, null);
            dp_geburtsdatum.Text = "";
            tb_matrikelnummer.Text = "";
            tb_ects.Text = "";
            tb_abschluss.Text = "";
            tb_vorname.Text = "";
            tb_nachname.Text = "";
            tb_strasse.Text = "";
            tb_hausnummer.Text = "";
            tb_postleitzahl.Text = "";
            tb_ort.Text = "";

            dp_geburtsdatum.Focus();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = lv_person.SelectedItem as Person;
            PersonListe.Instance.Remove(selectedPerson);

            btn_new_Click(null, null);
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Person newPerson = null;

            Rolle rolle = (Rolle)cb_rolle.SelectedItem;
            string vorname = tb_vorname.Text;
            string nachname = tb_nachname.Text;
            string strasse = tb_strasse.Text;
            string hausnummer = tb_hausnummer.Text;
            string postleitzahl = tb_postleitzahl.Text;
            string ort = tb_ort.Text;
            Adresse adresse = new Adresse(strasse, hausnummer, tb_postleitzahl.Text, tb_ort.Text);
            string geburtstag = dp_geburtsdatum.Text;
            Abschluss abschluss = new Abschluss(tb_abschluss.Text);
            string matrikelnummer = tb_matrikelnummer.Text;
            string ects = tb_ects.Text;

            if (rolle.Equals(Rolle.Dozent))
            {
                Dozent dozent = new Dozent(vorname, nachname, adresse, geburtstag, abschluss);
                newPerson = dozent;
            }
            else
            {
                Student student = new Student(vorname, nachname, adresse, geburtstag, matrikelnummer, ects);
                newPerson = student;
            }

            if (lv_person.SelectedItem is Person selectedPerson)
            {
                Person existingPerson = PersonListe.Instance.Where(x => x.Equals(selectedPerson)).Single();
                int indexExistingPerson = PersonListe.Instance.IndexOf(existingPerson);

                PersonListe.Instance[indexExistingPerson] = newPerson;
                lv_person.SelectedItem = newPerson;
            }
            else if (!IsDuplicate(newPerson))
            {
                PersonListe.Instance.Add(newPerson);
                lv_person.SelectedItem = newPerson;
            }
        }

        private bool IsDuplicate(Person newPerson)
        {
            List<Person> personResult1 = PersonListe.Instance.Where(x => x.Equals(newPerson)).ToList();
            List<Person> personResult2 = PersonListe.Instance.Where(x => x.Vorname.Equals(newPerson.Vorname)
                                                                    && x.Nachname.Equals(newPerson.Nachname)
                                                                    && x.Geburtsdatum.Equals(newPerson.Geburtsdatum))
                                                             .ToList();

            if (personResult1.Count > 0)
            {
                MessageBox.Show($"Person existiert bereits:" +
                    $"\nRolle: { personResult1[0].Rolle }" +
                    $"\nName: { personResult1[0].Vorname } { personResult1[0].Nachname }" +
                    $"\nGeburtsdatum: { personResult1[0].Geburtsdatum.ToShortDateString() }" +
                    $"\nAdresse: { personResult1[0].Adresse }", "Person vorhanden", MessageBoxButton.OK);

                btn_new.IsEnabled = true;
                return true;
            }
            else if (personResult2.Count > 0)
            {
                string msgTxt = "Person existiert bereits:";

                foreach (Person person in personResult2)
                {
                    msgTxt += $"Vorname: { person.Vorname }; Nachname: { person.Nachname }; Geburtsdatum: { person.Geburtsdatum }\n";
                }

                msgTxt += "Möchten Sie die Person dennoch anlegen?";

                MessageBoxResult msgBoxResult = MessageBox.Show(msgTxt, "Person vorhanden", MessageBoxButton.YesNo);

                switch (msgBoxResult)
                {
                    case MessageBoxResult.Yes:
                        return false;
                    default:
                        btn_new.IsEnabled = true;
                        return true;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
