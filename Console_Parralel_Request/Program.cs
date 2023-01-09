using Console_Parralel_Request.Operations;
using Console_Parralel_Request.RemoteRequest;

ThreadComparing threadComparing = new ();
WaitThreadFinished waitThreadFinished = new ();
ParallelProcessing parallelProcessing = new();
AkaryakitApi akaryakitApi = new ();

#region thread in sonlanmasını beklemeden yanı anda başlatınca içerideki verinin tamamı alınamıyor
//threadComparing.ComparerThreads();
#endregion

Console.WriteLine();

#region thread in sonlanması beklenirse
//waitThreadFinished.ComparerThreads();
#endregion

Console.WriteLine();

#region parallel processing
//parallelProcessing.Process();
//parallelProcessing.Process_ParalelForeach();
#endregion


#region akaryakit

#endregion

Console.ReadLine();