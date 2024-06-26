using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDpractice1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void insertButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-18BQ05G;Initial Catalog=CRUDpractice1;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into contact values(@name,@age)", con);
            cmd.Parameters.Add("@name", nameTextBox.Text);
            cmd.Parameters.Add("@age", int.Parse(ageTextBox.Text));
            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Data Inserted Successfully");
            nameTextBox.Clear();
            ageTextBox.Clear();

        }

        [Obsolete]
        private void updateButton_Click(object sender, EventArgs e)
        {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-18BQ05G;Initial Catalog=CRUDpractice1;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update contact set name=@name, age=@age where id=@id", con);
                cmd.Parameters.Add("@id", int.Parse(idTextBox.Text));
                cmd.Parameters.Add("@name", nameTextBox.Text);
                cmd.Parameters.Add("@age", int.Parse(ageTextBox.Text));
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Data Updated Successfully");
                idTextBox.Clear();
                nameTextBox.Clear();
                ageTextBox.Clear();
            dataGridView1.RefreshEdit();

        }

        [Obsolete]
        private void deleteTextBox_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-18BQ05G;Initial Catalog=CRUDpractice1;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete contact where id=@id", con);
            cmd.Parameters.Add("@id", int.Parse(idTextBox.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            idTextBox.Clear();
            nameTextBox.Clear();
            ageTextBox.Clear();
            MessageBox.Show("Data Deleted Successfully");

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-18BQ05G;Initial Catalog=CRUDpractice1;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from contact", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
                
        }
    }
}
