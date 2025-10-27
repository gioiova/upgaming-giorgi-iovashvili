using BookApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _authorRepository;
        public AuthorController(IAuthor authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet("/api/authors/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var authorDetails = _authorRepository.GetAuthorWithBooks(id);
            if (authorDetails == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }
            return Ok(authorDetails);
        }

    }
}
