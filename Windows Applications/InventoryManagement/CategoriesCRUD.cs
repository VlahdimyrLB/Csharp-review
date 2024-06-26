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
    }
}
