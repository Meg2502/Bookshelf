using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfDAL.Author
{
    public class AuthorRepo
    {
        //connectie

        public List<AuthorDTO> GetAllAuthors()
        {
            List<AuthorDTO> authors = new List<AuthorDTO>();

            //_connection.Open();
            //SqlCommand command = new SqlCommand("SELECT authors.author_id, title, birthdate, gender, biography, FROM authors", _connection);
            //SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    int currentId = reader.GetInt32(0);

            //    // 1. Check if the author is already in our list
            //    AuthorDTO author = authors.FirstOrDefault(a => a.Id == currentId);

            //    // 2. If it doesn't exist, create it and add it to the list
            //    if (author == null)
            //    {
            //        author = new AuthorDTO
            //        {
            //            Id = currentId,
            //            Name = reader.GetString(1),
            //            Birthdate = reader.GetDateTime(2),
            //            Gender = reader.GetString(3),
            //            Biography = reader.GetString(4),
            //        };
            //        authors.Add(author);
            //    }
            //    author.Books.Add(reader.GetInt32(3));
            //}
            //reader.Close();
            //_connection.Close();

            return authors;
        }
    }
}


