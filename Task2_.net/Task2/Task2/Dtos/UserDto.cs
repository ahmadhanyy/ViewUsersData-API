using System.ComponentModel.DataAnnotations;

namespace Task2.Dtos
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
