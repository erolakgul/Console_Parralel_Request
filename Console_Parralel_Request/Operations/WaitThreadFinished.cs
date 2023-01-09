using Console_Parralel_Request.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Parralel_Request.Operations
{
    public class WaitThreadFinished
    {
        public WaitThreadFinished()
        {

        }
        public void ComparerThreads()
        {
            Console.WriteLine("******************************* START ************************************");

            Helper helper = new Helper();

            /*******************************  senkron *************************************/
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 24; i++)
            {
                helper.Counter("Counter", 0, i);
            }

            Console.WriteLine();
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed (For): {stopwatch.Elapsed} ..... dolan list<string> sayısı => {helper.DataList.Count} ");


            /*******************************  paralel  *************************************/

            List<int> vList = new();

            for (int i = 0; i < 24; i++)
            {
                vList.Add(i);
            }

            Stopwatch stopwatch2 = Stopwatch.StartNew();

            const int nThreadCount = 24;
            Thread[] workerThreads = new Thread[nThreadCount];

            /* Start Threads */
            for (int k = 0; k < nThreadCount; k++)
            {
                //foreach (var item in vList)
                //{
                //    workerThreads[k] = new Thread(() => helper.Counter("Th", 0, item));
                //    workerThreads[k].Start();
                //}

                workerThreads[k] = new Thread(() => helper.Counter("Th", 0, k));
                workerThreads[k].Start(/*optional thread data */);

            }

            /* Wait for all Threads to finish */
            for (int k = 0; k < nThreadCount; k++)
            {
                workerThreads[k].Join();

            }

            stopwatch2.Stop();

            if (stopwatch2.Elapsed > TimeSpan.Zero)
                Console.WriteLine($"Time elapsed (For): {stopwatch2.Elapsed}  ..... dolan list<string> sayısı =>  {helper.DataList.Count} \n");


            /********************************************************************************/
            for (int i = 0; i < helper.DataList.Count; i++)
            {
                Console.WriteLine($" Result List<string> => {helper.DataList[i]}");

            }

            Console.WriteLine("******************************* FINISHED ************************************");
        }
    }
}
