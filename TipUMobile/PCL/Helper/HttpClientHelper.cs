using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using Newtonsoft.Json;
using static VideoBrek.Models.MediaHandlerModel;
using Newtonsoft.Json.Linq;

namespace VideoBrek.PCL.Helper
{
    class HttpClientHelper
    {


        public async Task<ResultModel> Get<T>(string url)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }

                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<JObject>(content);
                    ResultModel rslt = new ResultModel();
                    try
                    {
                        //string res = content.Replace("null", "\"\"");
                        rslt.Response = result["result"]["items"].ToString();
                        rslt.Status = 200;
                        return rslt;
                        
                        //return JsonConvert.DeserializeObject<ResultModel>(content);

                    }
                    catch (Exception ex)
                    {
                        return JsonConvert.DeserializeObject<ResultModel>(content);
                    }
                    
                }
            }
            
            return default(ResultModel);
        }

        public async Task<T> GetMedia<T>(string url)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }

                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    try
                    {
                        string res = content.Replace("null", "\"\"");
                        return JsonConvert.DeserializeObject<T>(res);

                    }
                    catch (Exception ex)
                    {
                        return JsonConvert.DeserializeObject<T>(content);
                    }
                }
            }
            return default(T);
        }


        public async Task<ResultModel> Post<T>(T obj, string url)
        {
            ResultModel resp = new ResultModel { Status = 0, Message = "", Response = null };
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                var json = JsonConvert.SerializeObject(obj);
                var sendContent = new StringContent(json, Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }
                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.PostAsync(client.BaseAddress + url, sendContent);
                }
                catch (Exception ex)
                {
                    resp.Message = ex.Message;
                }

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<JObject>(content);
                    ResultModel rslt = new ResultModel();
                    if (result.HasValues)
                    {
                        //rslt.accessToken = result["result"]["accessToken"].ToString();
                        //rslt.userId = int.Parse(result["result"]["userId"].ToString());
                        //rslt.success = result["success"].ToString(); 
                        rslt.Response = result["result"].ToString();
                        rslt.Status = 200;
                    }
                    return rslt;
                    //return JsonConvert.DeserializeObject<ResultModel>(content);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
            }
        }


        public async Task<ResultModel> PostData<T>(T obj, string url)
        {
            ResultModel resp = new ResultModel { Status = 0, Message = "", Response = null };
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                var json = JsonConvert.SerializeObject(obj);

                var sendContent = new StringContent(json, Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }
                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.PostAsync(client.BaseAddress + url, sendContent);
                }
                catch (Exception ex)
                {
                    resp.Message = ex.Message;
                }

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
            }
        }

        public async Task<ResultModel> PostData(string url)
        {
            ResultModel resp = new ResultModel { Status = 0, Message = "", Response = null };
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                var sendContent = new StringContent("application/json");
                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }
                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.PostAsync(client.BaseAddress + url, sendContent);
                }
                catch (Exception ex)
                {
                    resp.Message = ex.Message;
                }

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
            }
        }

        public async Task<ResultModel> Put<T>(T obj, string url)
        {
            ResultModel resp = new ResultModel { Status = 0, Message = "", Response = null };
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                client.BaseAddress = new Uri(GlobalConstant.BaseUrl);

                var json = JsonConvert.SerializeObject(obj);
                var sendContent = new StringContent(json, Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(GlobalConstant.AccessToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer" + " " + GlobalConstant.AccessToken);
                }
                else
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.PutAsync(client.BaseAddress + url, sendContent);
                }
                catch (Exception ex)
                {
                    resp.Message = ex.Message;
                }

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<JObject>(content);
                    ResultModel rslt = new ResultModel();
                    if (result.HasValues)
                    {
                        //rslt.accessToken = result["result"]["accessToken"].ToString();
                        //rslt.userId = int.Parse(result["result"]["userId"].ToString());
                        //rslt.success = result["success"].ToString(); 
                        rslt.Response = result["result"].ToString();
                        rslt.Status = 200;
                    }
                    return rslt;
                    //return JsonConvert.DeserializeObject<ResultModel>(content);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultModel>(content);
                }
            }
        }
    }
}