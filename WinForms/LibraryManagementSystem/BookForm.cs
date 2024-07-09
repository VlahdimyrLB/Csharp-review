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
    public partial class BookForm : Form
    {
        BookCRUD bookCRUD;
        AuthorCRUD authorCRUD;
        public BookForm()
        {
            InitializeComponent();

            bookCRUD = new BookCRUD();
            authorCRUD = new AuthorCRUD(); 

            PopulateYearComboBox();

            LoadData();
        }
        private void PopulateYearComboBox()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= 1900; year--)
            {
                yearComboBox.Items.Add(year);
            }
        }

        private void ClearFields()
        {
            titleTextBox.Text = "";
            genreComboBox.SelectedItem = null;
            authorComboBox.SelectedItem = null;
            isbnTextBox.Text = "";
            yearComboBox.SelectedItem = null;
        }

        public void LoadData()
        {
            bookGridView.DataSource = bookCRUD.GetBooks();
            bookGridView.Columns["AuthorId"].Visible = false;

            authorComboBox.DataSource = authorCRUD.GetAuthor();
            authorComboBox.DisplayMember = "Name";
            authorComboBox.ValueMember = "id";

        }


        private void addButton_Click(object sender, EventArgs e)
        {
            bookCRUD.AddBook(titleTextBox.Text, genreComboBox.SelectedItem.ToString(), (int)authorComboBox.SelectedValue, isbnTextBox.Text, (int)yearComboBox.SelectedItem);
            MessageBox.Show("Successfully Added");

            LoadData();
            ClearFields();
        }

        private void bookGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bookGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = bookGridView.SelectedRows[0];

                if (row.Index != -1 && titleTextBox.Text != null)
                {
                    titleTextBox.Text = row.Cells["Title"].Value.ToString();
                    genreComboBox.SelectedItem = row.Cells["Genre"].Value;
                    authorComboBox.SelectedValue = row.Cells["AuthorId"].Value;
                    isbnTextBox.Text = row.Cells["ISBN"].Value.ToString();
                    yearComboBox.SelectedItem = row.Cells["PublicationYear"].Value;
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (bookGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(bookGridView.SelectedRows[0].Cells["id"].Value);
                bookCRUD.UpdateBook(id, titleTextBox.Text, genreComboBox.SelectedItem.ToString(), (int)authorComboBox.SelectedValue, isbnTextBox.Text, (int)yearComboBox.SelectedItem);
                MessageBox.Show("Successfully Updated");

                LoadData();
                ClearFields();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (bookGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(bookGridView.SelectedRows[0].Cells["id"].Value);
                bookCRUD.DeleteBook(id);
                MessageBox.Show("Deleted Successfully");

                LoadData();
                ClearFields();
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = bookCRUD.SearchBook(searchTextBox.Text);
            bookGridView.DataSource = dt;
        }
    }
}
