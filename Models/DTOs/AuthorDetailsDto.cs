namespace BookApi.Models.DTOs
{
    public class AuthorDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
