using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQLServerAPI.Models
{
    public class UsersModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameUser { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Directions { get; set; }

        public UsersModel()
        {
            NameUser = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Directions = string.Empty;
        }
    }
}
