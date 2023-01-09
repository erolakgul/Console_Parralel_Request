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
        public AkaryakitApi()
        {
            _appClient = new HttpClient();
            GetHttpClient();
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

            HttpResponseMessage response = null;

            try
            {
                response = await _appClient.GetAsync(_appClient.BaseAddress + "district=" + district + "&city=" + city);

                if (response.IsSuccessStatusCode)
                {
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);


                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }


        }


    }
}
