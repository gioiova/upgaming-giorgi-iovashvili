using BookApi.Models.DTOs;

namespace BookApi.Interfaces
{
    public interface IAuthor
    {
        AuthorDetailsDto GetAuthorWithBooks(int id);
    }
}
