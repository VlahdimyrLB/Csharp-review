using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ContactManagement
{
    class ContactsCRUD
    {
        private string connectionString;
        internal DataTable DataSource;

        public ContactsCRUD()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ContactManagement"].ConnectionString;
        }

        public void AddContact(string firstName, string lastName, int age, string email, string phoneNumber, string address)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Contacts (FirstName, LastName, Age, Email, PhoneNumber, Address) VALUES (@FirstName, @LastName, @Age, @Email, @PhoneNumber, @Address)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Address", address);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ReadContacts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacts";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void UpdateContact(int id, string firsName, string lastName, int age, string email, string phoneNumber, string address)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Contacts SET FirstName=@Firstname, LastName=@LastName, Age=@Age, Email=@Email, PhoneNumber=@PhoneNumber, Address=@Address WHERE Id=@ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@FirstName", firsName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Address", address);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteContact(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE from Contacts WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable SearchContact(string searchTerm)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacts WHERE FirstName LIKE @SearchTerm OR LastName LIKE @SearchTerm OR Email LIKE @SearchTerm OR Age LIKE @SearchTerm";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
    }
}
