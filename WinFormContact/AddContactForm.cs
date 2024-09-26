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
        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            cbxCountry.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Contact";
                _Contact = new ClsContact();
                return;
            }
            _Contact = ClsContact.Find(_ContactID);
            if(_Contact == null)
            {
                MessageBox.Show("No Contact with ID = " + _ContactID);
                this.Close();
                return;
            }

            lblTitle.Text = "Edit Contact ID = " + _ContactID;
            lblContact_ID.Text = _ContactID.ToString();
            txbFirstName.Text = _Contact.FirstName;
            txbLastName.Text = _Contact.LastName;   
            txbEmail.Text = _Contact.Email;
            txbPhone.Text = _Contact.Phone;
            txbAddress.Text = _Contact.Address;
            pkrDateOfBirth.Value= _Contact.DateOfBirth;

            //this will select the country in the combobox.
            cbxCountry.SelectedIndex = cbxCountry.FindString(_Contact.CountryID.ToString());




        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddContactForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = ClsCountry.Find(cbxCountry.Text).ID;

            _Contact.FirstName=txbFirstName.Text;
            _Contact.LastName=txbLastName.Text;
            _Contact.Email=txbEmail.Text;
            _Contact.Phone=txbPhone.Text;
            _Contact.Address=txbAddress.Text;
            _Contact.DateOfBirth=pkrDateOfBirth.Value;
            _Contact.CountryID=CountryID;


            if (_Contact.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }
            _Mode=enMode.Update;
            lblTitle.Text = "Edit Contact ID = " + _Contact.ID;
            lblContact_ID.Text = _Contact.ID.ToString();




        }

        struct CountrySt
        {
            public string Item; 
            public int Value;
            public CountrySt(string Item, int Value)
            {
                 this.Item = Item;
                 this.Value = Value;
            }
        }

        private void cbxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
