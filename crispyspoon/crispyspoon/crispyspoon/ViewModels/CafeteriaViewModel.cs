using CrispySpoon.API.V2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrispySpoon.ViewModels
{
    public class CafeteriaViewModel : BaseViewModel
    {
        public ObservableCollection<tbm_cafeteria> Cafeterias { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CafeteriaViewModel()
        {
            Title = "Cafeteria";
            Cafeterias = new ObservableCollection<tbm_cafeteria>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadCafeteriasCommand());
        }

        async Task ExecuteLoadCafeteriasCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Cafeterias.Clear();
                IEnumerable<tbm_cafeteria> cafes;

                using (var client = new HttpClient())
                {
                    var uri = "https://crispyspoonapi.azurewebsites.net/api/cafeteria";

                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Host = "10.155.103.181:6050";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await client.GetAsync(uri);

                    //handling the answer  
                    cafes = JsonConvert.DeserializeObject<IEnumerable<tbm_cafeteria>>(result.RequestMessage.ToString());
                }

                foreach (var cafe in cafes)
                {
                    Cafeterias.Add(cafe);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
