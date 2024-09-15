using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WinFormContact
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btShowContacts_Click(object sender, EventArgs e)
        {

            ShowContactsForm ShowContacts =new ShowContactsForm();
            ShowContacts.Show();

        }

        private void btAddContact_Click(object sender, EventArgs e)
        {
            AddContactForm AddContactForm=new AddContactForm(-1);
            AddContactForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
