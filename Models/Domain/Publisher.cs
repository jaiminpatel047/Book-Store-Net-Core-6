using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Domain
{
    public class Author
    {
        public int ID { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}
