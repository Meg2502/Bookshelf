using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using BookshelfDAL;
using Microsoft.Data.SqlClient;

namespace BookshelfDAL.Book
{
    public class BookRepo
    {
        public BookRepo()
        {

        }
        
        public void Add(BookDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO book(title, authorid, releasedate, description, publisher, rating)" +
                    " VALUES (@title, @authorid, @releasedate, @description, @publisher, @rating)", connection);
                
                command.Parameters.AddWithValue("@title", dto.Title);
                command.Parameters.AddWithValue("@authorid", dto.AuthorId);
                command.Parameters.AddWithValue("@releasedate", dto.ReleaseDate);
                command.Parameters.AddWithValue("@description", dto.Description);
                command.Parameters.AddWithValue("@publisher", dto.Publisher);
                command.Parameters.AddWithValue("@rating", dto.Rating);
                command.ExecuteNonQuery();

                //to do: foreach genre in dto add to book_genre
            } 
        }

        public bool BookExists(string title, int authorId)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            {
                
                SqlCommand command = new SqlCommand(@"SELECT COUNT(1)
                FROM books
                WHERE title = @Title AND authorid = @AuthorId", connection);

                command.Parameters.Add("@Title", System.Data.SqlDbType.NVarChar).Value = title;
                command.Parameters.Add("@AuthorId", System.Data.SqlDbType.Int).Value = authorId;
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
        
    }
}
