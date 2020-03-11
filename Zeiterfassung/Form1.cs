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
    public partial class Form1 : Form
    {
        private Person _user;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            HideComponents();

            await LoadPersons();
            new FormLogin(OnAuthenticated).ShowDialog(this);

            //Positionen dynamisch als Auswahl zur ComboBox hinzufügen und ersten Eintrag standardmäßig auswählen
            Array.ForEach((Position[])Enum.GetValues(typeof(Position)), en => comboBoxPosition.Items.Add(en));
            if (comboBoxPosition.Items.Count > 0)
                comboBoxPosition.SelectedIndex = 0;
        }

        private void OnAuthenticated(Person person)
        {
            _user = person;
            Text = $"Fehlzeitenerfassung (Eingeloggt als {_user.ToString()})";

            ShowComponents();

            RenewZeitausgabeComboBoxMitarbeiter();
            RenewZeitausgabeComboBoxMonat();
            RefreshZeitausgabeBeschreibung();

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

        private async Task LoadPersons()
        {
            Person[] persons = CSVHandlers.CSVHandlerPerson.ParseAll(await DataProviders.FileDataProvider.ProvideAsync("Assets/Personen.csv")).ToArray();
            Storage<Person> personStorage = StorageContainer.CreateStorage<Person>("Personen"); //Potentially overwrite old storage only after successfull parsing
            Array.ForEach(persons, person => personStorage.Add(person));
        }

        private async Task SavePersons() => await DataWriters.FileDataWriter.WriteAllAsync("Assets/Personen.csv", CSVHandlers.CSVHandlerPerson.RevertAll(StorageContainer.Get<Person>().Values));

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            HideComponents();
            _user = null;
            new FormLogin(OnAuthenticated).ShowDialog(this);
        }

        private void HideComponents()
        {
            foreach (var control in Controls)
                ((Control)control).Visible = false;
        }

        private void ShowComponents()
        {
            foreach (var control in Controls)
                if (control is Control)
                    ((Control)control).Visible = true;
        }

        //Person Management

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

        //Time Management

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

        private void RenewZeitausgabeComboBoxMonat()
        {
            Person person = _user;
            if (_user.Position == Position.Manager)
                person = (Person)comboBoxZeitausgabeMitarbeiter.SelectedItem;

            if (person == null)
                return;

            DateTime[] dates = StorageContainer.Get<Person>().Values.Where(p => checkBoxZeitausgabeAlleMitarbeiter.Checked || p == person).SelectMany(p => p.Arbeitszeiten).Select(arbeitszeit => arbeitszeit.Datum).Select(arbeitszeit => Convert.ToDateTime(arbeitszeit.ToString("MM.yyyy"))).Distinct().OrderBy(date => date.Year).ThenBy(date => date.Month).ToArray();

            comboBoxZeitausgabeMonat.Items.Clear();
            Array.ForEach(dates, date => comboBoxZeitausgabeMonat.Items.Add(date));

            if (comboBoxZeitausgabeMonat.Items.Count > 0)
                comboBoxZeitausgabeMonat.SelectedIndex = 0;
        }

        private void RefreshZeitausgabeBeschreibung()
        {
            textBoxZeitausgabe.Clear();

            if (comboBoxZeitausgabeMonat.SelectedItem == null && !checkBoxZeitausgabeAlleMonate.Checked)
                return;

            Person[] personen;

            if (checkBoxZeitausgabeAlleMitarbeiter.Checked)
            {
                List<Person> personenTmp = StorageContainer.Get<Person>().Values.Where(person => person.Position == Position.Mitarbeiter).ToList();
                personenTmp.Add(_user);
                personen = personenTmp.ToArray();
            }
            else
            {
                Person person = _user;
                if (_user.Position == Position.Manager)
                    person = (Person)comboBoxZeitausgabeMitarbeiter.SelectedItem;

                if (person == null)
                    return;

                personen = new Person[] { person };
            }

            Dictionary<Person, Arbeitszeit[]> arbeitszeiten = new Dictionary<Person, Arbeitszeit[]>();

            foreach (Person person in personen)
                arbeitszeiten.Add(person, person.Arbeitszeiten
                    .Where(arbeitszeit => checkBoxZeitausgabeAlleMonate.Checked || arbeitszeit.Datum.Month == ((DateTime)comboBoxZeitausgabeMonat.SelectedItem).Month)
                    .OrderBy(arbeitszeit => arbeitszeit.Datum.Year)
                    .ThenBy(arbeitszeit => arbeitszeit.Datum.Month)
                    .ThenBy(arbeitszeit => arbeitszeit.Datum.Day)
                    .ThenBy(arbeitszeit => arbeitszeit.Anfang)
                    .ThenBy(arbeitszeit => arbeitszeit.Zeitspanne.Ticks)
                    .ToArray());

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

                textBoxZeitausgabe.Text += $"{Environment.NewLine}Gesamt: {personenArbeitszeiten.Sum(arbeitszeit => arbeitszeit.Zeitspanne.TotalHours).ToString("#.##")} Std.";
            }
            else
            {
                foreach (Person person in personen)
                    textBoxZeitausgabe.Text += $"{person.ToString()} Gesamt: {(arbeitszeiten[person].Length == 0 ? "0,00" : arbeitszeiten[person].Sum(arbeitszeit => arbeitszeit.Zeitspanne.TotalHours).ToString("#.##"))} Std.{Environment.NewLine}";
                textBoxZeitausgabe.Text += $"{Environment.NewLine}Gesamt: {personen.Sum(person => arbeitszeiten[person].Sum(arbeitszeit => arbeitszeit.Zeitspanne.TotalHours)).ToString("#.##")} Std.";
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