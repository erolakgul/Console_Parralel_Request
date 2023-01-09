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
            Console.WriteLine($"2. Paralel olmayan işlemin bitiş süresi : {stopwatch2.Elapsed}"); // ... Result => {helper.sonuc}



            Helper helper2 = new();
            Stopwatch stopwatch3 = Stopwatch.StartNew();
            helper2.ParallelCalculator();
            stopwatch3.Stop();
            Console.WriteLine($"2. Paralel işlemin bitiş süresi         : {stopwatch3.Elapsed}"); // ... Result => {helper2.sonuc}
        }


        public void Process_ParalelForeach()
        {

            List<string> items = new(); // { "item - 1", "item - 2", "item - 3", "item - 4", "item - 5", "item - 6", "item - 7", "item - 8", "item - 9", "item - 10" };
            List<string> _afterList = new();

            for (int i = 0; i < 24; i++)
            {
                items.Add("item-" + i);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"1. Paralel işlemin bitiş süresi         : {stopwatch.Elapsed}");

            Stopwatch stopwatch3 = Stopwatch.StartNew();
            Parallel.ForEach(items, (item) =>
            {
                Console.WriteLine(item);
                _afterList.Add(item);   
            });
            stopwatch3.Stop();
            Console.WriteLine($"2. Paralel işlemin bitiş süresi         : {stopwatch3.Elapsed} ... result => {_afterList.Count}");
        }
    }
}
