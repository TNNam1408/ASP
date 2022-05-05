using BookControllerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace BookControllerMVC.Connect
{
    public class ConnnectData
    {
        public ConnnectData() { }

        public string ConnectionString = $"Data Source=LAPTOP-34LLS43H;Initial Catalog=Books;Integrated Security=True";

        public List<Book> getList()
        {
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select *from Book";
                SqlCommand cm = new SqlCommand(query, conn);
                SqlDataReader data = cm.ExecuteReader();
                List<Book> listBook = new List<Book>();
                while (data.Read())
                {
                    Book b = new Book();
                    b.Id = int.Parse(data["id"].ToString());
                    b.Name = data["name"].ToString();
                    b.Author = data["author"].ToString();
                    b.Image = data["image"].ToString();
                    listBook.Add(b);
                }
                return listBook;
            }
        }

        public List<Book> searchList(Book book)
        {
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = $"Select *from Book where name like N'%{book.Name}%'";
                SqlCommand cm = new SqlCommand(query, conn);
                SqlDataReader data = cm.ExecuteReader();
                List<Book> listBook = new List<Book>();
                while (data.Read())
                {
                    Book b = new Book();
                    b.Id = int.Parse(data["id"].ToString());
                    b.Name = data["name"].ToString();
                    b.Author = data["author"].ToString();
                    b.Image = data["image"].ToString();
                    listBook.Add(b);
                }
                return listBook;
            }
        }

        public bool createBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "insert into Book values(@name, @author, @image)";
                SqlCommand cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@name", book.Name);
                cm.Parameters.AddWithValue("@author", book.Author);
                cm.Parameters.AddWithValue("@image", book.Image);
                try
                {
                    int resulf = cm.ExecuteNonQuery();
                    return resulf > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool editBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = $"update Book set name = @name,author = @author, image =@image where id = @id";
                SqlCommand cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@id", book.Id);
                cm.Parameters.AddWithValue("@name", book.Name);
                cm.Parameters.AddWithValue("@author", book.Author);
                cm.Parameters.AddWithValue("@image", book.Image);
                try
                {
                    int resulf = cm.ExecuteNonQuery();
                    return resulf > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool delete(Book book)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = $"Delete Book where id = @id";
                SqlCommand cm = new SqlCommand(query, conn);
                cm.Parameters.AddWithValue("@id", book.Id);
                try
                {
                    int resulf = cm.ExecuteNonQuery();
                    return resulf > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}