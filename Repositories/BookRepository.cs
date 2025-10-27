using BookApi.Interfaces;
using BookApi.Models;
using BookApi.Models.DTOs;

namespace BookApi.Repositories
{
    public class BookRepository : IBook
    {
        public List<BookDto> GetBooks(int? publicationYear, string? sortBy)
        {

            //start with all books
            var query = DataStore.Books.AsEnumerable();


            //filter if publicationYear is provided
            if (publicationYear.HasValue)
            {
                query = query.Where(b => b.PublicationYear == publicationYear.Value);
            }

            var bookDtos = query.Select(book => new BookDto
            {
                Id = book.ID,
                Title = book.Title,
                AuthorName = DataStore.Authors.FirstOrDefault(a => a.ID == book.AuthorID)?.Name ?? "unknown",
                PublicationYear = book.PublicationYear
            }).ToList();

            //sort by title if requested
            if (!string.IsNullOrEmpty(sortBy) && sortBy.Equals("title", StringComparison.OrdinalIgnoreCase))
            {
                bookDtos = bookDtos.OrderBy(b => b.Title).ToList();
            }

            return bookDtos;
        }
        public List<BookDto> GetBooksByAuthorId(int authorId)
        {
            var booksByAuthor = DataStore.Books
                .Where(book => book.AuthorID == authorId)
                .Select(book => new BookDto
                {
                    Id = book.ID,
                    Title = book.Title,
                    AuthorName = DataStore.Authors.FirstOrDefault(a => a.ID == book.AuthorID)?.Name ?? "unknown",
                    PublicationYear = book.PublicationYear
                }).ToList();

            return booksByAuthor;
        }

        public Book CreateBook(Book newBook)
        {
            var book = new Book
            {
                ID = DataStore.Books.Count > 0 ? DataStore.Books.Max(b => b.ID) + 1 : 1,
                AuthorID = newBook.AuthorID,
                Title = newBook.Title,
                PublicationYear = newBook.PublicationYear
            };
            DataStore.Books.Add(book);
            return book;
        }

        public Book UpdateBook(int id, Book updatedBook)
        {
            var existingBook = DataStore.Books.FirstOrDefault(b => b.ID == id);
      
            existingBook.Title = updatedBook.Title;
            existingBook.AuthorID = updatedBook.AuthorID;
            existingBook.PublicationYear = updatedBook.PublicationYear;
            return existingBook;
        }

        }
   
}
