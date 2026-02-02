namespace CatShelter.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CatVaccine> CatVaccines { get; set; }

    }
}
