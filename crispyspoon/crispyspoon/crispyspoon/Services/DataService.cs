using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace crispyspoon.Services
{
    public class DataService
    {
        public async Task<List<string>> GetData()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://crispyspoonapi.azurewebsites.net/api/cafeteria");
            var todoItems = JsonConvert.DeserializeObject<List<string>>(response);
            return todoItems;

        }
    }
}
