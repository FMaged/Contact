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
        private ClsCountry(int iD,string countryName,string Code,string PhoneCode)
        {
            this.ID = iD;
            this.CountryName = countryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;
        }
        private bool _AddNewCountry(string countryName)
        {
            this.ID = ClsCountryData.addNewCountry(countryName);
            return (ID != -1);
        }
        private bool _UpdateCountry()
        {
            return ClsCountryData.updateCountry(this.ID,this.CountryName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry(this.CountryName))
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
        
        public static ClsCountry Find(int ID)
        {
            string CountryName = "";
            string Code = "";
            string PhoneCode = "";

            
            if(ClsCountryData.getCountryInfoByID(ID,ref  CountryName,ref  Code,ref PhoneCode))
            {
                return new ClsCountry(ID,CountryName,Code,PhoneCode);

            }else
            {
                return null;

            }

        }

        public static ClsCountry Find(string countryName)
        {
            int ID = -1;
            string Code = "";
            string PhoneCode = "";

            if (ClsCountryData.getCountryInfoByName(countryName, ref ID, ref Code, ref PhoneCode))
            {
                return new ClsCountry(ID, countryName, Code, PhoneCode);
            }
            else
            {
                return null;
            }

        }


    }
}
