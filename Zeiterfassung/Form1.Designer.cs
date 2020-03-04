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
            this.groupBoxPersonManagement = new System.Windows.Forms.GroupBox();
            this.checkBoxPasswortZeigen = new System.Windows.Forms.CheckBox();
            this.buttonAdd = new System.Windows.Forms.Button();
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
            this.splitContainerManagement = new System.Windows.Forms.SplitContainer();
            this.groupBoxPersonManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerManagement)).BeginInit();
            this.splitContainerManagement.Panel1.SuspendLayout();
            this.splitContainerManagement.Panel2.SuspendLayout();
            this.splitContainerManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPersonManagement
            // 
            this.groupBoxPersonManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPersonManagement.Controls.Add(this.checkBoxPasswortZeigen);
            this.groupBoxPersonManagement.Controls.Add(this.buttonAdd);
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
            this.checkBoxPasswortZeigen.TabIndex = 15;
            this.checkBoxPasswortZeigen.Text = "Zeigen";
            this.checkBoxPasswortZeigen.UseVisualStyleBackColor = true;
            this.checkBoxPasswortZeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkBoxPasswortZeigen_MouseDown);
            this.checkBoxPasswortZeigen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkBoxPasswortZeigen_MouseUp);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(6, 222);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(167, 23);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Anlegen";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
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
            this.comboBoxPosition.TabIndex = 13;
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
            this.textBoxGehalt.TabIndex = 10;
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
            this.textBoxGeburtsdatum.TabIndex = 8;
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
            this.textBoxPasswort.TabIndex = 6;
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
            this.textBoxEmail.TabIndex = 4;
            // 
            // textBoxVorName
            // 
            this.textBoxVorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVorName.Location = new System.Drawing.Point(123, 45);
            this.textBoxVorName.Name = "textBoxVorName";
            this.textBoxVorName.Size = new System.Drawing.Size(254, 20);
            this.textBoxVorName.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(123, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(254, 20);
            this.textBoxName.TabIndex = 2;
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
            this.groupBoxTimeManagement.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTimeManagement.Name = "groupBoxTimeManagement";
            this.groupBoxTimeManagement.Size = new System.Drawing.Size(373, 258);
            this.groupBoxTimeManagement.TabIndex = 1;
            this.groupBoxTimeManagement.TabStop = false;
            this.groupBoxTimeManagement.Text = "Arbeitszeitmanagement";
            this.groupBoxTimeManagement.Visible = false;
            // 
            // splitContainerManagement
            // 
            this.splitContainerManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.splitContainerManagement.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.splitContainerManagement);
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "Form1";
            this.Text = "Fehlzeitenerfassung";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxPersonManagement.ResumeLayout(false);
            this.groupBoxPersonManagement.PerformLayout();
            this.splitContainerManagement.Panel1.ResumeLayout(false);
            this.splitContainerManagement.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerManagement)).EndInit();
            this.splitContainerManagement.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.CheckBox checkBoxPasswortZeigen;
    }
}

