using System.ComponentModel.DataAnnotations;

namespace DbFileApi.Domain.Entities.DTOs
{
    public class UserProfileDTO
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int UserRole { get; set; }

        [MinLength(5), MaxLength(30)]
        public required string Login { get; set; }

        [MinLength(6)]
        public required string Password { get; set; }
    }
}
