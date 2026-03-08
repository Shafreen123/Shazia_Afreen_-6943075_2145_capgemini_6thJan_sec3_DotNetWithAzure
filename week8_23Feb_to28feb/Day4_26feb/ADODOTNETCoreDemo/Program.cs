using System;
using System.Data;
using Microsoft.Data.SqlClient;
namespace ADODOTNETCoreDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString =
                    "Data Source=LAPTOP-JIAMKEF8\\SQLEXPRESS;" +
                    "Initial Catalog=EmployeeDB;" +
                    "Integrated Security=True;" +
                    "Encrypt=True;" +
                    "TrustServerCertificate=True;";

                GetAllEmployees(connectionString);

                GetEmployeeByID(connectionString, 1);

                CreateEmployeeWithAddress(
                    connectionString,
                    "Ramesh",
                    "Sharma",
                    "ramesh@example.com",
                    "123 Patia",
                    "BBSR",
                    "India",
                    "755019"
                );

                UpdateEmployeeWithAddress(
                    connectionString,
                    3,
                    "Rakesh",
                    "Sharma",
                    "rakesh@example.com",
                    "3456 Patia",
                    "CTC",
                    "India",
                    "755024"
                );

                DeleteEmployee(connectionString, 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            Console.ReadLine();
        }

        // ================= GET ALL EMPLOYEES =================
        static void GetAllEmployees(string connectionString)
        {
            Console.WriteLine("GetAllEmployees Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("GetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"EmployeeID: {reader["EmployeeID"]}, " +
                        $"FirstName: {reader["FirstName"]}, " +
                        $"LastName: {reader["LastName"]}, " +
                        $"Email: {reader["Email"]}"
                    );

                    Console.WriteLine(
                        $"Address: {reader["Street"]}, " +
                        $"{reader["City"]}, " +
                        $"{reader["State"]}, " +
                        $"{reader["PostalCode"]}\n"
                    );
                }

                reader.Close();
            }
        }

        // ================= GET EMPLOYEE BY ID =================
        static void GetEmployeeByID(string connectionString, int employeeID)
        {
            Console.WriteLine("GetEmployeeByID Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("GetEmployeeByID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"Employee: {reader["FirstName"]} {reader["LastName"]}, " +
                        $"Email: {reader["Email"]}"
                    );

                    Console.WriteLine(
                        $"Address: {reader["Street"]}, " +
                        $"{reader["City"]}, " +
                        $"{reader["State"]}, " +
                        $"{reader["PostalCode"]}\n"
                    );
                }

                reader.Close();
            }
        }

        // ================= CREATE EMPLOYEE =================
        static void CreateEmployeeWithAddress(
            string connectionString,
            string firstName,
            string lastName,
            string email,
            string street,
            string city,
            string state,
            string postalCode)
        {
            Console.WriteLine("CreateEmployeeWithAddress Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("CreateEmployeeWithAddress", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@PostalCode", postalCode);

                connection.Open();
                command.ExecuteNonQuery();

                Console.WriteLine("Employee and Address created successfully.\n");
            }
        }

        // ================= UPDATE EMPLOYEE =================
        static void UpdateEmployeeWithAddress(
            string connectionString,
            int employeeID,
            string firstName,
            string lastName,
            string email,
            string street,
            string city,
            string state,
            string postalCode)
        {
            Console.WriteLine("UpdateEmployeeWithAddress Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("UpdateEmployeeWithAddress", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@PostalCode", postalCode);

                connection.Open();
                command.ExecuteNonQuery();

                Console.WriteLine("Employee and Address updated successfully.\n");
            }
        }

        // ================= DELETE EMPLOYEE =================
        static void DeleteEmployee(string connectionString, int employeeID)
        {
            Console.WriteLine("DeleteEmployee Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                    Console.WriteLine("Employee and Address deleted successfully.\n");
                else
                    Console.WriteLine("Employee not found.\n");
            }
        }
    }
}
