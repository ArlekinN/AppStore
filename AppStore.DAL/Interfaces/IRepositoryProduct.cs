namespace AppStore.DAL.Interfaces
{
    public abstract class IRepositoryProduct
    {
        public bool CreateProduct(string nameProduct) { return true; }
        public int GetProductByName(string product) { return 0; }
        public List<string> ShowUniqProducts() { return new List<string>(); }
    }
}
