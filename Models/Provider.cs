using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, Phone]
        public string? Telefono { get; set; }
        
    }
}