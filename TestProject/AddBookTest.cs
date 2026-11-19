using BookshelfBL;
using BookshelfBL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BookshelfDAL.Book;
using TestProject.FakeRepos;

namespace TestProject
{
    [TestClass]
    public class AddBookTest
    {
        [TestMethod]
        public void EnterBookInfo_AddBook_SavesBook()
        {
            //Arrange
            FakeBookRepository repository = new FakeBookRepository();
            BookService service = new BookService(repository);

            List<Genre> bookgenre = new List<Genre>() { Genre.Fiction};
            

            BookModel book = new BookModel("The Alchemist", 1, bookgenre, "Test", new DateOnly(1988, 1, 1), "HarperTorch");
 
            
            //Act - Subject of test
            BookDTO result = service.CreateBook(book);

            //Assert
            Assert.IsTrue(repository.AddWasCalled);

            Assert.AreEquivalent(1, repository.Books.Count);
            BookDTO savedBook = repository.Books.Single();

            Assert.AreSame(result, savedBook);
            Assert.AreEquivalent(book.Title, savedBook.Title);
            Assert.AreEquivalent(book.AuthorID, savedBook.AuthorId);
            Assert.AreEquivalent(book.Description, savedBook.Description);
            Assert.AreEquivalent(book.ReleaseDate, savedBook.ReleaseDate);
            Assert.AreEquivalent(book.Publisher, savedBook.Publisher);
            CollectionAssert.AreEquivalent(
                new[] { (int)Genre.Fiction },
                savedBook.BookGenre.ToArray());
        }

        [TestMethod]
        public void EnterBookInfo_EmptyTitle_ShowsErrorMessage()
        {
            // Arrange
            FakeBookRepository repository = new FakeBookRepository();
            BookService service = new BookService(repository);

            List<Genre> bookgenre = new List<Genre>() { Genre.Fiction };

            BookModel book = new BookModel(
                "", 1, bookgenre, "Test",
                new DateOnly(1988, 1, 1), "HarperTorch");

            // Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => service.CreateBook(book));


            // Assert
            Assert.IsFalse(repository.AddWasCalled);
            Assert.AreEqual(0, repository.Books.Count); //niet toegevoegd aan systeem check
        }

        [TestMethod]
        public void EnterBookInfo_EmptyAuthor_ShowsErrorMessage()
        {
            // Arrange
            FakeBookRepository repository = new FakeBookRepository();
            BookService service = new BookService(repository);

            List<Genre> bookgenre = new List<Genre>() { Genre.Fiction };

            BookModel book = new BookModel(
                "The Alchemist", 0, bookgenre, "Test",
                new DateOnly(1988, 1, 1), "HarperTorch");

            // Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => service.CreateBook(book));

            // Assert
            Assert.IsFalse(repository.AddWasCalled);
            Assert.AreEqual(0, repository.Books.Count);
        }

        //TODO Once role based access is implemented admin check

        [TestMethod]
        public void EnterBookInfo_DuplicateTitleAndAuthor_ShowsAlreadyExistsMessage()
        {
            // Arrange
            FakeBookRepository repository = new FakeBookRepository();
            BookService service = new BookService(repository);

            List<Genre> bookgenre = new List<Genre>() { Genre.Fiction };

            BookModel book = new BookModel(
                "The Alchemist", 1, bookgenre, "Test",
                new DateOnly(1988, 1, 1), "HarperTorch");

            service.CreateBook(book); 

            // Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => service.CreateBook(book));

            // Assert
            
            Assert.AreEqual(1, repository.Books.Count);
        }

        //[Fact]
        //public void GivenAMovieWithTwoRatings_GetAverageRating_ReturnsAverage()
        //{
        //    //Arrange
        //    Movie movie = new MovieAfter2000("test", 2010);
        //    movie.AddRating(new Rating(2, DateTime.Now, new Rater("test@test.nl", 0)));
        //    movie.AddRating(new Rating(4, DateTime.Now, new Rater("test@test.nl", 0)));
        //    double expected = 3;

        //    //Act - Subject of Test
        //    double result = movie.GetAverageRating();

        //    //Assert
        //    Assert.Equal(expected, result);
        //}

        //[Fact]
        //public void GivenAMovieWithoutRatings_GetAverageRating_ReturnsZero()
        //{
        //    //Arrange
        //    Movie movie = new MovieAfter2000("test", 2010);
        //    double expected = 0;

        //    //Act - Subject of Test
        //    double result = movie.GetAverageRating();

        //    //Assert
        //    Assert.Equal(expected, result);
        //}
    }
}
