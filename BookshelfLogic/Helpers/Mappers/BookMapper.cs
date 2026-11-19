using BookshelfBL.Models;
using BookshelfDAL.Author;
using BookshelfDAL.Book;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookshelfBL.Helpers.Mappers
{
    internal static class BookMapper
    {
        //Hier doe je de data van je DTO overzetten naar je business laag dus bookmodel
        internal static BookModel MapToBusiness(BookDTO dto)
        {
            //Eerst checken bestaat ie al
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            List<Genre> genres = new List<Genre>();

            // Hier BookGenre overzetten naar een lijst met ints
            if (dto.BookGenre != null)
            {
                foreach (int genreid in dto.BookGenre)
                {
                    genres.Add((Genre)genreid);
                }
            }

            //dan hier maak je een nieuw object ervan aan met de data uit de dto (dto.data)
            BookModel book = new BookModel(dto.Title, dto.AuthorId, genres, dto.Description, dto.ReleaseDate, dto.Publisher);

            return book;
        }

        //hier maak je een lijst van je dtos die je hebt omgezet
        internal static List<BookModel> MapToBusinessList(List<BookDTO> dtos)
        {
            if (dtos == null)
            {
                return new List<BookModel>();
            }

            return dtos.Select(dto => MapToBusiness(dto)).ToList();
        }


    }
}
