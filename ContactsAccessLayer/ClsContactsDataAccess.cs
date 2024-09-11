using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace ContactsAccessLayer
{
    public class ClsContactsDataAccess
    {
        public static bool GetContactInfoById(int Id, ref string FirstName, ref string LastName,
                    ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth,
                    ref int CountryId, ref string ImgPath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = "SELECT * FROM Contacts WHERE ContactID=@ContactId";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"ContactId", Id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryId = (int)reader["CountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImgPath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImgPath = null; // or assign a default value, if needed
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }
                reader.Close();


            }

            catch (Exception ex)
            {

                isFound = false;
            }
            finally
            {
                connection.Close();


            }
            return isFound;


        }

        public static int AddNewContact(string FirstName, string LastName,
                    string Email, string Phone, string Address, DateTime DateOfBirth,
                    int CountryId, string ImgPath)
        {
            int ContactID = -1;
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = "INSERT INTO Contacts(FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath)" +
                            "VALUES(@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath)" +
                            "SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryId", CountryId);
            if (ImgPath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImgPath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ContactID = insertedID;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return -2;
            }
            finally
            {
                connection.Close();
            }
            return ContactID;
        }


        public static bool UpdateContact(int ID, string FirstName, string LastName,
                    string Email, string Phone, string Address, DateTime DateOfBirth,
                    int CountryId, string ImgPath)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = @"UPDATE Contacts
                            SET FirstName=@FirstName,
                                LastName=@LastName,
                                Email=@Email,
                                Phone=@Phone,
                                Address=@Address,
                                DateOfBirth=@DateOfBirth,
                                CountryID=@CountryID,
                                ImagePath=@ImagePath
                                WHERE ContactID=@ContactID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryId", CountryId);
            command.Parameters.AddWithValue("@ContactID", ID);
            if (ImgPath == "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImgPath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowAffected > 0);
        }

        public static bool DeleteContact(int ID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = @"   DELETE Contacts
                                WHERE ContactID=@ContactID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);
            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowAffected > 0);

        }


        public static DataTable GetAllContact()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = "SELECT * FROM Contacts";
            SqlCommand cmd = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public static bool IsContactExist(int ContactId)
        {
            bool IsFound=false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString) ;
            string Query = "SELECT Found=1 FROM Contacts WHERE ContactID=@ContactID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactId);
            try
            {
                connection.Open();
                IsFound = command.ExecuteScalar() != null ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

    }
}
