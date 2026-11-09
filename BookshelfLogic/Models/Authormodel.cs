using BookshelfDAL.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookshelfBL.Models
{
    public class AuthorModel
    {  
        public string Name { get;  private set; }
        public int Id { get;  private set; }

        public DateOnly Birthdate { get; private set; }
        public string Gender { get; private set; }
        public string Biography { get; private set; }
        public List<BookModel> Books { get; set; } = new List<BookModel>();

        //TODO image

        public AuthorModel(string name, int id, DateOnly birthdate)
        {
            Name = name;
            Id = id;
            Birthdate = birthdate;
            Books = new List<BookModel>();
        }


        public AuthorModel(string name, int id, DateOnly birthdate, string gender, string biography) : this(name, id, birthdate)
        {
            Gender = gender;
            Biography = biography;
        }

        public void AddBook(BookModel book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            Books.Add(book);
        }
    }
}
