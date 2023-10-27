using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Domain
{
    public class Publisher
    {
        public int ID { get; set; }
        [Required]
        public string PublisherName { get; set; }
    }
}
