using BookshelfDAL.Book;

namespace Bookshelf.ViewModels
{
    public class CreateAuthorViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }
       //lijst boeken
    }
}
