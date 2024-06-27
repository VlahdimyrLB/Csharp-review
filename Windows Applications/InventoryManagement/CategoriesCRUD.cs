using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InventoryManagement
{
    internal class CategoriesCRUD
    {
        private string connectionString;
        public CategoriesCRUD() 
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;
        }

        // CREATE
        public void AddCategory(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Categories (Name) VALUES (@Name)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // READ CATEGORIES
        public DataTable ReadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // UDPATE
        public void UpdateCategory(int id, string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE
        public void DeleteCategory(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Categories WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }

        // SEARCH
        public DataTable SearchCategory(string SearchTerm)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categories WHERE Name LIKE @SearchTerm";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + SearchTerm + "%");

                DataTable dt =new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
