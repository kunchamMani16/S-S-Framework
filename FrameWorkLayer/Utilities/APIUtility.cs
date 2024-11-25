
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FrameWorkLayer.Utilities
{
    public class APIUtility
    {
        private RestClient restClient;
        private RestRequest restRequest;
        private RestResponse restResponse;
        public APIUtility(string url)
        {
            restClient = new RestClient(url);
        }
        public RestRequest GetRestRequest(string endpoint, Method method)
        {
            return new RestRequest(endpoint, method);
        }
        public T Get<T>(string endpoint, Dictionary<string, string> parameters = null)
        {
            restRequest = GetRestRequest(endpoint, Method.Get);

            if (parameters != null) AddParameters(parameters);
            restResponse = restClient.Execute(restRequest);
            return JsonConvert.DeserializeObject<T>(restResponse.Content);
        }


        public (T, HttpStatusCode) Post<T, T1>(string endpoint, T1 body)
        {
            restRequest = GetRestRequest(endpoint, Method.Post);
            string jsonBody = JsonConvert.SerializeObject(body);
            restRequest.AddJsonBody(jsonBody);
            var response = restClient.Execute(restRequest);
            var data = JsonConvert.DeserializeObject<T>(response.Content);
            return (data, response.StatusCode);
        }
        public int GetStausCode()
        {
            return (int)restResponse.StatusCode;
        }
        public void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> key in headers)
            {
                restRequest.AddHeader(key.Key, key.Value);

            }
        }
        public void AddParameters(Dictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> key in parameters)
            {
                restRequest.AddParameter(key.Key, key.Value);
            }
        }
    }
}


