
using System.ComponentModel.DataAnnotations;

namespace api.Models
{   
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool UserRole { get; set; }

        public Gender gender { set; get; }
    }

    public enum Gender
    {
        [Display(Name ="Male")]
        male =0,
        [Display(Name = "Female")]
        female=1

    }
}