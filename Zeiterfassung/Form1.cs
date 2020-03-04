using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeiterfassung.CSV;
using Zeiterfassung.IO.DataProvider;
using Zeiterfassung.IO.DataWriter;
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
            PreLoad();

            InitializeComponent();
        }

        private async void PreLoad()
        {
            await LoadPersons();
            new FormLogin(OnAuthenticated).ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Position als Auswahl zur ComboBox hinzufügen und ersten Eintrag standardmäßig auswählen
            Array.ForEach((Position[])Enum.GetValues(typeof(Position)), en => comboBoxPosition.Items.Add(en));
            if (comboBoxPosition.Items.Count > 0)
                comboBoxPosition.SelectedIndex = 0;
        }

        private void OnAuthenticated(Person person)
        {
            _user = person;
            Text = $"Fehlzeitenerfassung (Eingeloggt als {person.ToString()})";

            if (person.Position == Position.Manager)
            {
                splitContainerManagement.Panel1Collapsed = false;
                groupBoxPersonManagement.Visible = true;

                splitContainerManagement.Panel2Collapsed = false;
                groupBoxTimeManagement.Visible = true;
            }
            else
            {
                splitContainerManagement.Panel1Collapsed = true;
                groupBoxPersonManagement.Visible = false;

                splitContainerManagement.Panel2Collapsed = false;
                groupBoxTimeManagement.Visible = true;
            }
        }

        private async Task LoadPersons()
        {
            Person[] persons = CSVHandlers.CSVHandlerPerson.ParseAll(await DataProviders.FileDataProvider.ProvideAsync("Assets/Personen.csv")).ToArray();
            Storage<Person> personStorage = StorageContainer.CreateStorage<Person>("Personen"); //Potentially overwrite old storage only after successfull parsing
            Array.ForEach(persons, person => personStorage.Add(person));
        }

        private async Task SavePersons() => await DataWriters.FileDataWriter.WriteAllAsync("Assets/Personen.csv", CSVHandlers.CSVHandlerPerson.RevertAll(StorageContainer.Get<Person>().Values));

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
    }
}