using CatShelter.Models;

namespace CatShelter.Dtos
{
    public class CatDto
    {
        public record CatReadDto(int Id, string Name, int Age, string Gender, int BreedId, string Description, string ImageURL);
        public record CatReadIncludeNamesDto(int Id, string Name, int Age, string Gender, int BreedId, string BreedName, string Description, string ImageURL);
        public record CatCreateDto(string Name, int Age, string Gender, int BreedId, string Description, string ImageURL);
        
    }
}
//public int Id { get; set; }
//public string Name { get; set; }
//public int Age { get; set; }
//public string Gender { get; set; }
//public int BreedId { get; set; }
//public Breed Breed { get; set; } // 1 : 1
//public string Description { get; set; }
//public string ImageURL { get; set; }
//public ICollection<FavoriteCat> FavoriteCats { get; set; }
//public ICollection<CatVaccine> CatVaccines { get; set; }