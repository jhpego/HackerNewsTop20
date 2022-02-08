using BestHackerNews.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace BestHackerNews.Services
{
    public class ApiClient
    {


        public string GenericRawGet(string url)
        {
            string output = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    string urlParameters = "?api_key=123";
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        output = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        string exMsg = string.Format("Error on Fetching data with status {0}, and reason {1}", response.StatusCode, response.ReasonPhrase);
                        throw new Exception(exMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PrimaryException("Error getting Api", ex);
            }

            return output;
        }


        public T GenericGet<T>(string url)
        {
            string rawResponse = GenericRawGet(url);
            T output = JsonConvert.DeserializeObject<T>(rawResponse);
            return output;
        }


    }
}