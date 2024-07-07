using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InventoryManagement
{
    internal class SuppliersCRUD
    {
        private string connectionString;
        public SuppliersCRUD() 
        {
            connectionString = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;
        }

        // CREATE
        public void AddSupplier(string name, string contact)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Supplier (Name, Contact) VALUES (@Name, @Contact)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Contact", contact);

                    conn.Open();
                    cmd.ExecuteNonQuery(); 
                }
            }
        }

        // READ
        public DataTable ReadSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Suppliers";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // UPDATE
        public void UpdateSupplier(int id, string name, string contact)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Supplier SET Name= @Name, Contact=@Contact WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Contact", contact);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE
        public void DeleteSupplier(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM SUPPLIER WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // SEARCH
        public DataTable SearchSupplier(string SearchTerm)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Suppliers WHERE Name LIKE @Searchterm";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Searchterm", "%" + SearchTerm + "%");
                
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
