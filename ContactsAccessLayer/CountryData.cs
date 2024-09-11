using System;
using System.Data;
using System.Data.SqlClient;


namespace ContactsAccessLayer
{
    public class ClsCountryData
    {
        public static bool getCountryInfoByID(int Id, ref string CountryName)
        {
            bool isFound = false;

            SqlConnection connection1 = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryID=@CountryID";
            SqlCommand command = new SqlCommand(Query, connection1);
            command.Parameters.AddWithValue("@CountryID", Id);
            try
            {
                connection1.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryName = (string)reader["CountryName"];

                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection1.Close();
            }
            return isFound;
        }

        public static bool getCountryInfoByName(string CountryName, ref int Id)
        {
            bool isFound = false;

            SqlConnection connection1 = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryName=@CountryName";
            SqlCommand command = new SqlCommand(Query, connection1);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection1.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    Id = (int)reader["CountryID"];

                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection1.Close();
            }
            return isFound;





        }

        public static int addNewCountry(string CountryName)
        {
            int CountryId = -1;
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = @"INSERT INTO Countries(CountryName)" +
                            "VALUES(@CountryName);" +
                            "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountryId = insertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return CountryId;
        }

        public static bool updateCountry(int Id, string CountryName)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = "UPDATE Countries" +
                            "SET CountryName=@CountryName" +
                            "WHERE CountryID=@CountryID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@CountryID", Id);
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (AffectedRows > 0);







        }

        public static bool DeleteCountry(int Id)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = @"   DELETE Countries
                           WHERE CountryID=@CounrtyID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", Id);

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (AffectedRows > 0);





        }

        public static DataTable GetAllCountries()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSitting.ConnectionString);
            string Query = "SELECT * FROM Countries";
            SqlCommand cmd = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;
        }


    }
}
