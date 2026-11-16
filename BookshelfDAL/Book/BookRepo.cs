using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using BookshelfDAL;
using BookshelfDAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace BookshelfDAL.Book
{
    public class BookRepo : IBookRepo
    {
        public BookRepo() 
        {

        }

        public void Add(BookDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO book(title, authorid, releasedate, description, publisher, rating)" +
                    " OUTPUT INSERTED.bookid" +   
                    " VALUES (@title, @authorid, @releasedate, @description, @publisher, @rating)", connection);

                command.Parameters.AddWithValue("@title", dto.Title);
                command.Parameters.AddWithValue("@authorid", dto.AuthorId);
                command.Parameters.AddWithValue("@releasedate", (object?)dto.ReleaseDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@description", (object?)dto.Description ?? DBNull.Value);
                command.Parameters.AddWithValue("@publisher", dto.Publisher);
                command.Parameters.AddWithValue("@rating", dto.Rating);
                int bookid = Convert.ToInt32(command.ExecuteScalar());

                foreach (int genreId in dto.BookGenre)
                {
                    SqlCommand genreCommand = new SqlCommand(
                        "INSERT INTO book_genre(bookid, genreid) VALUES (@bookid, @genreid)", connection);
                    genreCommand.Parameters.AddWithValue("@bookid", bookid);
                    genreCommand.Parameters.AddWithValue("@genreid", genreId);
                    genreCommand.ExecuteNonQuery();
                }
            }
        }

        public bool BookExists(string title, int authorId)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            {
                
                SqlCommand command = new SqlCommand(@"SELECT COUNT(1)
                FROM book
                WHERE title = @Title AND authorid = @AuthorId", connection);

                command.Parameters.Add("@Title", System.Data.SqlDbType.NVarChar).Value = title;
                command.Parameters.Add("@AuthorId", System.Data.SqlDbType.Int).Value = authorId;
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
        
    }
}
