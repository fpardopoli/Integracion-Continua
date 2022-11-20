using System.ComponentModel.DataAnnotations;

namespace Api.User.Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public long Identification { get; set; }
        [Required]
        public string Mail { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
    
    }
}
