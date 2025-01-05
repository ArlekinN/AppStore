namespace AppStore.DAL.Interfaces
{
    public abstract class IRepositoryStore
    {
        public bool CreateStore(string nameStore, string address) { return true; }
        public int GetStoreByName(string store) { return 0; }
        public List<string> ShowAllStores() { return new List<string>(); }
        public string GetStoreById(int idStore) { return ""; }
    }
}
