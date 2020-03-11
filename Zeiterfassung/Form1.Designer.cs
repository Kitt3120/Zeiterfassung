namespace Zeiterfassung
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxPersonManagement = new System.Windows.Forms.GroupBox();
            this.checkBoxPasswortZeigen = new System.Windows.Forms.CheckBox();
            this.buttonPersonHinzufügen = new System.Windows.Forms.Button();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelGehalt = new System.Windows.Forms.Label();
            this.textBoxGehalt = new System.Windows.Forms.TextBox();
            this.labelGeburtsdatum = new System.Windows.Forms.Label();
            this.textBoxGeburtsdatum = new System.Windows.Forms.TextBox();
            this.labelPasswort = new System.Windows.Forms.Label();
            this.textBoxPasswort = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxVorName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelVorname = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBoxTimeManagement = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonBisJetzt = new System.Windows.Forms.Button();
            this.buttonArbeitszeitHinzufügen = new System.Windows.Forms.Button();
            this.buttonDatumHeute = new System.Windows.Forms.Button();
            this.textBoxBeschreibung = new System.Windows.Forms.TextBox();
            this.labelBeschreibung = new System.Windows.Forms.Label();
            this.textBoxBis = new System.Windows.Forms.TextBox();
            this.labelBis = new System.Windows.Forms.Label();
            this.textBoxVon = new System.Windows.Forms.TextBox();
            this.labelVon = new System.Windows.Forms.Label();
            this.textBoxDatum = new System.Windows.Forms.TextBox();
            this.labelDatum = new System.Windows.Forms.Label();
            this.splitContainerManagement = new System.Windows.Forms.SplitContainer();
            this.textBoxZeitausgabe = new System.Windows.Forms.TextBox();
            this.groupBoxZeitausgabe = new System.Windows.Forms.GroupBox();
            this.checkBoxZeitausgabeAlleMonate = new System.Windows.Forms.CheckBox();
            this.comboBoxZeitausgabeMonat = new System.Windows.Forms.ComboBox();
            this.checkBoxZeitausgabeAlleMitarbeiter = new System.Windows.Forms.CheckBox();
            this.comboBoxZeitausgabeMitarbeiter = new System.Windows.Forms.ComboBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.groupBoxPersonManagement.SuspendLayout();
            this.groupBoxTimeManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerManagement)).BeginInit();
            this.splitContainerManagement.Panel1.SuspendLayout();
            this.splitContainerManagement.Panel2.SuspendLayout();
            this.splitContainerManagement.SuspendLayout();
            this.groupBoxZeitausgabe.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPersonManagement
            // 
            this.groupBoxPersonManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPersonManagement.Controls.Add(this.checkBoxPasswortZeigen);
            this.groupBoxPersonManagement.Controls.Add(this.buttonPersonHinzufügen);
            this.groupBoxPersonManagement.Controls.Add(this.comboBoxPosition);
            this.groupBoxPersonManagement.Controls.Add(this.labelPosition);
            this.groupBoxPersonManagement.Controls.Add(this.labelGehalt);
            this.groupBoxPersonManagement.Controls.Add(this.textBoxGehalt);
            this.groupBoxPersonManagement.Controls.Add(this.labelGeburtsdatum);
            this.groupBoxPersonManagement.Controls.Add(this.textBoxGeburtsdatum);
            this.groupBoxPersonManagement.Controls.Add(this.labelPasswort);
            this.groupBoxPersonManagement.Controls.Add(this.textBoxPasswort);
            this.groupBoxPersonManagement.Controls.Add(this.labelEmail);
            this.groupBoxPersonManagement.Controls.Add(this.textBoxEmail);
            this.groupBoxPersonManagement.Controls.Add(this.textBoxVorName);
            this.groupBoxPersonManagement.Controls.Add(this.textBoxName);
            this.groupBoxPersonManagement.Controls.Add(this.labelVorname);
            this.groupBoxPersonManagement.Controls.Add(this.labelName);
            this.groupBoxPersonManagement.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBoxPersonManagement.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPersonManagement.Name = "groupBoxPersonManagement";
            this.groupBoxPersonManagement.Size = new System.Drawing.Size(394, 258);
            this.groupBoxPersonManagement.TabIndex = 0;
            this.groupBoxPersonManagement.TabStop = false;
            this.groupBoxPersonManagement.Text = "Personenmanagement";
            this.groupBoxPersonManagement.Visible = false;
            // 
            // checkBoxPasswortZeigen
            // 
            this.checkBoxPasswortZeigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxPasswortZeigen.AutoSize = true;
            this.checkBoxPasswortZeigen.Location = new System.Drawing.Point(323, 99);
            this.checkBoxPasswortZeigen.Name = "checkBoxPasswortZeigen";
            this.checkBoxPasswortZeigen.Size = new System.Drawing.Size(59, 17);
            this.checkBoxPasswortZeigen.TabIndex = 5;
            this.checkBoxPasswortZeigen.Text = "Zeigen";
            this.checkBoxPasswortZeigen.UseVisualStyleBackColor = true;
            this.checkBoxPasswortZeigen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxPasswortZeigen_KeyDown);
            this.checkBoxPasswortZeigen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkBoxPasswortZeigen_KeyUp);
            this.checkBoxPasswortZeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkBoxPasswortZeigen_MouseDown);
            this.checkBoxPasswortZeigen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkBoxPasswortZeigen_MouseUp);
            // 
            // buttonPersonHinzufügen
            // 
            this.buttonPersonHinzufügen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPersonHinzufügen.Location = new System.Drawing.Point(9, 222);
            this.buttonPersonHinzufügen.Name = "buttonPersonHinzufügen";
            this.buttonPersonHinzufügen.Size = new System.Drawing.Size(167, 23);
            this.buttonPersonHinzufügen.TabIndex = 9;
            this.buttonPersonHinzufügen.Text = "Anlegen";
            this.buttonPersonHinzufügen.UseVisualStyleBackColor = true;
            this.buttonPersonHinzufügen.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Location = new System.Drawing.Point(123, 175);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(254, 21);
            this.comboBoxPosition.TabIndex = 8;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(6, 179);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(44, 13);
            this.labelPosition.TabIndex = 12;
            this.labelPosition.Text = "Position";
            // 
            // labelGehalt
            // 
            this.labelGehalt.AutoSize = true;
            this.labelGehalt.Location = new System.Drawing.Point(6, 152);
            this.labelGehalt.Name = "labelGehalt";
            this.labelGehalt.Size = new System.Drawing.Size(38, 13);
            this.labelGehalt.TabIndex = 11;
            this.labelGehalt.Text = "Gehalt";
            // 
            // textBoxGehalt
            // 
            this.textBoxGehalt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGehalt.Location = new System.Drawing.Point(123, 149);
            this.textBoxGehalt.Name = "textBoxGehalt";
            this.textBoxGehalt.Size = new System.Drawing.Size(254, 20);
            this.textBoxGehalt.TabIndex = 7;
            // 
            // labelGeburtsdatum
            // 
            this.labelGeburtsdatum.AutoSize = true;
            this.labelGeburtsdatum.Location = new System.Drawing.Point(6, 126);
            this.labelGeburtsdatum.Name = "labelGeburtsdatum";
            this.labelGeburtsdatum.Size = new System.Drawing.Size(73, 13);
            this.labelGeburtsdatum.TabIndex = 9;
            this.labelGeburtsdatum.Text = "Geburtsdatum";
            // 
            // textBoxGeburtsdatum
            // 
            this.textBoxGeburtsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGeburtsdatum.Location = new System.Drawing.Point(123, 123);
            this.textBoxGeburtsdatum.Name = "textBoxGeburtsdatum";
            this.textBoxGeburtsdatum.Size = new System.Drawing.Size(254, 20);
            this.textBoxGeburtsdatum.TabIndex = 6;
            // 
            // labelPasswort
            // 
            this.labelPasswort.AutoSize = true;
            this.labelPasswort.Location = new System.Drawing.Point(6, 100);
            this.labelPasswort.Name = "labelPasswort";
            this.labelPasswort.Size = new System.Drawing.Size(50, 13);
            this.labelPasswort.TabIndex = 7;
            this.labelPasswort.Text = "Passwort";
            // 
            // textBoxPasswort
            // 
            this.textBoxPasswort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPasswort.Location = new System.Drawing.Point(123, 97);
            this.textBoxPasswort.Name = "textBoxPasswort";
            this.textBoxPasswort.PasswordChar = '*';
            this.textBoxPasswort.Size = new System.Drawing.Size(194, 20);
            this.textBoxPasswort.TabIndex = 4;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(6, 74);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 5;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.Location = new System.Drawing.Point(123, 71);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(254, 20);
            this.textBoxEmail.TabIndex = 3;
            // 
            // textBoxVorName
            // 
            this.textBoxVorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVorName.Location = new System.Drawing.Point(123, 45);
            this.textBoxVorName.Name = "textBoxVorName";
            this.textBoxVorName.Size = new System.Drawing.Size(254, 20);
            this.textBoxVorName.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(123, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(254, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelVorname
            // 
            this.labelVorname.AutoSize = true;
            this.labelVorname.Location = new System.Drawing.Point(6, 48);
            this.labelVorname.Name = "labelVorname";
            this.labelVorname.Size = new System.Drawing.Size(49, 13);
            this.labelVorname.TabIndex = 1;
            this.labelVorname.Text = "Vorname";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // groupBoxTimeManagement
            // 
            this.groupBoxTimeManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimeManagement.Controls.Add(this.button1);
            this.groupBoxTimeManagement.Controls.Add(this.buttonBisJetzt);
            this.groupBoxTimeManagement.Controls.Add(this.buttonArbeitszeitHinzufügen);
            this.groupBoxTimeManagement.Controls.Add(this.buttonDatumHeute);
            this.groupBoxTimeManagement.Controls.Add(this.textBoxBeschreibung);
            this.groupBoxTimeManagement.Controls.Add(this.labelBeschreibung);
            this.groupBoxTimeManagement.Controls.Add(this.textBoxBis);
            this.groupBoxTimeManagement.Controls.Add(this.labelBis);
            this.groupBoxTimeManagement.Controls.Add(this.textBoxVon);
            this.groupBoxTimeManagement.Controls.Add(this.labelVon);
            this.groupBoxTimeManagement.Controls.Add(this.textBoxDatum);
            this.groupBoxTimeManagement.Controls.Add(this.labelDatum);
            this.groupBoxTimeManagement.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTimeManagement.Name = "groupBoxTimeManagement";
            this.groupBoxTimeManagement.Size = new System.Drawing.Size(373, 258);
            this.groupBoxTimeManagement.TabIndex = 1;
            this.groupBoxTimeManagement.TabStop = false;
            this.groupBoxTimeManagement.Text = "Arbeitszeitmanagement";
            this.groupBoxTimeManagement.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(308, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "08:00";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBisJetzt
            // 
            this.buttonBisJetzt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBisJetzt.Location = new System.Drawing.Point(308, 71);
            this.buttonBisJetzt.Name = "buttonBisJetzt";
            this.buttonBisJetzt.Size = new System.Drawing.Size(54, 23);
            this.buttonBisJetzt.TabIndex = 5;
            this.buttonBisJetzt.Text = "Jetzt";
            this.buttonBisJetzt.UseVisualStyleBackColor = true;
            this.buttonBisJetzt.Click += new System.EventHandler(this.buttonBisJetzt_Click);
            // 
            // buttonArbeitszeitHinzufügen
            // 
            this.buttonArbeitszeitHinzufügen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonArbeitszeitHinzufügen.Location = new System.Drawing.Point(11, 222);
            this.buttonArbeitszeitHinzufügen.Name = "buttonArbeitszeitHinzufügen";
            this.buttonArbeitszeitHinzufügen.Size = new System.Drawing.Size(167, 23);
            this.buttonArbeitszeitHinzufügen.TabIndex = 7;
            this.buttonArbeitszeitHinzufügen.Text = "Hinzufügen";
            this.buttonArbeitszeitHinzufügen.UseVisualStyleBackColor = true;
            this.buttonArbeitszeitHinzufügen.Click += new System.EventHandler(this.buttonArbeitszeitHinzufügen_Click);
            // 
            // buttonDatumHeute
            // 
            this.buttonDatumHeute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDatumHeute.Location = new System.Drawing.Point(308, 17);
            this.buttonDatumHeute.Name = "buttonDatumHeute";
            this.buttonDatumHeute.Size = new System.Drawing.Size(54, 23);
            this.buttonDatumHeute.TabIndex = 1;
            this.buttonDatumHeute.Text = "Heute";
            this.buttonDatumHeute.UseVisualStyleBackColor = true;
            this.buttonDatumHeute.Click += new System.EventHandler(this.buttonDatumHeute_Click);
            // 
            // textBoxBeschreibung
            // 
            this.textBoxBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBeschreibung.Location = new System.Drawing.Point(118, 100);
            this.textBoxBeschreibung.Multiline = true;
            this.textBoxBeschreibung.Name = "textBoxBeschreibung";
            this.textBoxBeschreibung.Size = new System.Drawing.Size(244, 92);
            this.textBoxBeschreibung.TabIndex = 6;
            // 
            // labelBeschreibung
            // 
            this.labelBeschreibung.AutoSize = true;
            this.labelBeschreibung.Location = new System.Drawing.Point(8, 103);
            this.labelBeschreibung.Name = "labelBeschreibung";
            this.labelBeschreibung.Size = new System.Drawing.Size(72, 13);
            this.labelBeschreibung.TabIndex = 6;
            this.labelBeschreibung.Text = "Beschreibung";
            // 
            // textBoxBis
            // 
            this.textBoxBis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBis.Location = new System.Drawing.Point(118, 71);
            this.textBoxBis.Name = "textBoxBis";
            this.textBoxBis.Size = new System.Drawing.Size(184, 20);
            this.textBoxBis.TabIndex = 4;
            // 
            // labelBis
            // 
            this.labelBis.AutoSize = true;
            this.labelBis.Location = new System.Drawing.Point(8, 74);
            this.labelBis.Name = "labelBis";
            this.labelBis.Size = new System.Drawing.Size(21, 13);
            this.labelBis.TabIndex = 4;
            this.labelBis.Text = "Bis";
            // 
            // textBoxVon
            // 
            this.textBoxVon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVon.Location = new System.Drawing.Point(118, 45);
            this.textBoxVon.Name = "textBoxVon";
            this.textBoxVon.Size = new System.Drawing.Size(184, 20);
            this.textBoxVon.TabIndex = 2;
            // 
            // labelVon
            // 
            this.labelVon.AutoSize = true;
            this.labelVon.Location = new System.Drawing.Point(8, 48);
            this.labelVon.Name = "labelVon";
            this.labelVon.Size = new System.Drawing.Size(26, 13);
            this.labelVon.TabIndex = 2;
            this.labelVon.Text = "Von";
            // 
            // textBoxDatum
            // 
            this.textBoxDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDatum.Location = new System.Drawing.Point(118, 19);
            this.textBoxDatum.Name = "textBoxDatum";
            this.textBoxDatum.Size = new System.Drawing.Size(184, 20);
            this.textBoxDatum.TabIndex = 0;
            // 
            // labelDatum
            // 
            this.labelDatum.AutoSize = true;
            this.labelDatum.Location = new System.Drawing.Point(8, 22);
            this.labelDatum.Name = "labelDatum";
            this.labelDatum.Size = new System.Drawing.Size(38, 13);
            this.labelDatum.TabIndex = 0;
            this.labelDatum.Text = "Datum";
            // 
            // splitContainerManagement
            // 
            this.splitContainerManagement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerManagement.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerManagement.IsSplitterFixed = true;
            this.splitContainerManagement.Location = new System.Drawing.Point(12, 12);
            this.splitContainerManagement.Name = "splitContainerManagement";
            // 
            // splitContainerManagement.Panel1
            // 
            this.splitContainerManagement.Panel1.Controls.Add(this.groupBoxPersonManagement);
            this.splitContainerManagement.Panel1MinSize = 50;
            // 
            // splitContainerManagement.Panel2
            // 
            this.splitContainerManagement.Panel2.Controls.Add(this.groupBoxTimeManagement);
            this.splitContainerManagement.Panel2MinSize = 50;
            this.splitContainerManagement.Size = new System.Drawing.Size(760, 261);
            this.splitContainerManagement.SplitterDistance = 388;
            this.splitContainerManagement.TabIndex = 0;
            // 
            // textBoxZeitausgabe
            // 
            this.textBoxZeitausgabe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxZeitausgabe.Location = new System.Drawing.Point(6, 46);
            this.textBoxZeitausgabe.Multiline = true;
            this.textBoxZeitausgabe.Name = "textBoxZeitausgabe";
            this.textBoxZeitausgabe.ReadOnly = true;
            this.textBoxZeitausgabe.Size = new System.Drawing.Size(540, 139);
            this.textBoxZeitausgabe.TabIndex = 4;
            this.textBoxZeitausgabe.TabStop = false;
            // 
            // groupBoxZeitausgabe
            // 
            this.groupBoxZeitausgabe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxZeitausgabe.Controls.Add(this.checkBoxZeitausgabeAlleMonate);
            this.groupBoxZeitausgabe.Controls.Add(this.comboBoxZeitausgabeMonat);
            this.groupBoxZeitausgabe.Controls.Add(this.checkBoxZeitausgabeAlleMitarbeiter);
            this.groupBoxZeitausgabe.Controls.Add(this.comboBoxZeitausgabeMitarbeiter);
            this.groupBoxZeitausgabe.Controls.Add(this.textBoxZeitausgabe);
            this.groupBoxZeitausgabe.Location = new System.Drawing.Point(12, 279);
            this.groupBoxZeitausgabe.Name = "groupBoxZeitausgabe";
            this.groupBoxZeitausgabe.Size = new System.Drawing.Size(760, 191);
            this.groupBoxZeitausgabe.TabIndex = 1;
            this.groupBoxZeitausgabe.TabStop = false;
            this.groupBoxZeitausgabe.Text = "Zeitausgabe";
            // 
            // checkBoxZeitausgabeAlleMonate
            // 
            this.checkBoxZeitausgabeAlleMonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxZeitausgabeAlleMonate.AutoSize = true;
            this.checkBoxZeitausgabeAlleMonate.Location = new System.Drawing.Point(552, 48);
            this.checkBoxZeitausgabeAlleMonate.Name = "checkBoxZeitausgabeAlleMonate";
            this.checkBoxZeitausgabeAlleMonate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxZeitausgabeAlleMonate.Size = new System.Drawing.Size(43, 17);
            this.checkBoxZeitausgabeAlleMonate.TabIndex = 2;
            this.checkBoxZeitausgabeAlleMonate.Text = "Alle";
            this.checkBoxZeitausgabeAlleMonate.UseVisualStyleBackColor = true;
            this.checkBoxZeitausgabeAlleMonate.CheckedChanged += new System.EventHandler(this.checkBoxZeitausgabeAlleMonate_CheckedChanged);
            // 
            // comboBoxZeitausgabeMonat
            // 
            this.comboBoxZeitausgabeMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxZeitausgabeMonat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZeitausgabeMonat.FormatString = "MMMM yyyy";
            this.comboBoxZeitausgabeMonat.FormattingEnabled = true;
            this.comboBoxZeitausgabeMonat.Location = new System.Drawing.Point(601, 46);
            this.comboBoxZeitausgabeMonat.Name = "comboBoxZeitausgabeMonat";
            this.comboBoxZeitausgabeMonat.Size = new System.Drawing.Size(153, 21);
            this.comboBoxZeitausgabeMonat.TabIndex = 3;
            this.comboBoxZeitausgabeMonat.SelectedIndexChanged += new System.EventHandler(this.comboBoxZeitausgabeMonat_SelectedIndexChanged);
            // 
            // checkBoxZeitausgabeAlleMitarbeiter
            // 
            this.checkBoxZeitausgabeAlleMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxZeitausgabeAlleMitarbeiter.AutoSize = true;
            this.checkBoxZeitausgabeAlleMitarbeiter.Location = new System.Drawing.Point(552, 21);
            this.checkBoxZeitausgabeAlleMitarbeiter.Name = "checkBoxZeitausgabeAlleMitarbeiter";
            this.checkBoxZeitausgabeAlleMitarbeiter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxZeitausgabeAlleMitarbeiter.Size = new System.Drawing.Size(43, 17);
            this.checkBoxZeitausgabeAlleMitarbeiter.TabIndex = 0;
            this.checkBoxZeitausgabeAlleMitarbeiter.Text = "Alle";
            this.checkBoxZeitausgabeAlleMitarbeiter.UseVisualStyleBackColor = true;
            this.checkBoxZeitausgabeAlleMitarbeiter.CheckedChanged += new System.EventHandler(this.checkBoxZeitausgabeAlle_CheckedChanged);
            // 
            // comboBoxZeitausgabeMitarbeiter
            // 
            this.comboBoxZeitausgabeMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxZeitausgabeMitarbeiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZeitausgabeMitarbeiter.FormattingEnabled = true;
            this.comboBoxZeitausgabeMitarbeiter.Location = new System.Drawing.Point(601, 19);
            this.comboBoxZeitausgabeMitarbeiter.Name = "comboBoxZeitausgabeMitarbeiter";
            this.comboBoxZeitausgabeMitarbeiter.Size = new System.Drawing.Size(153, 21);
            this.comboBoxZeitausgabeMitarbeiter.TabIndex = 1;
            this.comboBoxZeitausgabeMitarbeiter.SelectedIndexChanged += new System.EventHandler(this.comboBoxZeitausgabeMitarbeiter_SelectedIndexChanged);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.Location = new System.Drawing.Point(697, 476);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.groupBoxZeitausgabe);
            this.Controls.Add(this.splitContainerManagement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "Form1";
            this.Text = "Fehlzeitenerfassung";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxPersonManagement.ResumeLayout(false);
            this.groupBoxPersonManagement.PerformLayout();
            this.groupBoxTimeManagement.ResumeLayout(false);
            this.groupBoxTimeManagement.PerformLayout();
            this.splitContainerManagement.Panel1.ResumeLayout(false);
            this.splitContainerManagement.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerManagement)).EndInit();
            this.splitContainerManagement.ResumeLayout(false);
            this.groupBoxZeitausgabe.ResumeLayout(false);
            this.groupBoxZeitausgabe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxPersonManagement;
        private System.Windows.Forms.GroupBox groupBoxTimeManagement;
        private System.Windows.Forms.SplitContainer splitContainerManagement;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelVorname;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxVorName;
        private System.Windows.Forms.Label labelGehalt;
        private System.Windows.Forms.TextBox textBoxGehalt;
        private System.Windows.Forms.Label labelGeburtsdatum;
        private System.Windows.Forms.TextBox textBoxGeburtsdatum;
        private System.Windows.Forms.Label labelPasswort;
        private System.Windows.Forms.TextBox textBoxPasswort;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Button buttonPersonHinzufügen;
        private System.Windows.Forms.CheckBox checkBoxPasswortZeigen;
        private System.Windows.Forms.Label labelDatum;
        private System.Windows.Forms.TextBox textBoxDatum;
        private System.Windows.Forms.TextBox textBoxBis;
        private System.Windows.Forms.Label labelBis;
        private System.Windows.Forms.TextBox textBoxVon;
        private System.Windows.Forms.Label labelVon;
        private System.Windows.Forms.TextBox textBoxBeschreibung;
        private System.Windows.Forms.Label labelBeschreibung;
        private System.Windows.Forms.Button buttonDatumHeute;
        private System.Windows.Forms.Button buttonArbeitszeitHinzufügen;
        private System.Windows.Forms.Button buttonBisJetzt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxZeitausgabe;
        private System.Windows.Forms.GroupBox groupBoxZeitausgabe;
        private System.Windows.Forms.ComboBox comboBoxZeitausgabeMitarbeiter;
        private System.Windows.Forms.CheckBox checkBoxZeitausgabeAlleMitarbeiter;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ComboBox comboBoxZeitausgabeMonat;
        private System.Windows.Forms.CheckBox checkBoxZeitausgabeAlleMonate;
    }
}

