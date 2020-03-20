using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeiterfassung.CSV;
using Zeiterfassung.IO.DataProvider;
using Zeiterfassung.IO.DataWriter;
using Zeiterfassung.Models.Arbeitszeit;
using Zeiterfassung.Models.Person;
using Zeiterfassung.Storage;
using Zeiterfassung.Utils;

namespace Zeiterfassung
{
    public partial class FormMain : Form
    {
        private Person _user;

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Vorbereitungen beim Laden der Form.
        /// Öffnet auch das Login-Fenster. OnAuthenticated() wird als Callback benutzt.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            HideComponents(); //Alle Komponenten verstecken, bevor sich ein Benutzer eingeloggt hat

            await LoadPersons(); //Personen aus Datei auslesen
            new FormLogin(OnAuthenticated).ShowDialog(this); //Login-Fenster anzeigen

            //Positionen dynamisch als Auswahl zur ComboBox hinzufügen und ersten Eintrag standardmäßig auswählen.
            //Somit muss kein Code angepasst werden, wenn man eine Position zum Enum hinzufügt.
            Array.ForEach((Position[])Enum.GetValues(typeof(Position)), en => comboBoxPosition.Items.Add(en));
            if (comboBoxPosition.Items.Count > 0)
                comboBoxPosition.SelectedIndex = 0;
        }

