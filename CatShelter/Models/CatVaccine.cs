namespace CatShelter.Models
{
    public class CatVaccine
    {
        public int Id {  get; set; }
        public int CatId { get; set; }
        public Cat Cat { get; set; } // 1 : 1
        public int VaccineId { get; set; }
        public Vaccine Vaccine { get; set; } // 1 : 1
    }
}
