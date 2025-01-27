using AppStore.BLL.Strategies;
using AppStore.DAL.Configuration;
using Serilog;

namespace AppStore.BLL
{
    public class ProductService
    {
        private IDataDisplay DataDisplay { get; set; }
        public ProductService()
        {
            if (Config.TypeDal == "Database")
            {
                DataDisplay = new DataDisplayDatabase();
            }
            else
            {
                DataDisplay = new DataDisplayFiles();
            }
        }

        public bool CreateProduct(string name)
        {
            Log.Information("ProductService: Create Product");
            return DataDisplay.CreateProduct(name);
        }

        public List<string> ShowUniqueProducts()
        {
            Log.Information("ProductService: Show Unique Products");
            return DataDisplay.ShowUniqueProducts();
        }
    }
}
