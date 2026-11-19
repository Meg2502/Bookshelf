using BookshelfDAL.Book;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookshelfDAL.Author
{
    public class AuthorRepo
    {
        public void Add(AuthorDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            using (SqlCommand command = new SqlCommand(
                @"INSERT INTO author (name, birthdate, gender, biography)
             VALUES (@name, @birthdate, @gender, @biography)", connection))
            {
                command.Parameters.AddWithValue("@name", dto.Name);
                command.Parameters.Add("@birthdate", System.Data.SqlDbType.Date).Value =
                    dto.Birthdate.ToDateTime(TimeOnly.MinValue);
                command.Parameters.AddWithValue("@gender", (object?)dto.Gender ?? DBNull.Value);
                command.Parameters.AddWithValue("@biography", (object?)dto.Biography ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
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

        public AuthorDTO? GetOneAuthorFromDB(int authorId)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT authorid, name, birthdate, gender, biography
                FROM author
                WHERE authorid = @AuthorId", connection))
            {
                command.Parameters.Add("@AuthorId", System.Data.SqlDbType.Int).Value = authorId;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new AuthorDTO
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Birthdate = DateOnly.FromDateTime(reader.GetDateTime(2)),
                        Gender = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Biography = reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                    };
                }
            }
        }
    }
}



