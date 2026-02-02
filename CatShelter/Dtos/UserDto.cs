using CatShelter.Models;

namespace CatShelter.Dtos
{
    public class UserDto
    {
        public record UserReadDto(int Id, string Username, string FirstName, string LastName, string Email, string Password);
        public record UserCreateDto(string Username, string FirstName, string LastName, string Email, string Password);
    }
}
//public int Id { get; set; }
//public string Username { get; set; } = null!;
//public string FirstName { get; set; } = null!;
//public string LastName { get; set; } = null!;
//public string Email { get; set; } = null!;
//public string Password { get; set; } = null!;