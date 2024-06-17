using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ContactManagement
{
    public partial class ContactManagement : Form
    {
        private ContactsCRUD contactsCRUD;

        public ContactManagement()
        {
            InitializeComponent();
            contactsCRUD = new ContactsCRUD();

            // event subscription
            // Wire up event handlers
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
        }

        private void ContactManagement_Load(object sender, EventArgs e)
        {
            ReadContacts();
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            // Get the connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["ContactManagement"].ConnectionString;

            // Test the connection
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // READ ALL CONTACTS
        private void ReadContacts()
        {
            DataTable dt = contactsCRUD.ReadContacts();
            dataGridView1.DataSource = dt;
        }

        // CREATE NEW CONTACT
        private void addButton_Click(object sender, EventArgs e)
        {
            contactsCRUD.AddContact(firstNameTextBox.Text, lastNameTextBox.Text, int.Parse(ageTextBox.Text), emailTextBox.Text, phoneTextBox.Text, addressTextBox.Text);
            ReadContacts();
        }

        // UPDATE CONTACT
        private void editButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                contactsCRUD.UpdateContact(id, firstNameTextBox.Text, lastNameTextBox.Text, int.Parse(ageTextBox.Text), emailTextBox.Text, phoneTextBox.Text, addressTextBox.Text);
                ReadContacts();
            }
        }

        // SELECT TO-UPDATE ROW
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {


                DataRowView row = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
                if (row != null)
                {
                    firstNameTextBox.Text = row["FirstName"].ToString();
                    lastNameTextBox.Text = row["LastName"].ToString();
                    ageTextBox.Text = row["Age"].ToString();
                    emailTextBox.Text = row["Email"].ToString();
                    phoneTextBox.Text = row["PhoneNumber"].ToString();
                    addressTextBox.Text = row["Address"].ToString();
                }
            }
        }

        // DELETE DATA
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                contactsCRUD.DeleteContact(id);
                ReadContacts();
            } else
            {
                MessageBox.Show("No selected data to be deleted");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            ageTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            addressTextBox.Clear();

            dataGridView1.ClearSelection();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = contactsCRUD.SearchContact(searchTextBox.Text);
            dataGridView1.DataSource = dt;
        }
    }
}
