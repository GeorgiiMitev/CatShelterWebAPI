using System.ComponentModel;

namespace CatShelter.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public int Age {  get; set; }
        public string Gender { get; set; }   
        public int BreedId {  get; set; }
        public Breed Breed { get; set; } // 1 : 1
        
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public Adoption? Adoption { get; set; }
        public ICollection<FavoriteCat> FavoriteCats { get; set; }
        public ICollection<CatVaccine> CatVaccines { get; set; }


    }
}
