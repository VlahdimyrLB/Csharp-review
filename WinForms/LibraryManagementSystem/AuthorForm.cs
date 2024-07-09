using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class AuthorForm : Form
    {
        AuthorCRUD authorCRUD;
        public AuthorForm()
        {
            InitializeComponent();
            authorCRUD = new AuthorCRUD();

            LoadData();
        }

        public void LoadData()
        {
            authorGridView.DataSource = authorCRUD.GetAuthor();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            authorCRUD.AddAuthor(nameTextBox.Text, birthdayPicker.Value, nationalityTextBox.Text);
            MessageBox.Show("Succesfully Saved");

            LoadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (authorGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(authorGridView.SelectedRows[0].Cells["id"].Value);
                authorCRUD.DeleteAuthor(id);

                MessageBox.Show("Succesfully Deleted");

                LoadData();
            }
        }

        private void authorGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (authorGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = authorGridView.SelectedRows[0];

                if (row.Cells["Name"].Value != null)
                {
                    nameTextBox.Text = row.Cells["Name"].Value.ToString();

                    if (DateTime.TryParse(row.Cells["Birthday"].Value.ToString(), out DateTime birthday))
                    {
                        birthdayPicker.Value = birthday;
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format in the Birthday field.");
                        birthdayPicker.Value = DateTime.Today;
                    }

                    nationalityTextBox.Text = row.Cells["Nationality"].Value.ToString();
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (authorGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(authorGridView.SelectedRows[0].Cells["id"].Value);
                authorCRUD.UpdateAuthor(id, nameTextBox.Text, birthdayPicker.Value, nationalityTextBox.Text);

                MessageBox.Show("Succesfully Updated");

                LoadData();
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = authorCRUD.SearchAuthor(searchTextBox.Text);
            authorGridView.DataSource = dt;
        }
    }
}
