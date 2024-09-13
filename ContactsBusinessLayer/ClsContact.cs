using System;
using System.Data;
using System.Diagnostics.Contracts;
using ContactsAccessLayer;


namespace ContactsBusinessLayer
{
    public class ClsContact
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int CountryID { get; set; }


        public ClsContact()
        {
            ID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            DateOfBirth = DateTime.Now;
            ImagePath = "";
            CountryID = -1;
            Mode = enMode.AddNew;

        }

        private ClsContact(int iD, string firstName, string lastName, string email, string phone, string address, DateTime dateOfBirth, int countryID, string imagePath)
        {
            this.ID = iD;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.ImagePath = imagePath;
            this.CountryID = countryID;
            this.Mode = enMode.Update;

        }

        private bool _AddNewContact()
        {
            this.ID = ClsContactsDataAccess.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone, this.Address,
                                                        this.DateOfBirth, this.CountryID, this.ImagePath);
            return (this.ID != -1);
        }
        private bool _UpdateContact()
        {
            return ClsContactsDataAccess.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email, this.Phone, this.Address,
                                                        this.DateOfBirth, this.CountryID, this.ImagePath);
        }




        public static ClsContact Find(int iD)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            if (ClsContactsDataAccess.GetContactInfoById(iD, ref FirstName, ref LastName, ref Email, ref Phone, ref Address,
                ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new ClsContact(iD, FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }
        static public bool DeleteContact(int ID)
        {
            return ClsContactsDataAccess.DeleteContact(ID);
            

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {

                        return false;
                    }

                case enMode.Update:
                    if (_UpdateContact())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {

                        return false;
                    }
                default:
                    return false;
            }

        }

        public static DataTable GetAllContacts()
        {
            return ClsContactsDataAccess.GetAllContact();
        }

        public static bool IsContactExist(int ID)
        {
            return ClsContactsDataAccess.IsContactExist(ID);
        }
    }
}
