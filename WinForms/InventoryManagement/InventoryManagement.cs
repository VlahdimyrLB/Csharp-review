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
    public partial class InventoryManagement : Form
    {
        private ItemsCRUD itemsCrud;
        private CategoriesCRUD categoriesCrud;
        private SuppliersCRUD suppliersCrud;
        public InventoryManagement()
        {
            InitializeComponent();
            itemsCrud = new ItemsCRUD();
            categoriesCrud = new CategoriesCRUD();
            suppliersCrud = new SuppliersCRUD();


            // Load Initial data
            LoadData();    
        }

        private void LoadData()
        {

            // DataGridView for Items
            dataGridView1.DataSource = itemsCrud.ReadItems();

            // Hide the CategoryId and SupplierId columns
            dataGridView1.Columns["CategoryId"].Visible = false;
            dataGridView1.Columns["SupplierId"].Visible = false;

            // Show Categories
            categoryComboBox.DataSource = categoriesCrud.ReadCategories();
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "Id";

            // Show Suppliers
            supplierComboBox.DataSource = suppliersCrud.ReadSuppliers();
            supplierComboBox.DisplayMember = "Name";
            supplierComboBox.ValueMember = "Id";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            itemsCrud.AddItem(itemTextBox.Text, (int)categoryComboBox.SelectedValue, int.Parse(quantityTextBox.Text), decimal.Parse(priceTextBox.Text), (int)supplierComboBox.SelectedValue);
            
            MessageBox.Show("Successfuly Added");

            LoadData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // Check if the selected row is not the header row
                if (row.Index != -1 && row.Cells["ItemName"].Value != null)
                {
                    itemTextBox.Text = row.Cells["ItemName"].Value.ToString();
                    categoryComboBox.SelectedValue = row.Cells["CategoryId"].Value; // Hidden column
                    quantityTextBox.Text = row.Cells["Quantity"].Value.ToString();
                    priceTextBox.Text = row.Cells["Price"].Value.ToString();
                    supplierComboBox.SelectedValue = row.Cells["SupplierId"].Value; // Hidden column
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                itemsCrud.UpdateItem(id, itemTextBox.Text, (int)categoryComboBox.SelectedValue, int.Parse(quantityTextBox.Text), decimal.Parse(priceTextBox.Text), (int)supplierComboBox.SelectedValue);

                MessageBox.Show("Updated Successfuly");

                LoadData();
            }


        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                itemsCrud.DeleteItem(id);

                MessageBox.Show("Deleted Successfuly");

                LoadData();
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = itemsCrud.SearchItem(searchTextBox.Text);
            dataGridView1.DataSource = dt;
        }

        private void viewCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesForm form = new CategoriesForm();
            form.ShowDialog();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierForm form = new SupplierForm();
            form.ShowDialog();
        }
    }
}
