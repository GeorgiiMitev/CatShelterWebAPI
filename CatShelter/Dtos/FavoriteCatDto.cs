 namespace CatShelter.Dtos
{
    public class FavoriteCatDto
    {
        public record FavoriteCatReadDto(int Id, int UserId, int CatId);
        public record FavoriteCatReadIncludeNamesDto(int Id, int UserId, string FullName, int CatId, string CatName);
        public record FavoriteCatCreateDto(int UserId, int CatId);
    }
}
//public int Id { get; set; }
//public int UserId { get; set; }
//public User User { get; set; }

//public int CatId { get; set; }
//public Cat Cat { get; set; }