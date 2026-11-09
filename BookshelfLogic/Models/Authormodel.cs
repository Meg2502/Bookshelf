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

        public DateTime Birthdate { get; private set; }
        public string Gender { get; private set; }
        public string Biography { get; private set; }

        //TODO image

        public AuthorModel(string name, int id, DateTime birthdate)
        {
            Name = name;
            Id = id;
            Birthdate = birthdate;
        }

     
        public AuthorModel(string name, int id, string gender, string biography, DateTime birthdate  ) : this(name, id, birthdate)
        {
            Gender = gender;
            Biography = biography;
        }
    }
}
