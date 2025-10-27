using BookApi.Models;
using BookApi.Models.DTOs;

namespace BookApi.Interfaces
{
    public interface IBook
    {
        List<BookDto> GetAllBooks();
        List<BookDto> GetBooksByAuthorId(int authorId);
        Book CreateBook(Book newBook);
        Book UpdateBook(int id, Book updatedBook);
        List<BookDto> GetFilteredAndSortedBooks(int? publicationYear, string? sortBy);


    }
}
