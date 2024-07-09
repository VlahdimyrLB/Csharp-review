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
    public partial class Library : Form
    {

        BookCRUD bookCRUD;
        public Library()
        {
            InitializeComponent();
            bookCRUD = new BookCRUD();

            LoadDate();
        }

        public void LoadDate()
        {
            bookGridView.DataSource = bookCRUD.GetBooks();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            bookForm.ShowDialog();  
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorForm authorForm = new AuthorForm();  
            authorForm.ShowDialog();
        }
    }
}
