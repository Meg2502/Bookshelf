using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookshelfBL.Models
{
    public class AuthorModel
    {
        [Required(ErrorMessage ="Please fill in name of the author.")]
        public string Name { get; private set; }
        public int Authorid { get; private set; }

        public DateTime Birthdate { get; private set; }
        public string Gender { get; private set; }
        public string Biography {  get; private set; }
        //TODO image

        public AuthorModel(string name, int authorid)
        {
            Name = name;
            Authorid = authorid;
        }

        public AuthorModel(string name, int authorid, DateTime birthdate, string gender, string biography) : this(name, authorid)
        {
            
            Birthdate = birthdate;
            Gender = gender;
            Biography = biography;
        }
    }
}
