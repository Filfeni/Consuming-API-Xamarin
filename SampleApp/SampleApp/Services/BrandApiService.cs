using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SampleApp.Services
{
    public class BrandApiService : IBrandApiService
    {
        public async Task<ObservableCollection<Brand>> GetBrandAsync()
        {
            ObservableCollection<Brand> brands = null;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://xamrentapi.azurewebsites.net/api/const/brands");
            if (response.IsSuccessStatusCode)
            {
                brands = JsonConvert.DeserializeObject<ObservableCollection<Brand>>(await response.Content.ReadAsStringAsync());
            }
            return brands;
        }
    }
}
