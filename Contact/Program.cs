
using System;
using System.Data;
using ContactsBusinessLayer;


namespace ContactsConslApp
{
    internal class Program
    {

        static void FindContat(int Id)
        {
            ClsContact contact = ClsContact.Find(Id);
            if (contact == null)
            {
                Console.WriteLine("Not Found");
                return;
            }
            else
            {
                Console.WriteLine("Name is: " + contact.LastName + " Id is " + contact.ID);
            }

        }
        static void AddNewContact(string FirstName, string LastName,
                    string Email, string Phone, string Address, DateTime DateOfBirth,
                    int CountryId, string ImgPath)
        {
            ClsContact contact = new ClsContact();
            contact.FirstName = FirstName;
            contact.LastName = LastName;
            contact.Email = Email;
            contact.Phone = Phone;
            contact.Address = Address;
            contact.DateOfBirth = DateOfBirth;
            contact.CountryID = CountryId;
            contact.ImagePath = ImgPath;

            if (contact.Save())
            {
                Console.WriteLine("Added!  ID=" + contact.ID);
            }
            else
            {
                Console.WriteLine("Failed!!!");
            }
        }

        static void UpdateContact(int ID, string FirstName, string LastName,
                    string Email, string Phone, string Address, DateTime DateOfBirth,
                    int CountryId, string ImgPath)
        {
            ClsContact contact = ClsContact.Find(ID);
            contact.FirstName = FirstName;
            contact.LastName = LastName;
            contact.Email = Email;
            contact.Phone = Phone;
            contact.Address = Address;
            contact.DateOfBirth = DateOfBirth;
            contact.CountryID = CountryId;
            contact.ImagePath = ImgPath;
            if (contact.Save())
            {
                Console.WriteLine("Saved!");
            }
            else
            {
                Console.WriteLine("Failed!!!");
            }

        }


        static void DeleteContact(int ID)
        {
            if (ClsContact.DeleteContact(ID))
            {
                Console.WriteLine("Deleted!");
            }
            else
            {
                Console.WriteLine("Failed!!!");
            }
        }
        static void ListContact()
        {
            DataTable dt = ClsContact.GetAllContacts();
            Console.WriteLine("DataTable");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}: {row["FirstName"]} {row["LastName"]}");
            }
        }
        static void IsContactExist(int ID)
        {
            if (ClsContact.IsContactExist(ID))
            {
                Console.WriteLine("Exist!");
            }
            else
            {
                Console.WriteLine("Not!!");
            }
        }



        static void AddNewCountry(string CountryName)
        {
            ClsCountry Country = new ClsCountry();
            Country.CountryName = CountryName;
            if (Country.Save())
            {
                Console.WriteLine("Saved!  ID="+Country.ID);
            }
            else
            {
                Console.WriteLine("Not!!!");
            }
        }
        static void ListCountries()
        {
            DataTable tb = ClsCountry.GetAllCountries();
            foreach (DataRow row in tb.Rows)
            {
                Console.WriteLine($"{row["CountryID"]}, {row["CountryName"]} ");
            }
        }
        static void IsCountryExist(string CountryName)
        {
            if (ClsCountry.IsCountryExist(CountryName))
            {
                Console.WriteLine("Exist!");
            }
            else
            {
                Console.WriteLine("Not!!");
            }
        }

        static void Main(string[] args)
        {
            //ListContact();
            //ListCountries();
            //IsContactExist(100);
            //IsCountryExist("Syria");
            
            
            //AddNewCountry("Jaban");
           // FindContat(8);
            //UpdateContact(  7,"Ali","Mah","Mom@m.de","109237315","123  samStr",
            //               new DateTime(2008,12,1,10,30,00),1,"");
            //DeleteContact(15);


            Console.ReadKey();


        }
    }
}
