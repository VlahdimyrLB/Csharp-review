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
    public partial class CategoriesForm : Form
    {
        CategoriesCRUD categoriesCRUD;
        public CategoriesForm()
        {
            InitializeComponent();
            categoriesCRUD = new CategoriesCRUD();

            LoadData();
        }

        public void LoadData()
        {
            dataGridView1.DataSource = categoriesCRUD.ReadCategories();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            categoriesCRUD.AddCategory(categoryTextBox.Text);
            MessageBox.Show("Successfully Saved");

            LoadData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                if (row.Index != -1 && row.Cells["Name"].Value != null)
                {
                    categoryTextBox.Text = row.Cells["Name"].Value.ToString();
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                categoriesCRUD.UpdateCategory(id, categoryTextBox.Text);
                MessageBox.Show("UPDATED SUCCESSFULLY");

                LoadData();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                categoriesCRUD.DeleteCategory(id);
                MessageBox.Show("DELETED SUCCESSFULLY");

                LoadData();
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = categoriesCRUD.SearchCategory(searchTextBox.Text);
            dataGridView1.DataSource = dt;
        }
    }
}
