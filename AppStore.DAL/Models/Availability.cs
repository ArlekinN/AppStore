namespace AppStore.DAL.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public int IdStore { get; set; }
        public int IdProduct { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }

}
