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
    }
}
