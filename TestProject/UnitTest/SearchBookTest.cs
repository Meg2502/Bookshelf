using BookshelfBL;
using BookshelfBL.Models;
using BookshelfDAL.Book;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.FakeRepos;

namespace TestProject.UnitTest
{
    public class SearchBookTest
    {
        [TestMethod]
        public void EnterNameorTitle_Search_ShowResults()
        {
            //Arrange
            FakeBookRepository bookrepository = new FakeBookRepository();
            BookService service = new BookService(bookrepository);
            FakeAuthorRepository authorRepository = new FakeAuthorRepository();
         //   AuthorService authorservice = new AuthorService(authorservice);

            //
        }

        [TestMethod]
        public void EnterNameorTitle_Search_NoResultsFound()
        {

        }
    }


}


//[TestMethod]
//public void EnterBookInfo_AddBook_SavesBook()
//{
//    //Arrange
//    FakeBookRepository repository = new FakeBookRepository();
//    BookService service = new BookService(repository);

//    List<Genre> bookgenre = new List<Genre>() { Genre.Fiction };


//    BookModel book = new BookModel("The Alchemist", 1, bookgenre, "Test", new DateOnly(1988, 1, 1), "HarperTorch");


//    //Act - Subject of test
//    BookDTO result = service.CreateBook(book);

//    //Assert
//    Assert.IsTrue(repository.AddWasCalled);

//    Assert.AreEqual(1, repository.Books.Count);
//    BookDTO savedBook = repository.Books.Single();

//    Assert.AreSame(result, savedBook);
//    Assert.AreEqual(book.Title, savedBook.Title);
//    Assert.AreEqual(book.AuthorID, savedBook.AuthorId);
//    Assert.AreEqual(book.Description, savedBook.Description);
//    Assert.AreEqual(book.ReleaseDate, savedBook.ReleaseDate);
//    Assert.AreEqual(book.Publisher, savedBook.Publisher);
//    CollectionAssert.AreEqual(
//        new[] { (int)Genre.Fiction },
//        savedBook.BookGenre.ToArray());
//}