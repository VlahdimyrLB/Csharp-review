using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class SupplierForm : Form
    {

        SuppliersCRUD suppliersCrud;
        public SupplierForm()
        {
            InitializeComponent();
            suppliersCrud = new SuppliersCRUD();

            LoadData();
        }

        public void LoadData()
        {
            dataGridView1.DataSource = suppliersCrud.ReadSuppliers();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            suppliersCrud.AddSupplier(supplierTextBox.Text, contactTextBox.Text);
            MessageBox.Show("SUCCESFULLY ADDED");

            LoadData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                if (row.Index != 0 && row.Cells["Name"].Value != null)
                {
                    supplierTextBox.Text = row.Cells["Name"].Value.ToString();
                    contactTextBox.Text = row.Cells["Contact"].Value.ToString();
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                suppliersCrud.UpdateSupplier(id, supplierTextBox.Text, contactTextBox.Text);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                suppliersCrud.DeleteSupplier(id);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = suppliersCrud.SearchSupplier(searchTextBox.Text);
            dataGridView1.DataSource = dt;
        }
    }
}
