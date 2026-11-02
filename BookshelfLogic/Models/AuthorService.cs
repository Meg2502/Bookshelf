using BookshelfDAL.Author;
using BookshelfBL.Helpers.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfBL.Models
{
    public class AuthorService
    {
        private readonly AuthorRepo _authorRepository;
        public AuthorService(AuthorRepo authorRepository)
        {
            _authorRepository = authorRepository;
        }

        //Hier maak je een lijst van al je bestaande auteurs, via je mapper die alles van dtos heeft omgezet naar authormodels
        public List<AuthorModel> GetAllAuthors()
        {
            List<AuthorDTO> dtos = new AuthorRepo().GetAllAuthors();
            return AuthorMapper.MapToBusinessList(dtos);
        }
    }
}
