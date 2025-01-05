namespace AppStore.DAL.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Store() { }
        public Store(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

    }
}
