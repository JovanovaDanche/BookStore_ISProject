using System.ComponentModel.DataAnnotations;

namespace EBookStoreProjectAdmin.Models
{
    public class Publisher
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string MobileNum { get; set; }
    }
}
