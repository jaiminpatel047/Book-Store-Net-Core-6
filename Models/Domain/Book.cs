using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models.Domain
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        public int AuthoreId { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int GenreId { get; set; }
        [NotMapped]
        public string? GeneralName { get; set; }
        [NotMapped]
        public string? AuthoreName { get; set; }
        [NotMapped]
        public string? PublisherName { get; set; }
        [NotMapped]
        public List<SelectListItem>? GeneralList { get; set; }
        [NotMapped]
        public List<SelectListItem>? AuthoreList { get; set; }
        [NotMapped]
        public List<SelectListItem>? PublisherList { get; set; }
    }
}
