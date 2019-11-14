using DALPhotos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Photos
{
    public class PhotosHttpClient/* : IPhotosHttpClient*/
    {
        private readonly HttpClient _httpClient;
        //private readonly HttpContextAccessor _httpContext;
        public PhotosHttpClient(HttpClient _httpClient/*, IHttpContextAccessor _httpContext*/)
        {
            this._httpClient = _httpClient;
            //this._httpContext = _httpContext;
        }

        public async Task<string> GetImageUrl(int id)
        {
            var response = await _httpClient.GetAsync($"{id}/image");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<IEnumerable<Photo>> GetPhotosAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{id}/image");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Photo>>();
        }
    }

    //public interface IPhotosHttpClient
    //{
    //    Task<string> GetImageUrl(int id);
    //    Task<IEnumerable<Photo>> GetPhotosAsync(int id);
    //}
}
