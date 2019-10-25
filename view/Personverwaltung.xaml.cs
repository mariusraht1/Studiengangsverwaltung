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
        private bool[] validAttributes = new bool[10];
        private enum PersonArtAttribute
        {
            matrikelnummer = 1,
            ects = 3,
            abschluss = 2
        }

        public DatePickerTextBox Dptb_geburtsdatum { get; private set; }

        public Personverwaltung()
        {
            InitializeComponent();

            validationController = new ValidationController(validAttributes, lbl_error_msg, btn_save_person);

            lv_person.ItemsSource = PersonListe.Instance;
            cb_rolle.ItemsSource = Enum.GetValues(typeof(Rolle));
            cb_rolle.SelectedItem = Rolle.Student;
        }

        private void Dp_geburtsdatum_Loaded(object sender, RoutedEventArgs e)
        {
            DatePickerTextBox datePickerTextBox = (DatePickerTextBox)dp_geburtsdatum.Template.FindName("PART_TextBox", dp_geburtsdatum);

            if (datePickerTextBox != null)
            {
                datePickerTextBox.Focus();
            }
        }

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
            Settings.Instance.ChangesApplied = false;

            btn_reset_person.IsEnabled = false;
            btn_new_person.IsEnabled = true;
            btn_del_person.IsEnabled = true;
            btn_save_person.IsEnabled = false;

            Person selectedPerson = lv_person.SelectedItem as Person;

            if (selectedPerson != null)
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

                for (int i = 0; i < validAttributes.Length; i++)
                {
                    validAttributes[i] = true;
                }
            }
            else
            {
                for (int i = 0; i < validAttributes.Length; i++)
                {
                    validAttributes[i] = false;
                }
            }
        }

        private void Cb_rolle_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

                    validAttributes[(int)PersonArtAttribute.abschluss] = false;
                    validAttributes[(int)PersonArtAttribute.matrikelnummer] = true;
                    validAttributes[(int)PersonArtAttribute.ects] = true;
                    break;
                case Rolle.Student:
                    tb_matrikelnummer.IsEnabled = true;
                    tb_ects.IsEnabled = true;
                    tb_abschluss.Text = "";
                    tb_abschluss.IsEnabled = false;

                    validAttributes[(int)PersonArtAttribute.abschluss] = true;
                    validAttributes[(int)PersonArtAttribute.matrikelnummer] = false;
                    validAttributes[(int)PersonArtAttribute.ects] = false;
                    break;
            }

            Person selectedPerson = lv_person.SelectedItem as Person;

            if (selectedPerson != null)
            {
                if (!rolle.Equals(selectedPerson.Rolle))
                {
                    btn_reset_person.IsEnabled = true;
                }
            }
        }

        #endregion

        #region TextBox

        private void Dp_geburtsdatum_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(0, typeof(Person), dp_geburtsdatum, dp_geburtsdatum.Text, "Geburtsdatum", lbl_geburtsdatum.Content.ToString());
        }

        private void Tb_matrikelnummer_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(1, typeof(Student), tb_matrikelnummer, tb_matrikelnummer.Text, "Matrikelnummer", lbl_matrikelnummer.Content.ToString());
        }

        private void Tb_abschluss_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(2, typeof(Abschluss), tb_abschluss, tb_abschluss.Text, "Name", lbl_abschluss.Content.ToString());
        }

        private void Tb_ects_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(3, typeof(Student), tb_ects, tb_ects.Text, "ECTS", lbl_ects.Content.ToString());
        }

        private void Tb_vorname_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(4, typeof(Person), tb_vorname, tb_vorname.Text, "Vorname", lbl_vorname.Content.ToString());
        }

        private void Tb_nachname_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(5, typeof(Person), tb_nachname, tb_nachname.Text, "Nachname", lbl_nachname.Content.ToString());
        }

        private void Tb_strasse_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(6, typeof(Adresse), tb_strasse, tb_strasse.Text, "Strasse", lbl_strasse_nr.Content.ToString());
        }

        private void Tb_hausnummer_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(7, typeof(Adresse), tb_hausnummer, tb_hausnummer.Text, "Hausnummer", lbl_strasse_nr.Content.ToString());
        }

        private void Tb_postleitzahl_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(8, typeof(Adresse), tb_postleitzahl, tb_postleitzahl.Text, "Postleitzahl", lbl_plz_ort.Content.ToString());
        }

        private void Tb_ort_KeyUp(object sender, KeyEventArgs e)
        {
            validationController.ValidateAttribute(9, typeof(Adresse), tb_ort, tb_ort.Text, "Ort", lbl_plz_ort.Content.ToString());
        }

        #endregion

        #region Button

        private void btn_reset_person_Click(object sender, RoutedEventArgs e)
        {
            Lv_person_SelectionChanged(null, null);
        }

        private void btn_new_person_Click(object sender, RoutedEventArgs e)
        {
            lv_person.SelectedIndex = -1;
            btn_new_person.IsEnabled = false;
            btn_del_person.IsEnabled = false;

            cb_rolle.SelectedIndex = 0;
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

        private void btn_del_person_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = lv_person.SelectedItem as Person;
            PersonListe.Instance.Remove(selectedPerson);

            btn_new_person_Click(null, null);
        }

        private void btn_save_person_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = lv_person.SelectedItem as Person;
            Person newPerson = null;

            Rolle rolle = (Rolle)cb_rolle.SelectedItem;
            string vorname = tb_vorname.Text;
            string nachname = tb_nachname.Text;
            string strasse = tb_strasse.Text;
            string hausnummer = tb_hausnummer.Text;
            string postleitzahl = tb_postleitzahl.Text;
            string ort = tb_ort.Text;
            Adresse adresse = new Adresse(strasse, hausnummer, tb_postleitzahl.Text, tb_ort.Text);
            DateTime geburtstag = dp_geburtsdatum.SelectedDate.Value;
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

            if (selectedPerson == null)
            {
                switch (!IsDuplicate(newPerson))
                {
                    case true:
                        PersonListe.Instance.Add(newPerson);
                        lv_person.SelectedIndex = PersonListe.Instance.Count - 1;
                        break;
                }
            }
            else
            {
                Person existingPerson = PersonListe.Instance.Where(x => x.Equals(selectedPerson)).Single();
                int indexExistingPerson = PersonListe.Instance.IndexOf(existingPerson);

                PersonListe.Instance[indexExistingPerson] = newPerson;
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
                MessageBox.Show("Person existiert bereits:" +
                    "\nRolle: " + personResult1[0].Rolle +
                    "\nName: " + personResult1[0].Vorname + " " + personResult1[0].Nachname +
                    "\nGeburtsdatum: " + personResult1[0].Geburtsdatum.ToShortDateString() +
                    "\nAdresse: " + personResult1[0].Adresse, "Person vorhanden", MessageBoxButton.OK);

                btn_new_person.IsEnabled = true;
                return true;
            }
            else if (personResult2.Count > 0)
            {
                string msgTxt = "Person existiert bereits:";

                foreach (Person person in personResult2)
                {
                    msgTxt += "Vorname: " + person.Vorname + "; Nachname: " + person.Nachname
                                + "; Geburtsdatum: " + person.Geburtsdatum + "\n";
                }

                msgTxt += "Möchten Sie die Person dennoch anlegen?";

                MessageBoxResult msgBoxResult = MessageBox.Show(msgTxt, "Person vorhanden", MessageBoxButton.YesNo);

                switch (msgBoxResult)
                {
                    case MessageBoxResult.Yes:
                        return false;
                    default:
                        btn_new_person.IsEnabled = true;
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
