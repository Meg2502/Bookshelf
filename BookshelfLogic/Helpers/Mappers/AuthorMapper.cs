using System;
using System.Collections.Generic;
using System.Text;
using BookshelfDAL.Author;
using BookshelfDAL.Book;
using BookshelfBL.Models;


namespace BookshelfBL.Helpers.Mappers
{
    internal static class AuthorMapper
    {
        //Hier doe je de data van je DTO overzetten naar je business laag dus authormodel
        internal static AuthorModel MapToBusiness(AuthorDTO dto)
        {
            //Eerst checken bestaat ie al
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            //dan hier maak je een nieuw object ervan aan met de data uit de dto (dto.data)
            AuthorModel author = null;
            //ToDo map dto to domin model
            //AuthorModel author = new AuthorModel(dto.Name, dto.Id, dto.Birthdate, dto.Gender, dto.Biography);

            //Je hebt een lijst met boeken dus die moeten ook nog overgezet worden
            //if (dto.Books != null)
            //{
            //    foreach (var bookdto in dto.Books )
            //    {
            //        BookModel book = new BookModel(
            //            bookdto.BookModel.Title,
            //            bookdto.BookModel.Genre,
            //            bookdto.BookModel.Description,
            //            bookdto.BookModel.Releasedate,
            //            bookdto.BookModel.Publisher
            //            );
            //        author.AddBookModel(book);
            //    }
            //}
            return author;
        }

        //hier maak je een lijst van je dtos die je hebt omgezet
        internal static List<AuthorModel> MapToBusinessList(List<AuthorDTO> dtos)
        {
            if (dtos == null)
            {
                return new List<AuthorModel>();
            }

            return dtos.Select(dto => MapToBusiness(dto)).ToList();
        }
    }
}
