using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AstonFilRouge_API.Enums.Enumerables;

namespace AstonFilRouge_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public Role? Role { get; set; }
        public string? Job { get; set; }
        public int? ClubId { get; set; }
        [ForeignKey("ClubId")]
        public virtual Club? Club { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string AvatarUrl { get; set; } 
    }
}
