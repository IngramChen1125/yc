using System.ComponentModel.DataAnnotations;

namespace YC.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string Account { get; set; } = string.Empty;

        [Required, MaxLength(10)]
        public string Password { get; set; } = string.Empty;
    }
}
