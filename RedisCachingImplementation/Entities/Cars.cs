using System.ComponentModel.DataAnnotations;

namespace RedisCachingImplementation.Entities
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        [Required]
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
