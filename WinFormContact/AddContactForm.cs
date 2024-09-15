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
using ContactsBusinessLayer;


namespace WinFormContact
{
    public partial class AddContactForm : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _ContactID;
        ClsContact _Contact;
        public AddContactForm(int ContactID)
        {
            InitializeComponent();
            _ContactID = ContactID;
            if (ContactID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;

            }

        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountires=ClsCountry.GetAllCountries();

            foreach (DataRow row in dtCountires.Rows)
            {
                cbxCountry.Items.Add(row["CountryName"]);    

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddContactForm_Load(object sender, EventArgs e)
        {

        }

        private void cbxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
