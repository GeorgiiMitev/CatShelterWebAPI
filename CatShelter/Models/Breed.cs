namespace CatShelter.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; } 

        public ICollection<Cat> Cats { get; set; } // 1 : M // 1 порода принадлежи на много котки
    }
}
