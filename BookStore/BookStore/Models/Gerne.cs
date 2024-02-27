using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Gerne")]
    public class Gerne
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string? GerneName { get; set; }
        public List<Book> Book { get; set; }
     }
}
