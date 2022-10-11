using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digiwallet.Entities
{
    public class User
    {
        [Key]
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? NameSurname { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        [NotMapped]
        public string UserPassword { get; set; }
    }
}