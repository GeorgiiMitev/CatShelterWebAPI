using CatShelter.Models;

namespace CatShelter.Dtos
{
    public class VaccineDto
    {
        public record VaccineReadDto(int Id, string Name, string Description);
        public record VaccineCreateDto(string Name, string Description);
    }
}
//public int Id { get; set; }
//public string Name { get; set; }
//public string Description { get; set; }

//public ICollection<CatVaccine> CatVaccines { get; set; }