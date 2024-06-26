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
    internal class ItemsCRUD
    {
        private string connectionStrings;
        public ItemsCRUD() 
        {
            connectionStrings = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;
        }


        // CREATE ITEMS
        public void AddItem(string itemName, int categoryId, int quantity, decimal price, int supplierId)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                string query = "INSERT INTO Items (ItemName, CategoryId, Quantity, Price, SupplierId) VALUES (@ItemName, @CategoryId, @Quantity, @Price, @SupplierId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // READ ITEMS
        public DataTable ReadItems()
        { 
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                string query = "SELECT Items.Id, ItemName, Items.CategoryId, Categories.Name As Category, Quantity, Price, Items.SupplierId, Suppliers.Name As Supplier FROM Items " +
                       "INNER JOIN Categories ON Items.CategoryId = Categories.Id " +
                       "INNER JOIN Suppliers ON Items.SupplierId = Suppliers.Id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // UPDATE ITEM
        public void UpdateItem(int id, string itemName, int categoryId, int quantity, decimal price, int supplierId)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                string query = "UPDATE Items SET ItemName=@ItemName, CategoryId=@CategoryId, Quantity=@Quantity, Price=@Price, SupplierId=@SupplierId WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE ITEMS
        public void DeleteItem(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                string query = "DELETE FROM Items WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // SEARCH ITEM

        public DataTable SearchItem(string SearchTerm)
        {
            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                string query = "SELECT * FROM Items WHERE ItemName LIKE @SearchTerm";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + SearchTerm + "%");
                
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
