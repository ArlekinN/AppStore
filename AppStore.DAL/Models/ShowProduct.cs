namespace AppStore.DAL.Models
{
    public class ShowProduct
    {
        public string Product { get; set; }
        public string Store { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public ShowProduct() { }
    }
}
