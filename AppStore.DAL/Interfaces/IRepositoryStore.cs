namespace AppStore.DAL.Interfaces
{
    public interface IRepositoryStore
    {
        bool CreateStore(string nameStore, string address) { return false; }
        int GetStoreByName(string store) {  return 0; }
        List<string> ShowAllStores() { return []; }
        string GetStoreById(int idStore) { return string.Empty; }
    }
}
