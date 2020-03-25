using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using VideoBrekWebApi.ViewModels;
namespace VideoBrekWebApi.Helpers
{
    public class ApiHelper
    {
        public static async Task<string> HttpGetAccessToken(string url, TokenViewModel json)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(url);


                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("userName", json.Username));
                nvc.Add(new KeyValuePair<string, string>("Password", json.Password));
                nvc.Add(new KeyValuePair<string, string>("grant_type", "password"));

                var sendContent = new FormUrlEncodedContent(nvc);


                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.PostAsync(client.BaseAddress, sendContent);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return (content);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return (content);
                }
            }

        }
    }
}
