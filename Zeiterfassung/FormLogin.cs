using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeiterfassung.Models.Person;
using Zeiterfassung.Storage;
using Zeiterfassung.Utils;

namespace Zeiterfassung
{
    public partial class FormLogin : Form
    {
        private bool _verified = false;

        private Action<Person> _successAction;

        public FormLogin(Action<Person> successAction)
        {
            _successAction = successAction;
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Array.ForEach(StorageContainer.Get<Person>().Values, person => comboBoxUser.Items.Add(person));

            if (comboBoxUser.Items.Count > 0)
                comboBoxUser.SelectedIndex = 0;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string password = textBoxPassword.Text;
            Person user = (Person)comboBoxUser.SelectedItem;
            if (string.IsNullOrWhiteSpace(password) || user == null)
                return;

            if (!HashUtils.Verify(password, user.PasswordHash))
            {
                textBoxPassword.Clear();
                MessageBox.Show("Das Passwort war ungültig!", "Ungültiges Passwort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
            }
            else
            {
                _verified = true;
                Close();
                _successAction.Invoke((Person)comboBoxUser.SelectedItem);
            }
        }

        private void RefreshButton()
        {
            buttonLogin.Enabled = (comboBoxUser.SelectedItem != null && !string.IsNullOrWhiteSpace(textBoxPassword.Text));
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_verified)
                Environment.Exit(0);
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e) => RefreshButton();

        private void textBoxPassword_TextChanged(object sender, EventArgs e) => RefreshButton();
    }
}