        /// <summary>
        /// Wird als Callback benutzt, wenn der Nutzer sich angemeldet hat
        /// </summary>
        /// <param name="person">Die Person, die sich eingeloggt hat</param>
        private void OnAuthenticated(Person person)
        {
            _user = person;
            Text = $"Fehlzeitenerfassung (Eingeloggt als {_user.ToString()})";

            ShowComponents(); //Komponenten wieder anzeigen

            //Einige Komponenten aktualisieren
            RenewZeitausgabeComboBoxMitarbeiter();
            RenewZeitausgabeComboBoxMonat();
            RefreshZeitausgabeBeschreibung();

            //Anhand der Position des Benutzers bestimmte Bereiche des UI verstecken / anzeigen
            switch (_user.Position)
            {
                case Position.Mitarbeiter:
                    splitContainerManagement.Panel1Collapsed = true;
                    groupBoxPersonManagement.Visible = false;

                    splitContainerManagement.Panel2Collapsed = false;
                    groupBoxTimeManagement.Visible = true;
                    break;

                case Position.Manager:
                    splitContainerManagement.Panel1Collapsed = false;
                    groupBoxPersonManagement.Visible = true;

                    splitContainerManagement.Panel2Collapsed = false;
                    groupBoxTimeManagement.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Versteckt alle Komponenten der Form
        /// </summary>
        private void HideComponents()
        {
            foreach (var control in Controls)
                ((Control)control).Visible = false;
        }

        /// <summary>
        /// Zeigt alle Komponenten der Form
        /// </summary>
        private void ShowComponents()
        {
            foreach (var control in Controls)
                if (control is Control)
                    ((Control)control).Visible = true;
        }

        /// <summary>
        /// Ließt Personendaten aus der Personen.csv-Datei aus und konvertiert diese in Personen-Objekte.
        /// Es wird ein Storage<Person> im StorageContainer mit dem Schlüssel "Personen" angelegt, in denen die Personen zur Verfügung stehen.
        /// </summary>
        private async Task LoadPersons()
        {
            Person[] persons = CSVHandlers.CSVHandlerPerson.ParseAll(await DataProviders.FileDataProvider.ProvideAsync("Assets/Personen.csv")).ToArray();
            Storage<Person> personStorage = StorageContainer.CreateStorage<Person>("Personen"); //Beim mehrfachen Aufrufen von LoadPersons() wird der alte Storage verworfen. Die Rückgabe ist also immer ein neuer, leerer Storage.
            Array.ForEach(persons, person => personStorage.Add(person));
        }

        /// <summary>
        /// Schreibt die Daten der Personen aus dem Storage<Person> des StorageContainers in die Personen.csv-Datei.
        /// </summary>
        private async Task SavePersons() => await DataWriters.FileDataWriter.WriteAllAsync("Assets/Personen.csv", CSVHandlers.CSVHandlerPerson.RevertAll(StorageContainer.Get<Person>().Values));

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            HideComponents();
            _user = null;
            new FormLogin(OnAuthenticated).ShowDialog(this);
        }

        //Person Management

        /// <summary>
        /// Fügt, falls alle Werte korrekt, eine neue Person hinzu
        /// </summary>
        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            string vorname, name, email, passwort;
            double gehalt;
            DateTime geburtsdatum;
            Position position;

            vorname = textBoxName.Text;
            if (string.IsNullOrWhiteSpace(vorname))
            {
                MessageBox.Show("Bitte das Feld \"Name\" ausfüllen!", "Fehlende Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            name = textBoxVorName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Bitte das Feld \"Vorname\" ausfüllen!", "Fehlende Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            email = textBoxEmail.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Bitte das Feld \"Email\" ausfüllen!", "Fehlende Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            passwort = textBoxPasswort.Text;
            if (string.IsNullOrWhiteSpace(passwort))
            {
                MessageBox.Show("Bitte das Feld \"Passwort\" ausfüllen!", "Fehlende Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!double.TryParse(textBoxGehalt.Text, out gehalt))
            {
                MessageBox.Show("Bitte das Feld \"Gehalt\" korrekt ausfüllen!", "Fehlerhafte Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!DateTime.TryParse(textBoxGeburtsdatum.Text, out geburtsdatum))
            {
                MessageBox.Show("Bitte das Feld \"Geburtsdatum\" korrekt ausfüllen!", "Fehlerhafte Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (comboBoxPosition.SelectedItem == null)
            {
                MessageBox.Show($"Bitte eine der {Enum.GetValues(typeof(Position)).Length} möglichen Positionen auswählen!", "Fehlerhafte Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position = (Position)comboBoxPosition.SelectedItem;

            if (StorageContainer.Get<Person>().Values.Any(person => person.Name == vorname && person.Vorname == name))
            {
                MessageBox.Show("Eine Person mit diesem Namen existiert bereits!", "Halt Stop!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StorageContainer.Get<Person>().Add(new Person(vorname, name, position, geburtsdatum, email, HashUtils.GenerateHash(passwort), gehalt));
            await SavePersons();
            RenewZeitausgabeComboBoxMitarbeiter();
            MessageBox.Show("Person hinzugefügt!", "Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBoxPasswortZeigen_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPasswort.PasswordChar = '\0';
            checkBoxPasswortZeigen.Checked = true;
        }

        private void checkBoxPasswortZeigen_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPasswort.PasswordChar = '*';
            checkBoxPasswortZeigen.Checked = false;
        }

        private void checkBoxPasswortZeigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                e.Handled = false;
                textBoxPasswort.PasswordChar = '\0';
                checkBoxPasswortZeigen.Checked = true;
            }
        }

        private void checkBoxPasswortZeigen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                e.Handled = false;
                textBoxPasswort.PasswordChar = '*';
                checkBoxPasswortZeigen.Checked = false;
            }
        }

        //Time Management

        /// <summary>
        /// Fügt, falls alle Werte korrekt, einen Arbeitszeit-Eintrag zum eingeloggten Benutzer hinzu
        /// </summary>
        private async void buttonArbeitszeitHinzufügen_Click(object sender, EventArgs e)
        {
            DateTime datum, anfang, ende;
            string beschreibung;

            if (!DateTime.TryParse(textBoxDatum.Text, out datum))
            {
                MessageBox.Show("Bitte das Feld \"Datum\" korrekt ausfüllen!", "Fehlerhafte Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxVon.Text) || !DateTime.TryParse($"{datum.ToString("dd.MM.yyyy")} {textBoxVon.Text}", out anfang))
            {
                MessageBox.Show("Bitte das Feld \"Von\" korrekt ausfüllen!", "Fehlerhafte Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxBis.Text) || !DateTime.TryParse($"{datum.ToString("dd.MM.yyyy")} {textBoxBis.Text}", out ende))
            {
                MessageBox.Show("Bitte das Feld \"Bis\" korrekt ausfüllen!", "Fehlerhafte Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxBeschreibung.Text))
            {
                MessageBox.Show("Bitte das Feld \"Beschreibung\" ausfüllen!", "Fehlende Angabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            beschreibung = textBoxBeschreibung.Text;

            if (anfang.Ticks - ende.Ticks > 0)
            {
                MessageBox.Show("Ihre Arbeitszeit kann nicht enden, bevor sie gestartet hat.", "Fehlerhafte Angabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.AddArbeitszeit(datum, anfang, ende, beschreibung);
            await SavePersons();
            RenewZeitausgabeComboBoxMonat();
            RefreshZeitausgabeBeschreibung();
            MessageBox.Show("Arbeitszeit hinzugefügt!", "Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDatumHeute_Click(object sender, EventArgs e) => textBoxDatum.Text = DateTime.Now.ToString("dd.MM.yyyy");

        private void button1_Click(object sender, EventArgs e) => textBoxVon.Text = "08:00:00";

        private void buttonBisJetzt_Click(object sender, EventArgs e) => textBoxBis.Text = DateTime.Now.ToString("HH:mm:ss");

        //Zeitausgabe

        /// <summary>
        /// Erneuert die Einträge in der Mitarbeiter-Combobox.
        /// </summary>
        private void RenewZeitausgabeComboBoxMitarbeiter()
        {
            comboBoxZeitausgabeMitarbeiter.Items.Clear();

            switch (_user.Position)
            {
                case Position.Mitarbeiter:
                    comboBoxZeitausgabeMitarbeiter.Visible = false;

                    checkBoxZeitausgabeAlleMitarbeiter.Checked = false;
                    checkBoxZeitausgabeAlleMitarbeiter.Visible = false;
                    break;

                case Position.Manager:
                    int index = -1;
                    if (comboBoxZeitausgabeMitarbeiter.SelectedItem != null)
                        index = comboBoxZeitausgabeMitarbeiter.SelectedIndex;

                    comboBoxZeitausgabeMitarbeiter.Items.Add(_user);
                    comboBoxZeitausgabeMitarbeiter.Items.AddRange(StorageContainer.Get<Person>().Values.Where(person => person.Position == Position.Mitarbeiter).ToArray());

                    if (index != -1 && comboBoxZeitausgabeMitarbeiter.Items.Count > index)
                        comboBoxZeitausgabeMitarbeiter.SelectedIndex = index;
                    else if (comboBoxZeitausgabeMitarbeiter.Items.Count > 0)
                        comboBoxZeitausgabeMitarbeiter.SelectedIndex = 0;

                    comboBoxZeitausgabeMitarbeiter.Visible = true;
                    checkBoxZeitausgabeAlleMitarbeiter.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Erneuert die Einträge in der Monat-Combobox.
        /// Anhand einer LINQ-Abfrage werden alle entsprechenden Monate bestimmt.
        /// </summary>
        private void RenewZeitausgabeComboBoxMonat()
        {
            Person person = _user;
            if (_user.Position == Position.Manager)
                person = (Person)comboBoxZeitausgabeMitarbeiter.SelectedItem;

            if (person == null)
                return;

            DateTime[] dates = StorageContainer.Get<Person>().Values
                                                             .Where(p => checkBoxZeitausgabeAlleMitarbeiter.Checked || p == person)
                                                             .SelectMany(p => p.Arbeitszeiten).Select(arbeitszeit => arbeitszeit.Datum)
                                                             .Select(arbeitszeit => Convert.ToDateTime(arbeitszeit.ToString("MM.yyyy")))
                                                             .Distinct()
                                                             .OrderBy(date => date.Year)
                                                             .ThenBy(date => date.Month)
                                                             .ToArray();

            comboBoxZeitausgabeMonat.Items.Clear();
            Array.ForEach(dates, date => comboBoxZeitausgabeMonat.Items.Add(date));

            if (comboBoxZeitausgabeMonat.Items.Count > 0)
                comboBoxZeitausgabeMonat.SelectedIndex = 0;
        }

        /// <summary>
        /// Erneuert die Ausgabe in der Zeitausgabe-Textbox.
        /// Anhand von LINQ-Abfragen werden alle entsprechenden Arbeitszeiten bestimmt.
        /// </summary>
        private void RefreshZeitausgabeBeschreibung()
        {
            textBoxZeitausgabe.Clear();

            if (comboBoxZeitausgabeMonat.SelectedItem == null && !checkBoxZeitausgabeAlleMonate.Checked)
                return;

            Person[] personen; //Array, welcher nachher alle zu berücksichtigenden Personen enthält

            if (checkBoxZeitausgabeAlleMitarbeiter.Checked) //Ist die Checkbox für alle Mitarbeiter aktiviert, werden alle Mitarbeiter (Manager ausgeschlossen) berücksichtigt.
            {
                List<Person> personenTmp = StorageContainer.Get<Person>().Values
                                                                         .Where(person => person.Position == Position.Mitarbeiter)
                                                                         .ToList();
                personenTmp.Add(_user);
                personen = personenTmp.ToArray();
            }
            else //Ansonsten wird nur die ausgewählte Person berücksichtigt
            {
                Person person = _user;
                if (_user.Position == Position.Manager)
                    person = (Person)comboBoxZeitausgabeMitarbeiter.SelectedItem;

                if (person == null)
                    return;

                personen = new Person[] { person };
            }

            Dictionary<Person, Arbeitszeit[]> arbeitszeiten = new Dictionary<Person, Arbeitszeit[]>();

            //Nun werden die Arbeitszeiten von allen zu berücksichtigenden Personen sortiert gesammelt.
            //Hierbei wird berücksichtigt, welcher Monat gewollt ist, oder ob alle Monate berücksichtigt werden sollen. (Siehe .Where)
            foreach (Person person in personen)
                arbeitszeiten.Add(person, person.Arbeitszeiten
                    .Where(arbeitszeit => checkBoxZeitausgabeAlleMonate.Checked || arbeitszeit.Datum.Month == ((DateTime)comboBoxZeitausgabeMonat.SelectedItem).Month)
                    .OrderBy(arbeitszeit => arbeitszeit.Datum.Year)
                    .ThenBy(arbeitszeit => arbeitszeit.Datum.Month)
                    .ThenBy(arbeitszeit => arbeitszeit.Datum.Day)
                    .ThenBy(arbeitszeit => arbeitszeit.Anfang)
                    .ThenBy(arbeitszeit => arbeitszeit.Zeitspanne.Ticks)
                    .ToArray());

            //Anschließend werden die Arbeitszeiten der Personen ausgegeben.
            //Hierbei gibt es unterschiedliche Formate:
            // - eine detaillierte Ausgabe, wenn es sich um eine Person handelt
            // - eine zusammenfassende Ausgabe, wenn es sich um mehrere Personen handelt
            if (personen.Length == 1)
            {
                Person person = personen[0];
                Arbeitszeit[] personenArbeitszeiten = arbeitszeiten[person];
                textBoxZeitausgabe.Text = $"Arbeitszeiten von {person.ToString()}{Environment.NewLine}{Environment.NewLine}";

                if (personenArbeitszeiten.Length == 0)
                    textBoxZeitausgabe.Text += $"Keine{Environment.NewLine}";
                else
                    foreach (Arbeitszeit arbeitszeit in personenArbeitszeiten)
                        textBoxZeitausgabe.Text += $"{arbeitszeit.Datum.Day}. {arbeitszeit.Datum.ToString("MMMM")} {arbeitszeit.Datum.Year} - {arbeitszeit.Zeitspanne.TotalHours.ToString("#.##")} Std. von {arbeitszeit.Anfang.ToString("HH:mm:ss")} bis {arbeitszeit.Ende.ToString("HH:mm:ss")}: {arbeitszeit.Beschreibung}{Environment.NewLine}";

                textBoxZeitausgabe.Text += $"{Environment.NewLine}Gesamt: {(personenArbeitszeiten.Length == 0 ? "0,00" : personenArbeitszeiten.Sum(arbeitszeit => arbeitszeit.Zeitspanne.TotalHours).ToString("#.##"))} Std.";
            }
            else
            {
                foreach (Person person in personen)
                    textBoxZeitausgabe.Text += $"{person.ToString()} Gesamt: {(arbeitszeiten[person].Length == 0 ? "0,00" : arbeitszeiten[person].Sum(arbeitszeit => arbeitszeit.Zeitspanne.TotalHours).ToString("#.##"))} Std.{Environment.NewLine}";
                textBoxZeitausgabe.Text += $"{Environment.NewLine}Gesamt: {(personen.SelectMany(person => person.Arbeitszeiten).ToArray().Length == 0 ? "0,00" : personen.Sum(person => arbeitszeiten[person].Sum(arbeitszeit => arbeitszeit.Zeitspanne.TotalHours)).ToString("#.##"))} Std.";
            }
        }

        private void comboBoxZeitausgabeMitarbeiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenewZeitausgabeComboBoxMonat();
            RefreshZeitausgabeBeschreibung();
        }

        private void comboBoxZeitausgabeMonat_SelectedIndexChanged(object sender, EventArgs e) => RefreshZeitausgabeBeschreibung();

        private void checkBoxZeitausgabeAlle_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxZeitausgabeMitarbeiter.Enabled = !checkBoxZeitausgabeAlleMitarbeiter.Checked;
            RenewZeitausgabeComboBoxMonat();
            RefreshZeitausgabeBeschreibung();
        }

        private void checkBoxZeitausgabeAlleMonate_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxZeitausgabeMonat.Enabled = !checkBoxZeitausgabeAlleMonate.Checked;
            RefreshZeitausgabeBeschreibung();
        }
    }
}