using System.ComponentModel.DataAnnotations;

namespace WebApplication2
{
    public class PersonClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string University { get; set; }

    }
}
