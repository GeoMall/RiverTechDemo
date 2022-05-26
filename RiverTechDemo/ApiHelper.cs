using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RiverTechDemo
{
    public class ApiHelper
    {
        public ApiHelper(){ }

        public static HttpClient Client { get; set; }

        /// <summary>
        /// Initializing the HTTPClient and setting the default request headers to accept application/jason
        /// </summary>
   
        public void InitializeClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();

            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }


        /// <summary>
        /// Call the API using Get HTTP VERB. If the Status code is successful, the response data is returned.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserModel> CallApiUsingGet(string userId)
        {
            string url = $"https://jsonplaceholder.typicode.com/users/{ userId }";
           
            using (HttpResponseMessage response = await Client.GetAsync(url))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
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

        /// <summary>
        ///  Call the API using POST HTTP VERB. This call should return an errored response.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CallApiUsingPost(string userId)
        {
            string url = $"https://jsonplaceholder.typicode.com/users/{ userId }";
            var values = new Dictionary<string, string>
                          {
                              { userId, userId },
                          };
            var content = new FormUrlEncodedContent(values);

            using (HttpResponseMessage response = await Client.PostAsync(url, content).ConfigureAwait(false))
            {
                return response;               
            }
        }

        /// <summary>
        ///  Call the API using Get HTTP VERB. The full response is being returned.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
