using Console_Parralel_Request.RemoteRequest.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Console_Parralel_Request.RemoteRequest
{
    public class AkaryakitApi
    {
        protected HttpClient _appClient = null;

        public Dictionary<string, string> _cityList = null;
        public List<State> stateList = null;

        public AkaryakitApi()
        {
            _appClient = new HttpClient();
            GetHttpClient();

            _cityList = new();

            _cityList.Add("istanbul","kadikoy");
            _cityList.Add("istanbul", "besiktas");
            _cityList.Add("istanbul", "beykoz");
            _cityList.Add("istanbul", "maltepe");
            _cityList.Add("istanbul", "eminonu");

            _cityList.Add("izmir", "gaziemir");
            _cityList.Add("izmir", "menemen");
            _cityList.Add("izmir", "menderes");
            _cityList.Add("izmir", "konak");
            _cityList.Add("izmir", "odemis");

            _cityList.Add("ankara", "etimesgut");
            _cityList.Add("ankara", "evren");
            _cityList.Add("ankara", "kalecik");
            _cityList.Add("ankara", "sincan");
            _cityList.Add("ankara", "polatli");

            _cityList.Add("aydin", "efeler");
            _cityList.Add("aydin", "nazilli");
            _cityList.Add("aydin", "kusadasi");
            _cityList.Add("aydin", "incirliova");
            _cityList.Add("aydin", "soke");

            _cityList.Add("mugla", "bodrum");
            _cityList.Add("mugla", "dalaman");
            _cityList.Add("mugla", "fethiye");
            _cityList.Add("mugla", "datca");


            stateList = new();
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

        public async Task<List<State>> CustomReqAsync()  //string district, string city
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();

            string _error = "";

            foreach (var item in _cityList)
            {
                HttpResponseMessage response = null;

                try
                {
                    response = await _appClient.GetAsync(_appClient.BaseAddress + "district=" + item.Value + "&city=" + item.Key);

                    if (response.IsSuccessStatusCode)
                    {
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);

                        stateList.Add(myDeserializedClass.result.state);
                    }
                }
                catch (Exception ex)
                {
                    _error = ex.Message;
                }

            }
            stopwatch.Stop();

            Console.WriteLine($"Paralel olmayan işlemin bitiş süresi         : {stopwatch.Elapsed}");

            return stateList;
        }


        public async Task<List<State>> CustomReqAsyncMultiThread()  //string district, string city
        {
            ParallelOptions parallelOptions = new()
            {
                MaxDegreeOfParallelism = 8
            };

            Stopwatch stopwatch = new();

            stopwatch.Start();

            string _error = "";

            await Parallel.ForEachAsync(_cityList, parallelOptions, async (item, token) =>
            {
                HttpResponseMessage response = null;

                try
                {
                    response = await _appClient.GetAsync(_appClient.BaseAddress + "district=" + item.Value + "&city=" + item.Key);

                    if (response.IsSuccessStatusCode)
                    {
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);

                        stateList.Add(myDeserializedClass.result.state);
                    }
                }
                catch (Exception ex)
                {
                    _error = ex.Message;
                }

            });

            stopwatch.Stop();
            Console.WriteLine($"8 kanallı Paralel işlemin bitiş süresi         : {stopwatch.Elapsed}");

            return stateList;
        }

    }
}
