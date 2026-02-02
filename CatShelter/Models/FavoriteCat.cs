namespace CatShelter.Models
{
    public class FavoriteCat
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public User User {  get; set; }

        public int CatId {  get; set; }
        public Cat Cat { get; set; }
    }
}
