using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Interfaces
{
    internal abstract class IRepositoryProduct
    {
        public bool CreateProduct(string nameProduct) { return true; }
        public int GetProductByName(string product) { return 0; }
        public List<string> ShowUniqProducts() { return new List<string>(); }
    }
}
