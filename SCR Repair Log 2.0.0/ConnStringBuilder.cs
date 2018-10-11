using System;
using System.Data;
using System.Configuration;

namespace SCR_Repair_Tracker
{
    public static class ConnStringBuilder
    {
        //This class is designed to build, test and store a sql db connection string


        private static string connectionString;  // stores conn string once user and pw is validated

         


        public static string ConnectionString  // public prop of connection string so data class can use
        {
            get { return connectionString; }
        }

        public static bool TestLogin(string PasswordIn) // method to test the login by trying to open a connection
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(InsertCredentials("DbConn",PasswordIn)))
            {

                try
                {
                    connection.Open();
                    StoreConnString(InsertCredentials("DbConn", PasswordIn)); // stores the connection string once valdidated
                    return true;
                }
                catch (Exception)
                {

                    return false; 
                }
                 
                
            }
            
        }

        private static void StoreConnString(string inputString) // method to store string
        {
            connectionString = inputString;
        }

        public static void ClearCredentials() //deletes the string when user is logged out due to idle
        {
            connectionString = "";
        }

        public static string InsertCredentials(string name, string Password)  // inputs users creditials into string for testing
        {

            string ConnUnaltered = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return ConnUnaltered.Replace("passIn", Password);

        }


    }
}
