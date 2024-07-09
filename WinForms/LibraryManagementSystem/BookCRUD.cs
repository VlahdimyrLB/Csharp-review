using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagementSystem
{
    internal class BookCRUD
    {
        private string connectionString;

        public BookCRUD()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;
        }

        // CREATE 
        public void AddBook(string title, string genre, int authorId, string isbn, int publicatonYear  )
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Books (Title, Genre, Author, ISBN, PublicationYear) VALUES (@Title, @Genre, @Author, @ISBN, @PublicationYear)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@Author", authorId);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@PublicationYear", publicatonYear);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // READ
        public DataTable GetBooks()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Books.id, Books.Title, Books.Genre, Books.Author as AuthorId, Authors.Name as Author, Books.ISBN, Books.PublicationYear FROM Books INNER JOIN Authors ON Books.Author = Authors.id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;  

            }
        }

        // UPDATE 
        public void UpdateBook(int id, string title, string genre, int authorId, string isbn, int publicatonYear)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Books SET Title=@Title, Genre=@Genre, Author=@Author, ISBN=@ISBN, PublicationYear=@PublicationYear WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@Author", authorId);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@PublicationYear", publicatonYear);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE
        public void DeleteBook(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Books WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Search Items
        public DataTable SearchBook(string searchTerm)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Books WHERE Title LIKE @SearchTerm OR Genre LIKE @SearchTerm OR ISBN LIKE @SearchTerm OR Author LIKE @SearchTerm";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
