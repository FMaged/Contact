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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;


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
        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            cbxCountry.SelectedIndex = 0;
            if (_Mode == enMode.AddNew)
            {
                _Contact = new ClsContact();
                return;
            }
            _Contact = ClsContact.Find(_ContactID);
            if (_Contact == null)
            {
                MessageBox.Show("This form will be closed because No Contact with ID = " + _ContactID);
                this.Close();
                return;
            }

            lblTitle.Text = "Edit Contact ID = " + _ContactID;
            lblContact_ID.Text = _ContactID.ToString();
            txbFirstName.Text = _Contact.FirstName;
            txbLastName.Text = _Contact.LastName;
            txbEmail.Text = _Contact.Email; 
            txbPhone.Text = _Contact.Phone; 
            pkrDateOfBirth.Value=_Contact.DateOfBirth;
            cbxCountry.SelectedIndex = cbxCountry.FindString(ClsCountry.Find(_Contact.CountryID).CountryName);

        }


        private void AddContactForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cbxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblContact_ID_Click(object sender, EventArgs e)
        {

        }
    }
}
