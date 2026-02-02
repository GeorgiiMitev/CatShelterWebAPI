namespace CatShelter.Dtos
{
    public class BreedDto
    {
        public record BreedReadDto(int Id, string Name, string Color, string Description);
        public record BreedCreateDto(string Name, string Color, string Description);
    }
}
//public int Id { get; set; }
//public string Name { get; set; }
//public string Color { get; set; }
//public string Description { get; set; }