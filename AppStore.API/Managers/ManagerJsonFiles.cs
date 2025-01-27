using Newtonsoft.Json;

namespace AppStore.API.Managers
{
    internal static class ManagerJsonFiles
    {
        public static T GetData<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
