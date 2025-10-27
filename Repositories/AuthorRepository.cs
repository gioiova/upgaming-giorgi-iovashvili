using BookApi.Interfaces;
using BookApi.Models.DTOs;

namespace BookApi.Repositories
{
    public class AuthorRepository : IAuthor
    {
        public AuthorDetailsDto GetAuthorWithBooks(int id)
        {
            var author = DataStore.Authors.FirstOrDefault(a => a.ID == id);
            if(author == null)
            {
                return null;
            }

            var authorBooks = DataStore.Books
                .Where(b => b.AuthorID == id)
                .Select(b => new BookDto
                {
                    Id = b.ID,
                    Title = b.Title,
                    AuthorName = author.Name,
                    PublicationYear = b.PublicationYear
                }).ToList();

            var authorDetailsDto = new AuthorDetailsDto
            {
                Id = author.ID,
                Name = author.Name,
                Books = authorBooks
            };
            return authorDetailsDto;
        }
    }
}
