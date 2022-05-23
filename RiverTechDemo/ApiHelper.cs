using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RiverTechDemo
{
    public class ApiHelper
    {
        public ApiHelper()
        { }

        public static HttpClient Client { get; set; }

        public void InitializeClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();

            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UserModel> CallApi(int userId)
        {
            string url = $"https://jsonplaceholder.typicode.com/users/{ userId }";
            
            using (HttpResponseMessage response = await Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var userModel = await response.Content.ReadAsAsync<UserModel>();
                    return userModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<HttpResponseMessage> GetApiResponseStatus(int userId)
        {
            string url = $"https://jsonplaceholder.typicode.com/users/{ userId }";

            using (HttpResponseMessage response = await Client.GetAsync(url))
            {
                return response;
            }
        }

        public static void Main(String [] args)
        {

        }
    }
}
