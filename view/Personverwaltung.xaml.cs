using Studiengangsverwaltung.model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Studiengangsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für Personverwaltung.xaml
    /// </summary>
    public partial class Personverwaltung : UserControl
    {
        public Personverwaltung()
        {
            InitializeComponent();
        }

        private void lv_personen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Settings.Instance.ChangesApplied = false;

            btn_reset_person.IsEnabled = false;
            btn_new_person.IsEnabled = true;
            btn_del_person.IsEnabled = true;
            btn_save_person.IsEnabled = false;

            Person selectedPerson = lv_personen.SelectedItem as Person;

            if (selectedPerson != null)
            {
                cb_rolle.SelectedItem = selectedPerson.Rolle;
                tb_vorname.Text = selectedPerson.Vorname;
                tb_nachname.Text = selectedPerson.Nachname;
                tb_strasse.Text = selectedPerson.Adresse.Strasse + " " + selectedPerson.Adresse.Hausnummer;
                tb_postleitzahl.Text = selectedPerson.Adresse.Postleitzahl.ToString();
                tb_ort.Text = selectedPerson.Adresse.Ort;
                dp_geburtstag.SelectedDate = selectedPerson.Geburtsdatum;
            }
        }

        private void cb_rolle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person selectedPerson = lv_personen.SelectedItem as Person;

            if (Settings.Instance.ChangesApplied == false
                && selectedPerson != null)
            {
                if (!cb_rolle.SelectedItem.Equals(selectedPerson.Rolle))
                {
                    Settings.Instance.ChangesApplied = true;

                    btn_reset_person.IsEnabled = true;
                    btn_save_person.IsEnabled = true;
                }
            }
        }

        private void btn_reset_person_Click(object sender, RoutedEventArgs e)
        {
            lv_personen_SelectionChanged(null, null);
        }

        private void btn_new_person_Click(object sender, RoutedEventArgs e)
        {
            lv_personen.SelectedIndex = -1;
            btn_new_person.IsEnabled = false;
            btn_del_person.IsEnabled = false;

            cb_rolle.SelectedIndex = 0;
            tb_vorname.Text = "";
            tb_nachname.Text = "";
            tb_strasse.Text = "";
            tb_postleitzahl.Text = "";
            tb_ort.Text = "";
            dp_geburtstag.SelectedDate = DateTime.Now;

            tb_vorname.Focus();
        }

        private void btn_del_person_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = lv_personen.SelectedItem as Person;
            PersonListe.Instance.Remove(selectedPerson);

            btn_new_person_Click(null, null);
        }

        private void btn_save_person_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Felder für Abschluss und ECTS einfügen (auch erst ein-/ausblenden, wenn erforderlich)

            Person selectedPerson = lv_personen.SelectedItem as Person;
            Person newPerson = null;

            Rolle rolle = (Rolle)cb_rolle.SelectedItem;
            string vorname = tb_vorname.Text;
            string nachname = tb_nachname.Text;
            string[] straße_hausnr = tb_strasse.Text.Split(' ');
            Adresse adresse = new Adresse(straße_hausnr[0], straße_hausnr[1], int.Parse(tb_postleitzahl.Text), tb_ort.Text);
            DateTime geburtstag = dp_geburtstag.SelectedDate.Value;
            Abschluss abschluss = null;
            int matrikelnummer = 1;
            int ects = 0;

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

            if (selectedPerson.Equals(null))
            {
                PersonListe.Instance.Add(newPerson);
            }
            else
            {
                Person existingPerson = PersonListe.Instance.Where(x => x.Equals(selectedPerson)).Single();
                int indexExistingPerson = PersonListe.Instance.IndexOf(existingPerson);

                PersonListe.Instance[indexExistingPerson] = newPerson;
            }
        }
    }
}
