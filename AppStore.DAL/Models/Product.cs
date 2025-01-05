namespace AppStore.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdStore { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Product() { }
        public Product(int id, string name, int idStore, int price, int amount)
        {
            Id = id;
            Name = name;
            IdStore = idStore;
            Price = price;
            Amount = amount;
        }
    }
}
