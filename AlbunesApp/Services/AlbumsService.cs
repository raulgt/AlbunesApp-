using AlbunesApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace AlbunesApp.Services
{
    public class AlbumsService
    {
        public AlbumsService(){ }

        string baseUrl = "https://jsonplaceholder.typicode.com/";

        public async Task<List<Album>> AlbumsListAsync()
        {
            List<Album> albums = new List<Album>();
            string path = "albums";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;   

                    albums = JsonConvert.DeserializeObject<List<Album>>(result);

                    return albums;
                }
            }
            return null;
        }


        public async Task<List<AlbumDetail>> AlbumsDetailListAsync()
        {
            List<AlbumDetail> albumsDetails = new List<AlbumDetail>();
            string path = "photos";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;                  

                    albumsDetails = JsonConvert.DeserializeObject<List<AlbumDetail>>(result);

                    return albumsDetails;
                }
            }
            return null;
        }

        public async Task<List<AlbumComments>> AlbumsCommentsListAsync()
        {
            List<AlbumComments> albumsComments = new List<AlbumComments>();
            string path = "comments";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    albumsComments = JsonConvert.DeserializeObject<List<AlbumComments>>(result);

                    return albumsComments;
                }
            }
            return null;
        }
    }
}