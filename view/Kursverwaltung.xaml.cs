using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Universitätsverwaltung.controller;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung.view
{
    /// <summary>
    /// Interaktionslogik für Kursverwaltung.xaml
    /// </summary>
    public partial class Kursverwaltung : UserControl
    {
        private static Kursverwaltung instance;

        public static Kursverwaltung Instance => instance ?? (instance = new Kursverwaltung());

        private ValidationController validationController = null;

        public Kursverwaltung()
        {
            InitializeComponent();

            validationController = new ValidationController(new bool[3], lbl_error_msg);
        }

        #region Loaded

        private void lv_kurs_Loaded(object sender, RoutedEventArgs e)
        {
            lv_kurs.ItemsSource = KursListe.Instance;
        }

        private void tb_name_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            tb_name.Focus();
        }

        #endregion

        #region ListViewSorter

        private ListViewSorter lvKursSorter = new ListViewSorter();

        private void GridViewColumnHeaderLvKursClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;

            if (headerClicked != null)
            {
                lvKursSorter.SortHeader(headerClicked, null, lv_kurs);
            }
        }

        #endregion

        #region GotFocus

        private void tb_name_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            tb_name.SelectAll();
        }

        private void tb_beschreibung_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            tb_beschreibung.SelectAll();
        }

        private void tb_ects_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            tb_ects.SelectAll();
        }

        #endregion

        #region SelectionChanged

        private void Lv_kurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_reset.IsEnabled = false;
            btn_new.IsEnabled = true;
            btn_del.IsEnabled = true;
            btn_save.IsEnabled = false;

            if (lv_kurs.SelectedItem is Kurs selectedKurs)
            {
                tb_name.Text = selectedKurs.Name;
                tb_beschreibung.Text = selectedKurs.Beschreibung;
                tb_ects.Text = selectedKurs.ECTS.ToString();

                validationController.ResetValidAttributes(true);
            }
            else
            {
                validationController.ResetValidAttributes(false);
            }
        }

        #endregion

        #region TextChanged

        private void tb_name_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ValidateInput(e, 0, typeof(Kurs), tb_name, tb_name.Text, "Name", lbl_name.Content.ToString());
        }

        private void tb_beschreibung_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ValidateInput(e, 1, typeof(Kurs), tb_beschreibung, tb_beschreibung.Text, "Beschreibung", lbl_beschreibung.Content.ToString());
        }

        private void tb_ects_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ValidateInput(e, 2, typeof(Kurs), tb_ects, tb_ects.Text, "ECTS", lbl_ects.Content.ToString());
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
            Kurs selectedKurs = (Kurs)lv_kurs.SelectedItem;

            if (selectedKurs != null)
            {
                Kurs kurs = new Kurs(tb_name.Text, tb_beschreibung.Text, tb_ects.Text);

                return !kurs.Equals(selectedKurs);
            }
            else
            {
                return true;
            }
        }

        private void EnableResetbutton()
        {
            switch (lv_kurs.SelectedItem is Kurs
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

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            Lv_kurs_SelectionChanged(null, null);
            lbl_error_msg.Content = "";
        }

        private void btn_new_Click(object sender, RoutedEventArgs e)
        {
            lv_kurs.SelectedIndex = -1;
            btn_new.IsEnabled = false;
            btn_del.IsEnabled = false;

            tb_name.Text = "";
            tb_beschreibung.Text = "";
            tb_ects.Text = "";

            tb_name.Focus();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            Kurs selectedKurs = lv_kurs.SelectedItem as Kurs;

            StudiengangListe.Instance.Remove(selectedKurs);
            KursListe.Instance.Remove(selectedKurs);

            btn_new_Click(null, null);
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Kurs newKurs = null;

            string name = tb_name.Text;
            string beschreibung = tb_beschreibung.Text;
            string ects = tb_ects.Text;

            newKurs = new Kurs(name, beschreibung, ects);

            if (lv_kurs.SelectedItem is Kurs selectedKurs)
            {
                Kurs existingKurs = KursListe.Instance.Where(x => x.Equals(selectedKurs)).Single();
                int indexExistingKurs = KursListe.Instance.IndexOf(existingKurs);

                selectedKurs = newKurs;

                KursListe.Instance[indexExistingKurs] = newKurs;
                lv_kurs.SelectedItem = newKurs;
            }
            else if (!IsDuplicate(newKurs))
            {
                KursListe.Instance.Add(newKurs);
                lv_kurs.SelectedIndex = KursListe.Instance.Count - 1;
            }
        }

        private bool IsDuplicate(Kurs newKurs)
        {
            List<Kurs> kursResult1 = KursListe.Instance.Where(x => x.Equals(newKurs)).ToList();

            if (kursResult1.Count > 0)
            {
                MessageBox.Show("Kurs existiert bereits:" +
                    "\nName: " + kursResult1[0].Name +
                    "\nBeschreibung: " + kursResult1[0].Beschreibung +
                    "\nECTS: " + kursResult1[0].ECTS);

                btn_new.IsEnabled = true;
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
