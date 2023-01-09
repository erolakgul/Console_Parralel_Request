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

            for (int i = 0; i < 3; i++)
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

            const int nThreadCount = 1;
            Thread[] workerThreads = new Thread[nThreadCount];

            /* Start Threads */
            for (int k = 0; k < nThreadCount; k++)
            {
                foreach (var item in vList)
                {
                    workerThreads[k] = new Thread(() => helper.Counter("Th", 0, item));
                    workerThreads[k].Start(/*optional thread data */);
                }

            }

            /* Wait for all Threads to finish */
            for (int k = 0; k < nThreadCount; k++)
            {
                workerThreads[k].Join();

            }
            //Thread tread1 = new Thread(() => helper.Counter("Th", 0, 0));
            //tread1.Start();

            //Thread tread2 = new Thread(() => helper.Counter("Th", 0, 1));
            //tread2.Start();

            //Thread tread3 = new Thread(() => helper.Counter("Th", 0, 2));
            //tread3.Start();



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
