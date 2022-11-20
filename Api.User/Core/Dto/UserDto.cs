using System.ComponentModel.DataAnnotations;

namespace User.Core.Dto
{
    public class UserDto
    {

        public int Id { get; set; }

        public long Identification { get; set; }

        public string Mail { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
