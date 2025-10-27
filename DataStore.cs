using BookApi.Models;

namespace BookApi
{
    public static class DataStore
    {
        private static List<Author> _authors = new List<Author>
        {
            new Author { ID = 1, Name = "Robert C. Martin" },
            new Author { ID = 2, Name = "Jeffrey Richter" }
        };

        private static List<Book> _books = new List<Book>
        {
            new Book
            {
                ID = 1,
                Title = "Clean Code",
                AuthorID = 1,
                PublicationYear = 2008
            },
            new Book
            {
                ID = 2,
                Title = "CLR via C#",
                AuthorID = 2,
                PublicationYear = 2012
            },
            new Book
            {
                ID = 3,
                Title = "The Clean Coder",
                AuthorID = 1,
                PublicationYear = 2011
            },
            new Book
            {
                ID = 4,
                Title = "Code Complete",
                AuthorID = 2,
                PublicationYear = 2004
            }
        };

        // Public properties to access the collections
        public static List<Author> Authors => _authors;
        public static List<Book> Books => _books;
    }

}
