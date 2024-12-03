using System.ComponentModel.DataAnnotations;

namespace EBookStoreProjectAdmin.Models
{
    public class Book
    {
        [Required]
        public String Title { get; set; }
        [Required]
        public string BookCover { get; set; }
        public String Description { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public String Genre { get; set; }
        [Required]
        public Int32 QuantityAvaiable { get; set; }
        [Required]
        public double Price { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
