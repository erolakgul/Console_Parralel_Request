using Console_Parralel_Request.RemoteRequest.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Console_Parralel_Request.RemoteRequest
{
    public class AkaryakitApi
    {
        protected HttpClient _appClient = null;
        protected Dictionary<string, string> _headers = new ();
        public AkaryakitApi()
        {
            _appClient = new HttpClient();
            GetHttpClient();

            _headers.Add("istanbul","kadikoy");
            _headers.Add("istanbul", "besiktas");
            _headers.Add("istanbul", "beykoz");
            _headers.Add("istanbul", "maltepe");
            _headers.Add("istanbul", "eminonu");

            _headers.Add("izmir", "gaziemir");
            _headers.Add("izmir", "menemen");
            _headers.Add("izmir", "menderes");
            _headers.Add("izmir", "konak");
            _headers.Add("izmir", "odemis");


        }

        private HttpClient GetHttpClient()
        {
            _appClient.DefaultRequestHeaders.Accept.Clear();
            _appClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _appClient.Timeout = TimeSpan.FromDays(1);
            _appClient.BaseAddress = new Uri("https://api.collectapi.com/gasPrice/turkeyGasoline?"); //district=kadikoy&city=istanbul
            _appClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apikey your_token");
            return _appClient;
        }

        public async Task CustomReq(string district, string city)
        {
            string _error = "";
            List<Result> results = new();

            HttpResponseMessage response = null;

            try
            {
                response = await _appClient.GetAsync(_appClient.BaseAddress + "district=" + district + "&city=" + city);

                if (response.IsSuccessStatusCode)
                {
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);

                    results = myDeserializedClass.result;
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }


        }


    }
}
