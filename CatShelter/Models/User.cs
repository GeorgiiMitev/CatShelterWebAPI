namespace CatShelter.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public ICollection<Adoption> Adoptions { get; set; } // 1 : M // 1 user може да има много осиновявания
        public ICollection<FavoriteCat> FavoriteCats { get; set; }
    }
}
