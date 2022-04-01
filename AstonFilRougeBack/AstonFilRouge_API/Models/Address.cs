using System.ComponentModel.DataAnnotations;

namespace AstonFilRouge_API.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int? Num { get; set; }
        [Required]
        public string Street { get; set; }
        public string? Complement { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }

    }
}
