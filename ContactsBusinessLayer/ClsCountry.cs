using System;
using System.Data;
using ContactsAccessLayer;

namespace ContactsBusinessLayer
{
    public class ClsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string Code { set; get; }
        public string PhoneCode { set; get; }

        public ClsCountry()
        {
            ID = -1;
            CountryName = "";
            Mode = enMode.AddNew;

        }
        private ClsCountry(int iD,string countryName, string Code, string PhoneCode)
        {
            ID = iD;
            CountryName = countryName;
        }
        private bool _AddNewCountry()
        {
            this.ID = ClsCountryData.addNewCountry(this.CountryName,this.Code,this.PhoneCode);
            return (ID != -1);
        }
        private bool _UpdateCountry()
        {
            return ClsCountryData.updateCountry(this.ID,this.CountryName,this.Code,this.PhoneCode);
        }
        public static ClsCountry Find(int ID)
        {

            string CountryName = "";
            string Code = "";
            string PhoneCode = "";


            int CountryID = -1;

            if (ClsCountryData.getCountryInfoByID(ID, ref CountryName, ref Code, ref PhoneCode))

                return new ClsCountry(ID, CountryName, Code, PhoneCode);
            else
                return null;

        }

        public static ClsCountry Find(string CountryName)
        {

            int ID = -1;
            string Code = "";
            string PhoneCode = "";


            if (ClsCountryData.getCountryInfoByName(CountryName, ref ID, ref Code, ref PhoneCode))

                return new ClsCountry(ID, CountryName, Code, PhoneCode);
            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;

                    }
                case enMode.Update:
                   if(_UpdateCountry())
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                default: return false;

            }
                    

        }
        
        public static DataTable GetAllCountries()
        {
            return ClsCountryData.GetAllCountries();
        }

        public static bool IsCountryExist(string contactName)
        {
            return ClsCountryData.IsCountryExist(contactName);
        }
    }
}
