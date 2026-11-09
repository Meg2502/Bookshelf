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
                SqlCommand command = new SqlCommand("INSERT INTO book(title, authorid, releasedate, description, publisher, rating) VALUES (@title, @authorid, @releasedate, @description, @publisher, @rating)", connection);
                
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
        
    }
}
