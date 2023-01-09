using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Parralel_Request.RemoteRequest.Dto
{
    public class Root
    {
        public bool success { get; set; }
        public List<Result> result { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Result
    {
        public double katkili { get; set; }
        public double benzin { get; set; }
        public string marka { get; set; }
    }

}
