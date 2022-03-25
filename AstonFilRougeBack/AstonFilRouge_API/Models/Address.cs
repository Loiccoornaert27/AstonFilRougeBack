using System.ComponentModel.DataAnnotations;

namespace AstonFilRouge_API.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int Num { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

    }
}
