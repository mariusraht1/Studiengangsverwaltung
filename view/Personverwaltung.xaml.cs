using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Universitätsverwaltung.model;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Universitätsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für Personverwaltung.xaml
    /// </summary>
    public partial class Personverwaltung : UserControl
    {
        private bool[] validAttribute = new bool[10];
        private enum personArtAttribute
        {
            matrikelnummer = 1,
            ects = 3,
            abschluss = 2
        }

        private static Personverwaltung instance;

        public static Personverwaltung Instance
        {
            get { return instance ?? (instance = new Personverwaltung()); }
        }

        public Personverwaltung()
        {
            InitializeComponent();

            lv_personen.ItemsSource = PersonListe.Instance;
            cb_rolle.ItemsSource = Enum.GetValues(typeof(Rolle));
            cb_rolle.SelectedItem = Rolle.Student;
        }

        private void Lv_personen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Settings.Instance.ChangesApplied = false;

            btn_reset_person.IsEnabled = false;
            btn_new_person.IsEnabled = true;
            btn_del_person.IsEnabled = true;
            btn_save_person.IsEnabled = false;

            Person selectedPerson = lv_personen.SelectedItem as Person;

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

                for (int i = 0; i < validAttribute.Length; i++)
                {
                    validAttribute[i] = true;
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

                    validAttribute[(int)personArtAttribute.matrikelnummer] = true;
                    validAttribute[(int)personArtAttribute.ects] = true;
                    break;
                case Rolle.Student:
                    tb_matrikelnummer.IsEnabled = true;
                    tb_ects.IsEnabled = true;
                    tb_abschluss.Text = "";
                    tb_abschluss.IsEnabled = false;

                    validAttribute[(int)personArtAttribute.abschluss] = true;
                    break;
            }

            Person selectedPerson = lv_personen.SelectedItem as Person;

            if (Settings.Instance.ChangesApplied == false
                && selectedPerson != null)
            {
                if (!rolle.Equals(selectedPerson.Rolle))
                {
                    Settings.Instance.ChangesApplied = true;

                    btn_reset_person.IsEnabled = true;
                    btn_save_person.IsEnabled = true;
                }
            }
        }

        #region TextBox

        private void Dp_geburtsdatum_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(0, typeof(Person), dp_geburtsdatum, dp_geburtsdatum.Text, "Geburtsdatum", lbl_geburtsdatum.Content.ToString());
        }

        private void Tb_matrikelnummer_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(1, typeof(Student), tb_matrikelnummer, tb_matrikelnummer.Text, "Matrikelnummer", lbl_matrikelnummer.Content.ToString());
        }

        private void Tb_abschluss_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(2, typeof(Abschluss), tb_abschluss, tb_abschluss.Text, "Name", lbl_abschluss.Content.ToString());
        }

        private void Tb_ects_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(3, typeof(Student), tb_ects, tb_ects.Text, "ECTS", lbl_ects.Content.ToString());
        }

        private void Tb_vorname_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(4, typeof(Person), tb_vorname, tb_vorname.Text, "Vorname", lbl_vorname.Content.ToString());
        }

        private void Tb_nachname_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(5, typeof(Person), tb_nachname, tb_nachname.Text, "Nachname", lbl_nachname.Content.ToString());
        }

        private void Tb_strasse_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(6, typeof(Adresse), tb_strasse, tb_strasse.Text, "Strasse", lbl_strasse_nr.Content.ToString());
        }

        private void Tb_hausnummer_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(7, typeof(Adresse), tb_hausnummer, tb_hausnummer.Text, "Hausnummer", lbl_strasse_nr.Content.ToString());
        }

        private void Tb_postleitzahl_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(8, typeof(Adresse), tb_postleitzahl, tb_postleitzahl.Text, "Postleitzahl", lbl_plz_ort.Content.ToString());
        }

        private void Tb_ort_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            validateAttribute(9, typeof(Adresse), tb_ort, tb_ort.Text, "Ort", lbl_plz_ort.Content.ToString());
        }

        private void validateAttribute(int valID, Type type, Control control, string value, string propertyName, string displayName)
        {
            lbl_error_msg.Content = "";

            ValidationContext validationContext = new ValidationContext(control);
            validationContext.DisplayName = displayName;
            List<ValidationResult> validationResults = new List<ValidationResult>();
            List<ValidationAttribute> validationAttributes = type.GetProperty(propertyName).GetCustomAttributes(false).OfType<ValidationAttribute>().ToList();

            validAttribute[valID] = Validator.TryValidateValue(value, validationContext, validationResults, validationAttributes);

            switch (validAttribute[valID])
            {
                case true:
                    bool isValidObject = true;

                    for (int i = 0; i < validAttribute.Length; i++)
                    {
                        if (!validAttribute[i])
                        {
                            isValidObject = false;
                            break;
                        }
                    }

                    switch (isValidObject)
                    {
                        case true:
                            btn_save_person.IsEnabled = true;
                            break;
                        case false:
                            btn_save_person.IsEnabled = false;
                            break;
                    }
                    break;
                case false:
                    btn_save_person.IsEnabled = false;
                    lbl_error_msg.Content = validationResults[0].ErrorMessage;
                    break;
            }
        }

        #endregion

        #region Button

        private void btn_reset_person_Click(object sender, RoutedEventArgs e)
        {
            Lv_personen_SelectionChanged(null, null);
        }

        private void btn_new_person_Click(object sender, RoutedEventArgs e)
        {
            lv_personen.SelectedIndex = -1;
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
            tb_postleitzahl.Text = "";
            tb_ort.Text = "";

            dp_geburtsdatum.Focus();
        }

        private void btn_del_person_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = lv_personen.SelectedItem as Person;
            PersonListe.Instance.Remove(selectedPerson);

            btn_new_person_Click(null, null);
        }

        private void btn_save_person_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = lv_personen.SelectedItem as Person;
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
                PersonListe.Instance.Add(newPerson);
                lv_personen.SelectedIndex = PersonListe.Instance.Count - 1;
            }
            else
            {
                Person existingPerson = PersonListe.Instance.Where(x => x.Equals(selectedPerson)).Single();
                int indexExistingPerson = PersonListe.Instance.IndexOf(existingPerson);

                PersonListe.Instance[indexExistingPerson] = newPerson;
            }
        }

        #endregion
    }
}
