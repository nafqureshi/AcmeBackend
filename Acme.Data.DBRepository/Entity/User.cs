using System.ComponentModel.DataAnnotations;

namespace Acme.Data.DBRepository.Entity
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
