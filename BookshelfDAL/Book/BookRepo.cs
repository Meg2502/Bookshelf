using BookshelfDAL;
using BookshelfDAL.Author;
using BookshelfDAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BookshelfDAL.Book
{
    public class BookRepo : IBookRepo
    {
        AuthorRepo _authorRepo = new AuthorRepo();
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

        public List<BookDTO> GetAllBooks()
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            {
                connection.Open();

                List<BookDTO> books = new List<BookDTO>();

                SqlCommand command = new SqlCommand("SELECT book.title, authorid, releasedate, description, publisher, rating FROM book", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int currentId = reader.GetInt32(0);

                    // 1. Check if the book is already in our list
                    BookDTO book = books.FirstOrDefault(a => a.Id == currentId);

                    // 2. If it doesn't exist, create it and add it to the list
                    if (book == null)
                    {
                        int authorid = reader.GetInt32(2);
                        AuthorDTO authorDTO = _authorRepo.GetOneAuthorFromDB(authorid);

                        book = new BookDTO
                        {
                            Id = currentId,
                            Title = reader.GetString(1),
                            Author = authorDTO,
                            BookGenre = new List<int>(),
                            ReleaseDate = DateOnly.FromDateTime(reader.GetDateTime(3)),
                            Description = reader.GetString(4),
                            Publisher = reader.GetString(5),
                            Rating = reader.GetInt32(6),
                        };
                        books.Add(book);
                    }
                    
                    using (SqlCommand genreCommand = new SqlCommand(
                        @"SELECT genreid from book_genre 
                            WHERE bookid =@bookid", connection))
                    {
                        genreCommand.Parameters.Add("@bookid", System.Data.SqlDbType.Int).Value = book.Id;

                        SqlDataReader genreReader = command.ExecuteReader();
                        while (genreReader.Read())
                        {
                            book.BookGenre.Add(genreReader.GetInt32(0));
                        }
                    }
                }
                reader.Close();
                connection.Close();

                return books;
            }
        }


        public List<BookDTO> GetBooksForList()
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.DBConnectionString))
            {
                connection.Open();

                List<BookDTO> booksdd = new List<BookDTO>();

                SqlCommand command = new SqlCommand("SELECT book.bookid, title, authorid FROM book", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int currentId = reader.GetInt32(0);

                    // 1. Check if the book is already in our list
                    BookDTO book = booksdd.FirstOrDefault(a => a.Id == currentId);

                    int authorid = reader.GetInt32(2);
                    AuthorDTO authorDTO = _authorRepo.GetOneAuthorFromDB(authorid);

                    AuthorDTO authorOnlyNameId = new AuthorDTO
                    {
                        Id = authorDTO.Id,
                        Name = authorDTO.Name
                    };
                        

                    // 2. If it doesn't exist, create it and add it to the list
                    if (book == null)
                    {
                        book = new BookDTO
                        {
                            Id = currentId,
                            Title = reader.GetString(1),
                            Author = authorOnlyNameId,
                        };
                        booksdd.Add(book);
                    }
                }
                reader.Close();
                connection.Close();

                return booksdd;
            }
        }

    }
}
