using System.ComponentModel.DataAnnotations;

namespace MovieAPI_Front.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public User() { }

        public User(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }
    }
}
