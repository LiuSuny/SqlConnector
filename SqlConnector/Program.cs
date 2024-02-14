
using System;
using System.Data.SqlClient;

namespace SqlConnector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            using (var sqlConnection = new SqlConnection("Server = Toshiba-nout\\SUNNYLESSON; Database = test; User Id=testuser; Password=testuser;"))
            { 
                sqlConnection.Open();

                //Inserting and connecting our database 
                using (var command = new SqlCommand
                    ($"INSERT INTO dbo.Users(Id, Username, Firstname, Lastname, CreatedDateUtc, IsEnabled) VALUES('{Guid.NewGuid().ToString("N")}', 'Username1', 'my first name', 'my last name', ' 12/10/2025 12:32:10 PM +01:00', '1') ", sqlConnection))
                {
                    var result = command.ExecuteNonQuery();
                            
                }
                //Connecting and reading from our database 
                using (var command = new SqlCommand("SELECT * FROM dbo.Users", sqlConnection))
                {
                   
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Username: {reader["Username"]} First name: {reader["Firstname"]} Last name: {reader["Lastname"]} IsEnabled {reader["IsEnabled"]} CreateddateUtc {reader["CreatedDateUtc"]}");
                        }

                    }
                }
            }
            Console.Read();
        }
    }
}


