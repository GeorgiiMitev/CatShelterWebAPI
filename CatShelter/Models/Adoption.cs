namespace CatShelter.Models
{
    public class Adoption
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; } // 1 : 1
        public int CatId {  get; set; }
        public Cat Cat { get; set; } // 1 : 1
        public string Description { get; set; } = string.Empty;
        public DateTime AdoptionDate { get; set; } = DateTime.Now;
    }
}
