using ContactsBusinessLayer;
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
    public partial class ShowContactsForm : Form
    {
        public ShowContactsForm()
        {
            InitializeComponent();
        }

        private void _RefreshContactList()
        {
            dgvAllContacts.DataSource=ClsContact.GetAllContacts();
        }

        private void ShowContactsForm_Load(object sender, EventArgs e)
        {
            _RefreshContactList();
        }



        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContactForm addContactForm = new AddContactForm((int) dgvAllContacts.CurrentRow.Cells[0].Value);
            addContactForm.ShowDialog();
            _RefreshContactList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
