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
        public abstract Task<bool> CreateStore(string nameStore, string address);
    }
}
