using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Societies_Management_System
{

    internal class DatabaseHandler
    {
        private string connectionString;

        public DatabaseHandler()
        {
            connectionString = "Data Source=DESKTOP-CD9SUPU\\SQLEXPRESS;Initial Catalog=society;Integrated Security=True;";
        }
        public DataTable ExecuteQuery(SqlCommand command)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
            }
            return dataTable;
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing non-query: " + ex.Message);
            }
            return rowsAffected;
        }

        public object ExecuteQueryScalar(SqlCommand command)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    return command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing scalar query: " + ex.Message);
                return null;
            }
        }
    }
}
