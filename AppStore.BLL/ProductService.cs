using AppStore.BLL.Strategies;
using AppStore.DAL.Configuration;

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
            return DataDisplay.CreateProduct(name);
        }

        public List<string> ShowUniqProducts()
        {
            return DataDisplay.ShowUniqProducts();
        }
    }
}
