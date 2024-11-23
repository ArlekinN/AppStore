using AppStore.Models;
using AppStore.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Interfaces
{
    internal abstract class IRepositoryStore
    {
        public bool CreateStore(string nameStore, string address) { return true; }
        public int GetStoreByName(string store) { return 0; }
        public List<string> ShowAllStores() { return new List<string>(); }
        public string GetStoreById(int idStore) { return ""; }
    }
}
