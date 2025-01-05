namespace AppStore.DAL.Models
{
    public class Consigment
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Consigment(int id, string product, int price, int amount)
        {
            Id = id; 
            Product = product;
            Price = price;
            Amount = amount;
        }
        public Consigment() { }
    }
}
