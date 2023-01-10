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

        public List<ResponseModel> _cityList = null;
        public List<Result> stateList = null;

        public AkaryakitApi()
        {
            _appClient = new HttpClient();
            GetHttpClient();

            _cityList = new()
            {
                new ResponseModel() { City = "istanbul", Distrinct = "kadikoy" },
                new ResponseModel() { City = "istanbul", Distrinct = "besiktas" },
                new ResponseModel() { City = "istanbul", Distrinct = "beykoz" },
                new ResponseModel() { City = "istanbul", Distrinct = "maltepe" },
                new ResponseModel() { City = "istanbul", Distrinct = "eminonu" },

                new ResponseModel() { City = "izmir", Distrinct = "gaziemir" },
                new ResponseModel() { City = "izmir", Distrinct = "menemen" },
                new ResponseModel() { City = "izmir", Distrinct = "menderes" },
                new ResponseModel() { City = "izmir", Distrinct = "konak" },
                new ResponseModel() { City = "izmir", Distrinct = "odemis" },

                new ResponseModel() { City = "ankara", Distrinct = "etimesgut" },
                new ResponseModel() { City = "ankara", Distrinct = "evren" },
                new ResponseModel() { City = "ankara", Distrinct = "kalecik" },
                new ResponseModel() { City = "ankara", Distrinct = "sincan" },
                new ResponseModel() { City = "ankara", Distrinct = "polatli" },

                new ResponseModel() { City = "aydin", Distrinct = "efeler" },
                new ResponseModel() { City = "aydin", Distrinct = "nazilli" },
                new ResponseModel() { City = "aydin", Distrinct = "kusadasi" },
                new ResponseModel() { City = "aydin", Distrinct = "incirliova" },
                new ResponseModel() { City = "aydin", Distrinct = "soke" },

                new ResponseModel() { City = "mugla", Distrinct = "bodrum" },
                new ResponseModel() { City = "mugla", Distrinct = "dalaman" },
                new ResponseModel() { City = "mugla", Distrinct = "fethiye" },
                new ResponseModel() { City = "mugla", Distrinct = "datca" }
            };

            stateList = new();
        }

        private HttpClient GetHttpClient()
        {
            _appClient.DefaultRequestHeaders.Accept.Clear();
            _appClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _appClient.Timeout = TimeSpan.FromDays(1);
            _appClient.BaseAddress = new Uri("https://api.collectapi.com/gasPrice/turkeyGasoline?"); //district=kadikoy&city=istanbul
            _appClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Free", "6DJy0BRdBsvmSsfK8yX21Q:3S8CNrJwcNpruJNhBKGhDZ");
            return _appClient;
        }

        public async Task<List<Result>> CustomReqAsync()  //string district, string city
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();

            string _error = "";

            foreach (var item in _cityList)
            {
                HttpResponseMessage response = null;

                try
                {
                    response = await _appClient.GetAsync(_appClient.BaseAddress + "district=" + item.Distrinct + "&city=" + item.City);

                    if (response.IsSuccessStatusCode)
                    {
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);

                        stateList.AddRange(myDeserializedClass.result);
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


        public async Task<List<Result>> CustomReqAsyncMultiThread()  //string district, string city
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
                    response = await _appClient.GetAsync(_appClient.BaseAddress + "district=" + item.Distrinct + "&city=" + item.City);

                    if (response.IsSuccessStatusCode)
                    {
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);

                        stateList.AddRange(myDeserializedClass.result);
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
