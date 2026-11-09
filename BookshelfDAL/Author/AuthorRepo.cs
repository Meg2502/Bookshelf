using BookshelfDAL.Book;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfDAL.Author
{
    public class AuthorRepo
    {
        public List<AuthorDTO> GetAllAuthors()
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            {
                connection.Open();

                List<AuthorDTO> authors = new List<AuthorDTO>();

                SqlCommand command = new SqlCommand("SELECT authors.authorid, name, birthdate, gender, biography FROM authors", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int currentId = reader.GetInt32(0);

                    // 1. Check if the author is already in our list
                    AuthorDTO author = authors.FirstOrDefault(a => a.Id == currentId);

                    // 2. If it doesn't exist, create it and add it to the list
                    if (author == null)
                    {
                        author = new AuthorDTO
                        {
                            Id = currentId,
                            Name = reader.GetString(1),
                            Birthdate = DateOnly.FromDateTime(reader.GetDateTime(2)),
                            Gender = reader.GetString(3),
                            Biography = reader.GetString(4),
                        };
                        authors.Add(author);
                    }
                    author.Books.Add(new BookDTO { Id = reader.GetInt32(5) });
                }
                reader.Close();
                connection.Close();

                return authors;
            }
        }

            public List<AuthorDTO> GetAuthorsDD()
            {   
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            {
                connection.Open();

                List<AuthorDTO> authorsdd = new List<AuthorDTO>();

                SqlCommand command = new SqlCommand("SELECT author.authorid, name, birthdate FROM author", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int currentId = reader.GetInt32(0);

                    // 1. Check if the author is already in our list
                    AuthorDTO author = authorsdd.FirstOrDefault(a => a.Id == currentId);

                    // 2. If it doesn't exist, create it and add it to the list
                    if (author == null)
                    {
                        author = new AuthorDTO
                        {
                            Id = currentId,
                            Name = reader.GetString(1),
                            Birthdate = DateOnly.FromDateTime(reader.GetDateTime(2)),
                        };
                        authorsdd.Add(author);
                    }
                }
                reader.Close();
                connection.Close();

                return authorsdd;
            }
        }
    }
}



