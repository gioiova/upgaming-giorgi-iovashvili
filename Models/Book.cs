using System.ComponentModel.DataAnnotations;

namespace BookApi.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int PublicationYear { get; set; }
    }
}
