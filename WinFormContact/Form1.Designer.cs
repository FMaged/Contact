namespace WinFormContact
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
            this.btShowContacts = new System.Windows.Forms.Button();
            this.btAddContact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btShowContacts
            // 
            this.btShowContacts.Location = new System.Drawing.Point(80, 37);
            this.btShowContacts.Name = "btShowContacts";
            this.btShowContacts.Size = new System.Drawing.Size(182, 60);
            this.btShowContacts.TabIndex = 0;
            this.btShowContacts.Text = "Show Contacts";
            this.btShowContacts.UseVisualStyleBackColor = true;
            this.btShowContacts.Click += new System.EventHandler(this.btShowContacts_Click);
            // 
            // btAddContact
            // 
            this.btAddContact.Location = new System.Drawing.Point(306, 37);
            this.btAddContact.Name = "btAddContact";
            this.btAddContact.Size = new System.Drawing.Size(182, 60);
            this.btAddContact.TabIndex = 1;
            this.btAddContact.Text = "Add Contact";
            this.btAddContact.UseVisualStyleBackColor = true;
            this.btAddContact.Click += new System.EventHandler(this.btAddContact_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 544);
            this.Controls.Add(this.btAddContact);
            this.Controls.Add(this.btShowContacts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btShowContacts;
        private System.Windows.Forms.Button btAddContact;
    }
}

