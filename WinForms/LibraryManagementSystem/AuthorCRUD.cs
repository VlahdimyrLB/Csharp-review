using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class AuthorCRUD
    {
        private string connectionString;

        public AuthorCRUD()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;
        }

        // CREATE 
        public void AddAuthor(string name, DateTime birthday, string nationality)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Authors (Name, Birthday, Nationality) VALUES (@Name, @Birthday, @Nationality)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Birthday", birthday);
                    cmd.Parameters.AddWithValue("@Nationality", nationality);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // READ
        public DataTable GetAuthor()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Authors";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;

            }
        }

        // UPDATE 
        public void UpdateAuthor(int id, string name, DateTime birthday, string nationality)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Authors SET Namne=@Name, Birthday=@Birthday, Nationality=@Nationality WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Birthday", birthday);
                    cmd.Parameters.AddWithValue("@Nationality", nationality);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE
        public void DeleteAuthor(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Authors WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Search Items
        public DataTable SearchAuthor(string searchTerm)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Authors WHERE Name LIKE @SearchTerm OR Birthday LIKE @SearchTerm OR Nationality LIKE @SearchTerm";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
        }
    }
}
