using CatShelter.Models;

namespace CatShelter.Dtos
{
    public class CatVaccineDto
    {
        public record CatVaccineReadDto(int Id, int CatId, int VaccineId);
        public record CatVaccineReadIncludeNamesDto(int Id, int CatId, string Name, int VaccineId, string VaccineName);
        public record CatVaccineCreateDto(int CatId, int VaccineId);
    }
}
//public int Id { get; set; }
//public int CatId { get; set; }
//public Cat Cat { get; set; } // 1 : 1
//public int VaccineId { get; set; }
//public Vaccine Vaccine { get; set; } // 1 : 1