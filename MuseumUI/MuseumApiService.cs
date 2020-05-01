using MuseumUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;


namespace MuseumUI
{
    public class MuseumApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<vArt> GetArtworkAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                vArt art = await response.Content.ReadAsAsync<vArt>();
                return art;
            }
            return null;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default;
        }
    }
}
