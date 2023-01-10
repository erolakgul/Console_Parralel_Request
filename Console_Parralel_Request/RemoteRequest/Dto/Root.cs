using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Parralel_Request.RemoteRequest.Dto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //public class City
    //{
    //    public string regular { get; set; }
    //    public string midGrade { get; set; }
    //    public string premium { get; set; }
    //    public string diesel { get; set; }
    //    public string name { get; set; }
    //}

    //public class Result
    //{
    //    public State state { get; set; }
    //    public List<City> cities { get; set; }
    //}

    //public class Root
    //{
    //    public bool success { get; set; }
    //    public Result result { get; set; }
    //}

    //public class State
    //{
    //    public string name { get; set; }
    //    public string regular { get; set; }
    //    public string midGrade { get; set; }
    //    public string premium { get; set; }
    //    public string diesel { get; set; }
    //}

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Result
    {
        public double katkili { get; set; }
        public double benzin { get; set; }
        public string marka { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public List<Result> result { get; set; }
    }

}
