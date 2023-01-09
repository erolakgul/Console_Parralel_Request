using Console_Parralel_Request.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Parralel_Request.Operations
{
    public class ParallelProcessing
    {
        public ParallelProcessing()
        {

        }

        public void Process()
        {
            Helper helper = new();

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            helper.Calculator();
            stopwatch2.Stop();
            Console.WriteLine($"2. Paralel olmayan işlemin bitiş süresi : {stopwatch2.Elapsed} ");

            Stopwatch stopwatch3 = Stopwatch.StartNew();
            helper.ParallelCalculator();
            stopwatch3.Stop();
            Console.WriteLine($"2. Paralel işlemin bitiş süresi : {stopwatch3.Elapsed} ");
        }
    }
}
