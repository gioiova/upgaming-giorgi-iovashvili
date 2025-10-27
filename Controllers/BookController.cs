using BookApi.Interfaces;
using BookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookRepository;
        public BookController(IBook bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("/api/books")]
        public IActionResult GetBooks([FromQuery] int? publicationYear, [FromQuery] string? sortBy)
        {
            var books = _bookRepository.GetBooks(publicationYear, sortBy);
            return Ok(books);
        }

        [HttpGet("/api/authors/{id}/books")]
        public IActionResult GetBooksByAuthor(int id)
        {

            var booksByAuthor = _bookRepository.GetBooksByAuthorId(id);
            if (booksByAuthor == null || !booksByAuthor.Any())
            {
                return NotFound($"No books found for author with ID {id}");
            }
            return Ok(booksByAuthor);
        }

        [HttpPost("/api/books")]
        public IActionResult CreateBook(Book newBook)
        {
            if (newBook.PublicationYear > DateTime.Now.Year)
                return BadRequest("Publication year cannot be in the future.");

            if (newBook.Title == null)
                return BadRequest("Title can not be empty");

            if (!DataStore.Authors.Any(a => a.ID == newBook.AuthorID))
                return BadRequest("AuthorID must correspond to an existing author");


            var createdBook = _bookRepository.CreateBook(newBook);

            return StatusCode(201, createdBook);
        }

        [HttpPut("/api/books/{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var existingBook = DataStore.Books.FirstOrDefault(b => b.ID == id);
            if (existingBook == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            if (updatedBook.PublicationYear > DateTime.Now.Year)
                return BadRequest("Publication year cannot be in the future.");

            if (updatedBook.Title == null)
                return BadRequest("Title can not be empty");

            if (!DataStore.Authors.Any(a => a.ID == updatedBook.AuthorID))
                return BadRequest("AuthorID must correspond to an existing author");

            _bookRepository.UpdateBook(id, updatedBook);


            return NoContent();
        }

    }
}
