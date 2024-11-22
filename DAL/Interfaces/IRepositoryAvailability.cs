using AppStore.Models;
using AppStore.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Interfaces
{
    internal abstract class IRepositoryAvailability
    {
        public abstract Task<List<ShowProduct>> GetAllProducts();
        
    }
}
