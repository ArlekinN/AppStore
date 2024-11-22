using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Interfaces
{
    internal abstract class IRepositoryProduct
    {
        public abstract Task<bool> CreateProduct(string nameProduct);
        public abstract Task<int> GetProductByName(string product);
        public abstract Task<List<string>> ShowUniqProducts();
    }
}
