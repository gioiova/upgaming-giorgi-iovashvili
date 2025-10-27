using BookApi.Models;
using BookApi.Models.DTOs;

namespace BookApi.Interfaces
{
    public interface IBook
    {
        List<BookDto> GetBooks(int? publicationYear = null, string? sortBy = null);
        List<BookDto> GetBooksByAuthorId(int authorId);
        Book CreateBook(Book newBook);
        Book UpdateBook(int id, Book updatedBook);
    }
}
