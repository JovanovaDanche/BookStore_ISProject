using System.ComponentModel.DataAnnotations;

namespace EBookStoreProjectAdmin.Models
{
    public class Author
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public string AuthorImage { get; set; }
        [Required]
        public string Biography { get; set; }
    }
}
