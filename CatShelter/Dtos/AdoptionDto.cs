using CatShelter.Models;

namespace CatShelter.Dtos
{
    public class AdoptionDto
    {
        public record AdoptionReadDto(int Id, int UserId, int CatId, string Description, DateTime AdoptionDate);
        public record AdoptionReadIncludeNamesDto(int Id, int UserId, string FullName, int CatId, string CatName, string Description, DateTime AdoptionDate);
        public record AdoptionCreateDto(int UserId, int CatId, string Description, DateTime AdoptionDate);
    }
}
//public int Id { get; set; }
//public int UserId { get; set; }
//public User User { get; set; } // 1 : 1
//public int CatId { get; set; }
//public Cat Cat { get; set; } // 1 : 1
//public string Description { get; set; } = string.Empty;
//public DateTime AdoptionDate { get; set; } = DateTime.Now;