using DAL.Photo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Photos
{
    public class PhotosHttpClient
    {
        private readonly HttpClient _httpClient;
        public PhotosHttpClient(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<string> GetImageUrl(int id)
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("Access-Control-Allow-Origin", "*");

            var response = await _httpClient.GetAsync($"{id}/image");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<IEnumerable<Photo>> GetPhotosAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("http://localhost:5000/api/Photos"),
                Method = HttpMethod.Get,
            };
            request.Headers.Add("Access-Control-Allow-Origin", "*");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Photo>>();
        }
    }
}
