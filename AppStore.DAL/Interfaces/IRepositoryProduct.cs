namespace AppStore.DAL.Interfaces
{
    public interface IRepositoryProduct
    {
        bool CreateProduct(string nameProduct) { return false; }
        int GetProductByName(string product) { return 0; }
        List<string> ShowUniqueProducts() { return []; }
    }
}
