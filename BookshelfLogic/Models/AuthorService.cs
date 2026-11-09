using BookshelfBL.Helpers.Mappers;
using BookshelfDAL.Author;
using BookshelfDAL.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfBL.Models
{
    public class AuthorService
    {
        //readonly = repository word 1x ingesteld, zo gaat de service geen andere gebruiken
        private readonly AuthorRepo _authorRepository;
        public AuthorService()
        {
            _authorRepository = new AuthorRepo();
        }

        //Hier maak je een lijst van al je bestaande auteurs, via je mapper die alles van dtos heeft omgezet naar authormodels
        public List<AuthorModel> GetAllAuthors()
        {
            List<AuthorDTO> dtos = new AuthorRepo().GetAllAuthors();
            return AuthorMapper.MapToBusinessList(dtos);
        }

        public List<AuthorModel> GetAuthorsDD()
        {
            List<AuthorDTO> authorsdd = new AuthorRepo().GetAuthorsDD();
            return AuthorMapper.MapToBusinessList(authorsdd);
        }
    }
}
