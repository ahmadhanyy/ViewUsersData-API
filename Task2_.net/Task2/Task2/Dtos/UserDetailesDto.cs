using System.ComponentModel.DataAnnotations;

namespace Task2.Dtos
{
    public class UserDetailesDto
    {
        [Required]
        public string Name { get; set; }
    }
}
